using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using cheapHooker;

namespace DummyTrack
{
    public partial class DummyTrack : Form
    {
        private Connector c = null;
        private bool recording;
        private bool playing;
        private string folderPath = "";
        private int jamEnabler;
        public static int speedVal;
        private bool randomrunning = false;
        private KeyboardHook hook = new KeyboardHook();
        public static BitArray buttons = new BitArray(4);
        public static double[] stickFloats = {0,0};
        public static bool emulation = false;

        public DummyTrack()
        {
            InitializeComponent();
            stopButton.Enabled = false;
            textBox1.Enabled = false;
            recPlayStopButton.Enabled = false;
            checkThisPC.Checked = true;
            recPlayStopButton.Enabled = false;
            c = new Connector(logBox);
            c.GetStringGenerator().Set6dAmount(Convert.ToInt32(sixdCount.Text));
            c.GetStringGenerator().SetFlystickAmount(Convert.ToInt32(flystickCount.Text));
            fileCBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            fileCBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            recplayCheckThisPC.Checked = true;
            logBox.ScrollBars = ScrollBars.Vertical;
            logBox.VisibleChanged += (sender, e) =>
            {
                if (logBox.Visible)
                {
                    logBox.SelectionStart = logBox.TextLength;
                    logBox.ScrollToCaret();
                }
            };
            speedBar.ValueChanged += (sender, e) =>
            {
                speedBox.Text = Convert.ToString(speedBar.Value);
            };
            speedBox.TextChanged += (sender, e) =>
            {
                int val;
                if (!int.TryParse(speedBox.Text, out val))
                {
                    c.GetLogHandler().AddMessage("Please enter only numbers between 0 and 500 as a speed value");
                    return;
                }
                if (val > speedBar.Maximum)
                {
                    val = 500;
                }
                if (val < speedBar.Minimum)
                {
                    val = 0;
                }
                speedBar.Value = val;
                speedVal = val;
            };
            speedVal = Convert.ToInt32(speedBox.Text);
            speedBar.Value = speedVal;
            textBox1.KeyPress += textBox1_KeyPress;
            hook.KeyPressed += (hook_KeyPressed);
        }

        private void hook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            if (emulation)
            {
                c.GetLogHandler().AddMessage(e.Key + " pressed");
                if (e.Key == Keys.F)
                {
                    buttons[0] = true;
                }
                if (e.Key == Keys.D)
                {
                    buttons[1] = true;
                }
                if (e.Key == Keys.S)
                {
                    buttons[2] = true;
                }
                if (e.Key == Keys.A)
                {
                    buttons[3] = true;
                }
                if (e.Key == Keys.Right)
                {
                    if (stickFloats[0] < 0.9)
                    {
                        stickFloats[0] += 0.1;
                    }
                    c.GetLogHandler().AddMessage("x: " + stickFloats[0]);
                }
                if (e.Key == Keys.Left)
                {
                    if (stickFloats[0] > -0.9)
                    {
                        stickFloats[0] -= 0.1;
                    }
                    c.GetLogHandler().AddMessage("x: " + stickFloats[0]);
                }
                if (e.Key == Keys.Down)
                {
                    if (stickFloats[1] >= -0.9/* && stickFloats[1] <= 0*/)
                    {
                        stickFloats[1] -= 0.1;
                    }
                    c.GetLogHandler().AddMessage("y: " + stickFloats[1]);
                }
                if (e.Key == Keys.Up)
                {
                    if (stickFloats[1] <= 0.9/* && stickFloats[1] >= 0*/)
                    {
                        stickFloats[1] += 0.1;
                    }
                    c.GetLogHandler().AddMessage("y: " + stickFloats[1]); 
                }
            }


        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool clicked = false;
            if (e.KeyChar == (char)13 && !randomrunning)
            {
                startButton_Click(sender, e);
                clicked = true;
            }
            if (e.KeyChar == (char)13 && randomrunning && !clicked)
            {
                stopButton_Click(sender, e);
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (CheckIP(textBox1.Text) || checkThisPC.Checked)
            {
                int port;
                if (!int.TryParse(Port.Text, out port))
                {
                    c.GetLogHandler().AddMessage("Port is probably not a number. Please enter a valid number.");
                    return;
                }
                stopButton.Enabled = true;
                startButton.Enabled = false;
                recPlayStopButton.Enabled = false;
                recButton.Enabled = false;
                playButton.Enabled = false;
                folderButton.Enabled = false;
                fileCBox.Enabled = false;
                randomrunning = true;
                if (checkLog.Checked)
                {
                    tabs.SelectTab("log");
                }
                if (checkThisPC.Checked)
                {
                    if (jamCheck.Checked)
                    {
                        c.SendingStart(port, jam: true);
                    }
                    else
                    {
                        c.SendingStart(port);
                    }
                }
                else
                {
                    if (jamCheck.Checked)
                    {
                        string ip = textBox1.Text;
                        c.SendingStart(port, ip, true);
                    }
                    else
                    {
                        string ip = textBox1.Text;
                        c.SendingStart(port, ip);
                    }
                }
            }

            else
            {
                c.GetLogHandler().AddMessage("IP does not match IP layout." + Environment.NewLine +
                                             " Please enter only numbers matching this format: ###.###.###.###");
            }
        }

        private bool CheckIP(string input)
        {
            if (Regex.IsMatch(input, @"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b"))
            {
                return true;
            }
            return false;
        }


        private void stopButton_Click(object sender, EventArgs e)
        {
            stopButton.Enabled = false;
            startButton.Enabled = true;
            recButton.Enabled = true;
            playButton.Enabled = true;
            folderButton.Enabled = true;
            fileCBox.Enabled = true;
            randomrunning = false;
            c.SendingStop();
        }

        private void toText_TextChanged(object sender, EventArgs e)
        {
        }

        private void fromText_TextChanged(object sender, EventArgs e)
        {
        }

        private void toLabel_Click(object sender, EventArgs e)
        {
        }

        private void fromLabel_Click(object sender, EventArgs e)
        {
        }

        private void generationText_Click(object sender, EventArgs e)
        {
        }

        private void generationLabel_Click(object sender, EventArgs e)
        {
        }

        private void flystickLabel_Click(object sender, EventArgs e)
        {
        }

        private void flystickCount_SelectedIndexChanged(object sender, EventArgs e)
        {
            c.GetStringGenerator().SetFlystickAmount(Convert.ToInt32(flystickCount.Text));
        }

        private void sixdobjLabel_Click(object sender, EventArgs e)
        {
        }

        private void sixdCount_SelectedIndexChanged(object sender, EventArgs e)
        {
            c.GetStringGenerator().Set6dAmount(Convert.ToInt32(sixdCount.Text));
        }

        private void checkThisPC_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = !checkThisPC.Checked;
        }

        private void PortLabel_Click(object sender, EventArgs e)
        {
            jamEnabler++;
            if (jamEnabler > 4)
            {
                jamCheck.Visible = true;
            }
        }

        private void IP_Click(object sender, EventArgs e)
        {
        }

        private void colon_Click(object sender, EventArgs e)
        {
        }

        private void Port_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void recplayCheckThisPC_checkedChanged(object sender, EventArgs e)
        {
            recPlayIpTextBox.Enabled = !recplayCheckThisPC.Checked;
        }

        private void recButton_Click(object sender, EventArgs e)
        {
            if (folderPath != "")
            {
                if (CheckIP(recPlayIpTextBox.Text) || recplayCheckThisPC.Checked)
                {
                    int port;
                    if (!int.TryParse(portRecPlayTextBox.Text, out port))
                    {
                        c.GetLogHandler().AddMessage("Port is probably not a number. Please enter a valid number.");
                        return;
                    }
                    playButton.Enabled = false;
                    recPlayStopButton.Enabled = true;
                    recButton.Enabled = false;
                    stopButton.Enabled = false;
                    startButton.Enabled = false;
                    fileCBox.Enabled = false;
                    folderButton.Enabled = false;
                    playing = false;

                    if (recplayCheckThisPC.Checked)
                    {
                        c.RecordingStart(port, folderPath);
                    }
                    else
                    {
                        string ip = recPlayIpTextBox.Text;
                        c.RecordingStart(port, folderPath, ip);
                    }
                    recording = true;
                }
                else
                {
                    c.GetLogHandler().AddMessage("IP does not match IP layout." + Environment.NewLine +
                                                 " Please enter only numbers matching this format: ###.###.###.###");
                }
            }
            else
            {
                c.GetLogHandler().AddMessage("In order to record you have to set a destination folder.");
            }
        }

        private void recPlayStopButton_Click(object sender, EventArgs e)
        {
            recPlayStopButton.Enabled = false;
            recButton.Enabled = true;
            playButton.Enabled = true;
            startButton.Enabled = true;
            fileCBox.Enabled = true;
            folderButton.Enabled = true;
            if (recording)
            {
                c.RecordingStop();
                recording = false;
            }
            if (playing)
            {
                c.PlayingStop();
                playing = false;
            }
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            if (folderPath != "")
            {
                if (CheckIP(recPlayIpTextBox.Text) || recplayCheckThisPC.Checked)
                {
                    int port;
                    if (!int.TryParse(portRecPlayTextBox.Text, out port))
                    {
                        c.GetLogHandler().AddMessage("Port is probably not a number. Please enter a valid number.");
                        return;
                    }
                    if (fileCBox.SelectedItem is LogFile)
                    {
                        if (c.GetStringGenerator().CheckFile(((LogFile) fileCBox.SelectedItem).Path))
                        {
                            playButton.Enabled = false;
                            recPlayStopButton.Enabled = true;
                            recButton.Enabled = false;
                            recording = false;
                            stopButton.Enabled = false;
                            startButton.Enabled = false;
                            fileCBox.Enabled = false;
                            folderButton.Enabled = false;
                            playing = true;

                            if (recplayCheckThisPC.Checked)
                            {
                                c.PlayingStart(port, ((LogFile) fileCBox.SelectedItem).Path);
                            }
                            else
                            {
                                string ip = recPlayIpTextBox.Text;
                                c.PlayingStart(port, ((LogFile) fileCBox.SelectedItem).Path, ip);
                            }
                        }
                        else
                        {
                            c.GetLogHandler()
                                .AddMessage("Invalid file, probably empty. Please choose a different file.");
                        }
                        playing = true;
                    }
                    else
                    {
                        c.GetLogHandler().AddMessage("No valid files in this folder.");
                    }
                }
                else
                {
                    c.GetLogHandler().AddMessage("IP does not match IP layout." + Environment.NewLine +
                                                 " Please enter only numbers matching this format: ###.###.###.###");
                }
            }
            else
            {
                c.GetLogHandler().AddMessage("In order to play data you have to choose a source folder.");
            }
            //string[] splitedmes = c.GetStringGenerator().ReadFile(((LogFile) fileCBox.SelectedItem).Path);
            //splitedmes = c.GetStringGenerator().CleanUpStrings(splitedmes);
            //foreach (var message in splitedmes)
            //{
            //    Console.WriteLine(@message);
            //}
        }

        private void folderButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                fileCBox.Items.Clear();
                folderPath = folderBrowserDialog1.SelectedPath;
                string folderName = DeletePath(folderPath);
                folderButton.Text = folderName;
                String[] files = Directory.GetFiles(@folderPath, "*.log");
                if (files.Length != 0)
                {
                    AutoCompleteStringCollection fileNames = new AutoCompleteStringCollection();
                    foreach (var file in files)
                    {
                        LogFile lf = new LogFile(DeletePath(file), file);
                        fileNames.Add(DeletePath(file));
                        fileCBox.Items.Add(lf);
                    }
                    fileCBox.AutoCompleteCustomSource = fileNames;
                }
                else
                {
                    fileCBox.Items.Add("No .log files");
                }
                fileCBox.SelectedItem = fileCBox.Items[0];
            }
        }

        private string DeletePath(string path)
        {
            return path.Substring(path.LastIndexOf('\\', path.Length - 1) + 1);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void emulationCheck_CheckedChanged(object sender, EventArgs e)
        {
            emulation = emulationCheck.Checked;
            if (emulationCheck.Checked)
            {
                hook.RegisterHotKey(cheapHooker.ModifierKeys.None, Keys.F);
                hook.RegisterHotKey(cheapHooker.ModifierKeys.None, Keys.D);
                hook.RegisterHotKey(cheapHooker.ModifierKeys.None, Keys.S);
                hook.RegisterHotKey(cheapHooker.ModifierKeys.None, Keys.A);
                hook.RegisterHotKey(cheapHooker.ModifierKeys.None, Keys.Up);
                hook.RegisterHotKey(cheapHooker.ModifierKeys.None, Keys.Down);
                hook.RegisterHotKey(cheapHooker.ModifierKeys.None, Keys.Left);
                hook.RegisterHotKey(cheapHooker.ModifierKeys.None, Keys.Right);
            }
            if (!emulationCheck.Checked)
            {
                hook.Dispose();
            }
        }
    }
}