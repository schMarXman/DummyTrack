using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace DummyTrack
{
    class StringGenerator
    {
        private Random rnd;
        private ArrayList matricesList;
        private int matrices = 0;
        private int sixds = 0;
        private int flysticks = 0;
        private int frame = 0;
        private float timestamp = 0;
        public StringGenerator()
        {
            rnd = new Random();
            matricesList = new ArrayList();
        }
        /// <summary>
        /// Generates a new random matrix and adds it to the matrices list.
        /// </summary>
        public void GenerateMatrix()
        {
            int amount = sixds + flysticks;
            for (int i = 0; i < amount; i++)
            {
                var values = new float[9];
                for (int j = 0; j < values.Length; j++)
                {
                    values[j] = RandomFloatFromTo(rnd, -1F, 1F);
                }
                Matrix m = new Matrix(values);
                matricesList.Add(m); 
            }
        }

        /// <summary>
        /// Forges and returns a DTrack like packet with a random matrix.
        /// </summary>
        /// <returns></returns>
        public String GenerateString()
        {
            string output = "fr " + frame + Environment.NewLine +
                            "ts " + timestamp + Environment.NewLine +
                            "6dcal " + sixds + Environment.NewLine +
                            "6d 2 [0 1.000][-618.139 137.743 1185.127 79.0737 25.1774 22.9205]" + matricesList[0] +
                             "[1 1.000][-499.630 147.249 1249.461 -47.2664 20.4333 -77.2325]" + matricesList[1] + Environment.NewLine +
                             "3d 0" + Environment.NewLine +
                             "6df2 1 1 [0 1.000 4 2][29.288 22.800 1609.692]" + matricesList[2] + "[8 0.00 0.00]" + Environment.NewLine;
            matricesList.Clear();
            return output;
        }
        /// <summary>
        /// Reads a recording file and splits it into seperate packets.
        /// </summary>
        /// <param name="fileWPath">File and path of the recorded file</param>
        /// <returns>Returns the recorded file splited into single strings.</returns>
        public string[] ReadFile(string fileWPath)
        {
            StreamReader sr = new StreamReader(fileWPath, Encoding.Default);
            string completeFile = sr.ReadToEnd();
            string[] separator = { "#", "#", "#" };
            string[] splitedFile = completeFile.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            return splitedFile;           
        }
        /// <summary>
        /// Cleans up strings.
        /// </summary>
        /// <param name="strings">Strings to be cleaned up.</param>
        /// <returns>Returns cleaned up strings.</returns>
        public string[] CleanUpStrings(string[] strings)
        {
            for (int i = 0; i < strings.Length; i++)
            {
                if (strings[i].StartsWith("\r\n"))
                {
                    strings[i] = strings[i].Remove(0, 2);
                }
                if (strings[i].EndsWith("\r\n"))
                {
                    strings[i] = strings[i].Remove(strings[i].Length - 2);
                }
            }
            if (strings.Length-1 > 0)
            {
                if (strings[strings.Length - 1].Equals(""))
                {
                    string[] shortenedArray = new string[strings.Length - 1];
                    for (int j = 0; j < shortenedArray.Length; j++)
                    {
                        shortenedArray[j] = strings[j];

                    }
                    return shortenedArray;
                } 
            }
            return strings;
        }

        private string SetFlystickMarker(string s)
        {
            Regex r = new Regex(@"\[\d+\s+([+-]?\d*\.\d+)(?![-+0-9\.])\s+([+-]?\d*\.\d+)(?![-+0-9\.])\]");
            if (r.IsMatch(s))
            {
                s = r.Replace(s, "FLYSTICK"); 
            }
            return s;
        }

        private void ClearBits(BitArray b)
        {
            for (int i = 0; i < b.Length; i++)
            {
                b[i] = false;
            }
        }

        private string GenerateKeyboardString()
        {
            int b = ConvertButtonsToInt(DummyTrack.buttons);
            //DummyTrack.buttons = new BitArray(4);
            ClearBits(DummyTrack.buttons);
            string output = "[" + b + " " + DummyTrack.stickFloats[0] + " " + DummyTrack.stickFloats[1] + "]";
            Console.WriteLine(output);
            return output;        
        }
        /// <summary>
        /// Replaces strings tagged with "FLYSTICK" with the current button presses of the emulation. 
        /// </summary>
        /// <param name="mes">Message in which the emulation shall be integrated</param>
        /// <returns>Returns the finished message.</returns>
        public string ReplaceFlystickWithEmulation(string mes)
        {
            string output = SetFlystickMarker(mes);
            output = output.Replace("FLYSTICK", GenerateKeyboardString());
            return output;
        }

        private int ConvertButtonsToInt(BitArray bits)
        {
            int i = 0;
            if (bits[0])
            {
                i += 1;
            }
            if (bits[1])
            {
                i += 2;
            }
            if (bits[2])
            {
                i += 4;
            }
            if (bits[3])
            {
                i += 8;
            }
            return i;
        }

        public string[] SetFlystickMarker(string[] strings)
        {
            for (int i = 0; i < strings.Length; i++)
            {
                SetFlystickMarker(strings[i]);
            }
            return strings;
        }
        /// <summary>
        /// Checks if the loaded file is an actual recording.
        /// </summary>
        /// <param name="file">Filename with path.</param>
        /// <returns>Returns true if the file is a recording.</returns>
        public bool CheckFile(string file)
        {
            StreamReader sr = new StreamReader(file, Encoding.Default);
            string completeFile = sr.ReadToEnd();
            if (!completeFile.Contains("###") || completeFile.Equals("") || completeFile.Contains("No .log files"))
            {
                return false;
            }
            return true;

        }
        /// <summary>
        /// Generates a random float between given min and max parameters.
        /// </summary>
        /// <param name="rng">"Random" object</param>
        /// <param name="min">Minimum value</param>
        /// <param name="max">Maximum value</param>
        /// <returns></returns>
        public float RandomFloatFromTo(Random rng, float min, float max)
        {
            return min + (((float)rng.NextDouble()) * (max - min));
        }

        public void SetMatrixAmount(int amount)
        {
            matrices = amount;
        }

        public int Get6dAmount()
        {
            return sixds;
        }

        public int GetFlystickAmount()
        {
            return flysticks;
        }

        public void Set6dAmount(int amount)
        {
            sixds = amount;
        }

        public void SetFlystickAmount(int amount)
        {
            flysticks = amount;
        }

        public void SetFrame(int f)
        {
            frame = f;
        }

        public void SetTimestamp(float ts)
        {
            timestamp = ts;
        }
    }
}
