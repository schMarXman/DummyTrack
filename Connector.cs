using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DummyTrack
{
    internal class Connector
    {
        private Thread frameThread;
        private Thread timestampThread;
        private Thread connectionThread;
        private Thread recordingThread;
        private bool running;
        private int frameCount;
        private float timestamp;
        private Socket socket;
        private UdpClient client;
        private StringGenerator stringGen;
        private LogHandler log;
        private string recPath;
        private string currentFileStamp;
        private string outputMessage = "";
        private bool jamming;

        public Connector(TextBox l)
        {
            stringGen = new StringGenerator();
            log = new LogHandler(l);
        }
        /// <summary>
        /// Starts the random matrices thread and send it to opt_ip:port.
        /// </summary>
        /// <param name="port">Port</param>
        /// <param name="opt_ip">Optional IP</param>
        /// <param name="jam">NOT IMPLEMENTED</param>
        public void SendingStart(int port, string opt_ip = "127.0.0.1", bool jam = false)
        {
            running = true;
            jamming = jam;
            FrameThreadStart();
            TimestampThreadStart();
            SocketThreadStart(port, opt_ip);
            log.AddMessage("Generating packages with " + stringGen.Get6dAmount() + " 6d-Objects and " +
                           stringGen.GetFlystickAmount() + " Flysticks.");
            if (jamming)
            {
                log.NotifyJam(port);
            }
            else
            {
                log.NotifyStart(opt_ip, port);
            }
        }

        private void SocketThreadStart(int port, string opt_ip = "127.0.0.1")
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPAddress serverAddr;
            IPEndPoint endPoint;
            if (!jamming)
            {
                serverAddr = IPAddress.Parse(opt_ip);
                endPoint = new IPEndPoint(serverAddr, port);
            }
            else
            {
                endPoint = new IPEndPoint(IPAddress.Broadcast, port);
            }


            connectionThread = new Thread(() =>
            {
                while (running)
                {
                    stringGen.GenerateMatrix();
                    string send_string = stringGen.GenerateString();
                    if (DummyTrack.emulation)
                    {
                        send_string = stringGen.ReplaceFlystickWithEmulation(send_string);
                        //Console.WriteLine(send_string);
                    }
                    byte[] send_buffer = Encoding.ASCII.GetBytes(send_string);

                    try
                    {
                        socket.SendTo(send_buffer, endPoint);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    Console.WriteLine(send_string);
                }
            });
            connectionThread.IsBackground = true;
            connectionThread.Start();
        }
        /// <summary>
        /// Starts the recording thread to record incoming packets from DTrack2
        /// </summary>
        /// <param name="port">Port on which DTrack sends</param>
        /// <param name="filePath">Filepath where the recording will be savec</param>
        /// <param name="opt_ip">Optional IP</param>
        public void RecordingStart(int port, string filePath, string opt_ip = "127.0.0.1")
        {
            //string incomingString;
            //incomingString += Environment.NewLine + "###" + Environment.NewLine;
            //System.IO.File.WriteAllText(@"C:\ARTLOG\log" + i + ".txt", incomingString);
            running = true;
            recPath = filePath;
            currentFileStamp = GetTimestamp(DateTime.Now);
            RecordingThreadStart(port, opt_ip);
            log.AddMessage("Recording packets from " + opt_ip + ":" + port + Environment.NewLine
                           + "to file: " + @filePath + @"\rec" + currentFileStamp + ".log");
        }

        private void RecordingThreadStart(int port, string opt_ip = "127.0.0.1")
        {
            IPAddress serverAddr = IPAddress.Parse(opt_ip);
            IPEndPoint endPoint = new IPEndPoint(serverAddr, port);
            //byte[] buffer = new byte[2048];
            bool firstrun = true;
            string oldMessage = "";
            string newMessage = "";
            //int timeout = 0;
            try
            {
                client = new UdpClient(port);
                recordingThread = new Thread(() =>
                {
                    while (running)
                    {
                        byte[] buffer = client.Receive(ref endPoint);
                        newMessage = Encoding.ASCII.GetString(buffer);
                        //Console.WriteLine("newmes: " + newMessage);
                        if (firstrun)
                        {
                            oldMessage = newMessage;
                            Console.WriteLine("1. oldmes: " + oldMessage);
                            firstrun = false;
                        }
                        if (!oldMessage.Equals(newMessage))
                        {
                            outputMessage += newMessage + Environment.NewLine + "###" + Environment.NewLine;
                            //Console.WriteLine("Outmes: " + outputMessage);
                            oldMessage = newMessage;
                        }

                        //if (outputMessage == "")
                        //{
                        //    timeout++;
                        //}
                        //if (timeout == 100)
                        //{
                        //    recordingThread.Abort(); //
                        //    running = false; //THIS HAS BEEN CHANGED orig: stop();
                        //    throw new Exception(
                        //        "Client timed out. Check if DTrack is running and sending packages over " + opt_ip + ":" +
                        //        port + ".");
                        //}
                    }
                });
                recordingThread.IsBackground = true;
                recordingThread.Start();
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Get the current time stamp.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static String GetTimestamp(DateTime value)
        {
            return value.ToString("yyyy-MM-dd-HH-mm-ss");
        }

        /// <summary>
        /// Stops the recording thread.
        /// </summary>
        public void RecordingStop()
        {
            running = false;
            File.WriteAllText(@recPath + @"\rec" + currentFileStamp + ".log", outputMessage);
            log.AddMessage("Recording stopped" + Environment.NewLine + "Recording saved to " + @recPath + @"\rec" +
                           currentFileStamp + ".log");
            recordingThread.Abort();
            client.Close();
            client = null;
            currentFileStamp = "";
            outputMessage = "";
        }

        
        private void PlayingSocketStart(int port, string pathANDFile, string opt_ip = "127.0.0.1")
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPAddress serverAddr = IPAddress.Parse(opt_ip);
            IPEndPoint endPoint = new IPEndPoint(serverAddr, port);
            string[] fileStrings;
            int i = 0;

            connectionThread = new Thread(() =>
            {
                fileStrings = stringGen.CleanUpStrings(stringGen.ReadFile(pathANDFile));
                while (running)
                {
                    string send_string = fileStrings[i];
                    if (DummyTrack.emulation)
                    {
                        send_string = stringGen.ReplaceFlystickWithEmulation(send_string);
                        //Console.WriteLine(send_string);
                    }
                    byte[] send_buffer = Encoding.ASCII.GetBytes(send_string);

                    socket.SendTo(send_buffer, endPoint);
                    Thread.Sleep(DummyTrack.speedVal);
                    Console.WriteLine(send_string);
                    if (i < fileStrings.Length - 1)
                    {
                        i++;
                    }
                    else
                    {
                        i = 0;
                    }
                }
            });
            connectionThread.IsBackground = true;
            connectionThread.Start();
        }

        /// <summary>
        /// Starts a thread in which a recording is sent to the given IP and port.
        /// </summary>
        /// <param name="port">Port on which will be sent</param>
        /// <param name="pathANDFile">File with its path</param>
        /// <param name="opt_ip">Optional IP</param>
        public void PlayingStart(int port, string pathANDFile, string opt_ip = "127.0.0.1")
        {
            running = true;
            PlayingSocketStart(port, pathANDFile, opt_ip);
            log.AddMessage("Sending " + pathANDFile + " to " + opt_ip + ":" + port);
        }

        /// <summary>
        /// Stops the sending of a record thread.
        /// </summary>
        public void PlayingStop()
        {
            connectionThread.Abort();
            socket.Close();
            socket = null;
            running = false;
            log.AddMessage("Streaming file stopped");
        }

        private void FrameThreadStart()
        {
            frameThread = new Thread(() =>
            {
                while (running)
                {
                    frameCount++;
                    stringGen.SetFrame(frameCount);
                }
            });
            frameThread.IsBackground = true;
            frameThread.Start();
        }

        private void TimestampThreadStart()
        {
            timestampThread = new Thread(() =>
            {
                while (running)
                {
                    timestamp += 0.001F;
                    stringGen.SetTimestamp(timestamp);
                }
            });
            timestampThread.IsBackground = true;
            timestampThread.Start();
        }

        /// <summary>
        /// Stops the random sending thread
        /// </summary>
        public void SendingStop()
        {
            timestampThread.Abort();
            frameThread.Abort();
            connectionThread.Abort();
            socket.Close();
            socket = null;
            running = false;
            log.NotifyStop();
        }

        public StringGenerator GetStringGenerator()
        {
            return stringGen;
        }

        public LogHandler GetLogHandler()
        {
            return log;
        }
    }
}