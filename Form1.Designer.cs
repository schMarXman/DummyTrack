using System.Security.AccessControl;

namespace DummyTrack
{
    partial class DummyTrack
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabs = new System.Windows.Forms.TabControl();
            this.randomize = new System.Windows.Forms.TabPage();
            this.jamCheck = new System.Windows.Forms.CheckBox();
            this.checkLog = new System.Windows.Forms.CheckBox();
            this.stopButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.toText = new System.Windows.Forms.TextBox();
            this.fromText = new System.Windows.Forms.TextBox();
            this.toLabel = new System.Windows.Forms.Label();
            this.fromLabel = new System.Windows.Forms.Label();
            this.generationText = new System.Windows.Forms.Label();
            this.generationLabel = new System.Windows.Forms.Label();
            this.flystickLabel = new System.Windows.Forms.Label();
            this.flystickCount = new System.Windows.Forms.ComboBox();
            this.sixdobjLabel = new System.Windows.Forms.Label();
            this.sixdCount = new System.Windows.Forms.ComboBox();
            this.checkThisPC = new System.Windows.Forms.CheckBox();
            this.PortLabel = new System.Windows.Forms.Label();
            this.IP = new System.Windows.Forms.Label();
            this.colon = new System.Windows.Forms.Label();
            this.Port = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.recplay = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.speedBox = new System.Windows.Forms.TextBox();
            this.speedBar = new System.Windows.Forms.TrackBar();
            this.playButton = new System.Windows.Forms.Button();
            this.recPlayStopButton = new System.Windows.Forms.Button();
            this.recButton = new System.Windows.Forms.Button();
            this.sourceFLabel = new System.Windows.Forms.Label();
            this.recplayCheckThisPC = new System.Windows.Forms.CheckBox();
            this.ipRecPlayLabel = new System.Windows.Forms.Label();
            this.portRecPlayLabel = new System.Windows.Forms.Label();
            this.colonRecPlayLabel = new System.Windows.Forms.Label();
            this.portRecPlayTextBox = new System.Windows.Forms.TextBox();
            this.recPlayIpTextBox = new System.Windows.Forms.TextBox();
            this.fromToLabel = new System.Windows.Forms.Label();
            this.fileLabel = new System.Windows.Forms.Label();
            this.fileCBox = new System.Windows.Forms.ComboBox();
            this.recLabel = new System.Windows.Forms.Label();
            this.folderButton = new System.Windows.Forms.Button();
            this.log = new System.Windows.Forms.TabPage();
            this.logBox = new System.Windows.Forms.TextBox();
            this.fEmulation = new System.Windows.Forms.TabPage();
            this.emulationCheck = new System.Windows.Forms.CheckBox();
            this.emulationDescLabel = new System.Windows.Forms.Label();
            this.emulationDescLabel2 = new System.Windows.Forms.Label();
            this.tabs.SuspendLayout();
            this.randomize.SuspendLayout();
            this.recplay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speedBar)).BeginInit();
            this.log.SuspendLayout();
            this.fEmulation.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.randomize);
            this.tabs.Controls.Add(this.recplay);
            this.tabs.Controls.Add(this.fEmulation);
            this.tabs.Controls.Add(this.log);
            this.tabs.Location = new System.Drawing.Point(0, 0);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(294, 268);
            this.tabs.TabIndex = 0;
            // 
            // randomize
            // 
            this.randomize.Controls.Add(this.jamCheck);
            this.randomize.Controls.Add(this.checkLog);
            this.randomize.Controls.Add(this.stopButton);
            this.randomize.Controls.Add(this.startButton);
            this.randomize.Controls.Add(this.toText);
            this.randomize.Controls.Add(this.fromText);
            this.randomize.Controls.Add(this.toLabel);
            this.randomize.Controls.Add(this.fromLabel);
            this.randomize.Controls.Add(this.generationText);
            this.randomize.Controls.Add(this.generationLabel);
            this.randomize.Controls.Add(this.flystickLabel);
            this.randomize.Controls.Add(this.flystickCount);
            this.randomize.Controls.Add(this.sixdobjLabel);
            this.randomize.Controls.Add(this.sixdCount);
            this.randomize.Controls.Add(this.checkThisPC);
            this.randomize.Controls.Add(this.PortLabel);
            this.randomize.Controls.Add(this.IP);
            this.randomize.Controls.Add(this.colon);
            this.randomize.Controls.Add(this.Port);
            this.randomize.Controls.Add(this.textBox1);
            this.randomize.Location = new System.Drawing.Point(4, 22);
            this.randomize.Name = "randomize";
            this.randomize.Padding = new System.Windows.Forms.Padding(3);
            this.randomize.Size = new System.Drawing.Size(286, 242);
            this.randomize.TabIndex = 0;
            this.randomize.Text = "Randomize";
            this.randomize.UseVisualStyleBackColor = true;
            // 
            // jamCheck
            // 
            this.jamCheck.AutoSize = true;
            this.jamCheck.Location = new System.Drawing.Point(196, 219);
            this.jamCheck.Name = "jamCheck";
            this.jamCheck.Size = new System.Drawing.Size(86, 17);
            this.jamCheck.TabIndex = 35;
            this.jamCheck.Text = "Jam network";
            this.jamCheck.UseVisualStyleBackColor = true;
            this.jamCheck.Visible = false;
            // 
            // checkLog
            // 
            this.checkLog.AutoSize = true;
            this.checkLog.Location = new System.Drawing.Point(32, 219);
            this.checkLog.Name = "checkLog";
            this.checkLog.Size = new System.Drawing.Size(160, 17);
            this.checkLog.TabIndex = 34;
            this.checkLog.Text = "Switch to log screen on start";
            this.checkLog.UseVisualStyleBackColor = true;
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(152, 188);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 23);
            this.stopButton.TabIndex = 33;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(55, 188);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 32;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // toText
            // 
            this.toText.Location = new System.Drawing.Point(165, 156);
            this.toText.Name = "toText";
            this.toText.Size = new System.Drawing.Size(62, 20);
            this.toText.TabIndex = 31;
            this.toText.TextChanged += new System.EventHandler(this.toText_TextChanged);
            // 
            // fromText
            // 
            this.fromText.Location = new System.Drawing.Point(68, 156);
            this.fromText.Name = "fromText";
            this.fromText.Size = new System.Drawing.Size(62, 20);
            this.fromText.TabIndex = 30;
            this.fromText.TextChanged += new System.EventHandler(this.fromText_TextChanged);
            // 
            // toLabel
            // 
            this.toLabel.AutoSize = true;
            this.toLabel.Location = new System.Drawing.Point(136, 159);
            this.toLabel.Name = "toLabel";
            this.toLabel.Size = new System.Drawing.Size(23, 13);
            this.toLabel.TabIndex = 29;
            this.toLabel.Text = "To:";
            this.toLabel.Click += new System.EventHandler(this.toLabel_Click);
            // 
            // fromLabel
            // 
            this.fromLabel.AutoSize = true;
            this.fromLabel.Location = new System.Drawing.Point(29, 159);
            this.fromLabel.Name = "fromLabel";
            this.fromLabel.Size = new System.Drawing.Size(33, 13);
            this.fromLabel.TabIndex = 28;
            this.fromLabel.Text = "From:";
            this.fromLabel.Click += new System.EventHandler(this.fromLabel_Click);
            // 
            // generationText
            // 
            this.generationText.AutoSize = true;
            this.generationText.Location = new System.Drawing.Point(29, 138);
            this.generationText.Name = "generationText";
            this.generationText.Size = new System.Drawing.Size(153, 13);
            this.generationText.TabIndex = 27;
            this.generationText.Text = "Generate random matrix values";
            this.generationText.Click += new System.EventHandler(this.generationText_Click);
            // 
            // generationLabel
            // 
            this.generationLabel.AutoSize = true;
            this.generationLabel.Location = new System.Drawing.Point(29, 121);
            this.generationLabel.Name = "generationLabel";
            this.generationLabel.Size = new System.Drawing.Size(59, 13);
            this.generationLabel.TabIndex = 26;
            this.generationLabel.Text = "Generation";
            this.generationLabel.Click += new System.EventHandler(this.generationLabel_Click);
            // 
            // flystickLabel
            // 
            this.flystickLabel.AutoSize = true;
            this.flystickLabel.Location = new System.Drawing.Point(166, 94);
            this.flystickLabel.Name = "flystickLabel";
            this.flystickLabel.Size = new System.Drawing.Size(50, 13);
            this.flystickLabel.TabIndex = 25;
            this.flystickLabel.Text = "Flysticks:";
            this.flystickLabel.Click += new System.EventHandler(this.flystickLabel_Click);
            // 
            // flystickCount
            // 
            this.flystickCount.DisplayMember = "1";
            this.flystickCount.FormattingEnabled = true;
            this.flystickCount.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.flystickCount.Location = new System.Drawing.Point(219, 91);
            this.flystickCount.MaxLength = 1;
            this.flystickCount.Name = "flystickCount";
            this.flystickCount.Size = new System.Drawing.Size(38, 21);
            this.flystickCount.TabIndex = 24;
            this.flystickCount.Text = "1";
            this.flystickCount.SelectedIndexChanged += new System.EventHandler(this.flystickCount_SelectedIndexChanged);
            // 
            // sixdobjLabel
            // 
            this.sixdobjLabel.AutoSize = true;
            this.sixdobjLabel.Location = new System.Drawing.Point(29, 94);
            this.sixdobjLabel.Name = "sixdobjLabel";
            this.sixdobjLabel.Size = new System.Drawing.Size(61, 13);
            this.sixdobjLabel.TabIndex = 23;
            this.sixdobjLabel.Text = "6d-Objects:";
            this.sixdobjLabel.Click += new System.EventHandler(this.sixdobjLabel_Click);
            // 
            // sixdCount
            // 
            this.sixdCount.DisplayMember = "1";
            this.sixdCount.FormattingEnabled = true;
            this.sixdCount.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.sixdCount.Location = new System.Drawing.Point(93, 91);
            this.sixdCount.MaxLength = 1;
            this.sixdCount.Name = "sixdCount";
            this.sixdCount.Size = new System.Drawing.Size(38, 21);
            this.sixdCount.TabIndex = 22;
            this.sixdCount.Text = "2";
            this.sixdCount.SelectedIndexChanged += new System.EventHandler(this.sixdCount_SelectedIndexChanged);
            // 
            // checkThisPC
            // 
            this.checkThisPC.AutoSize = true;
            this.checkThisPC.Location = new System.Drawing.Point(32, 52);
            this.checkThisPC.Name = "checkThisPC";
            this.checkThisPC.Size = new System.Drawing.Size(149, 17);
            this.checkThisPC.TabIndex = 21;
            this.checkThisPC.Text = "Send packages to this PC";
            this.checkThisPC.UseVisualStyleBackColor = true;
            this.checkThisPC.CheckedChanged += new System.EventHandler(this.checkThisPC_CheckedChanged);
            // 
            // PortLabel
            // 
            this.PortLabel.AutoSize = true;
            this.PortLabel.Location = new System.Drawing.Point(224, 9);
            this.PortLabel.Name = "PortLabel";
            this.PortLabel.Size = new System.Drawing.Size(26, 13);
            this.PortLabel.TabIndex = 20;
            this.PortLabel.Text = "Port";
            this.PortLabel.Click += new System.EventHandler(this.PortLabel_Click);
            // 
            // IP
            // 
            this.IP.AutoSize = true;
            this.IP.Location = new System.Drawing.Point(93, 9);
            this.IP.Name = "IP";
            this.IP.Size = new System.Drawing.Size(52, 13);
            this.IP.TabIndex = 19;
            this.IP.Text = "IP-Adress";
            this.IP.Click += new System.EventHandler(this.IP_Click);
            // 
            // colon
            // 
            this.colon.AutoSize = true;
            this.colon.Location = new System.Drawing.Point(206, 29);
            this.colon.Name = "colon";
            this.colon.Size = new System.Drawing.Size(10, 13);
            this.colon.TabIndex = 18;
            this.colon.Text = ":";
            this.colon.Click += new System.EventHandler(this.colon_Click);
            // 
            // Port
            // 
            this.Port.Location = new System.Drawing.Point(218, 26);
            this.Port.MaxLength = 4;
            this.Port.Name = "Port";
            this.Port.Size = new System.Drawing.Size(37, 20);
            this.Port.TabIndex = 17;
            this.Port.Text = "5001";
            this.Port.TextChanged += new System.EventHandler(this.Port_TextChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(32, 26);
            this.textBox1.MaxLength = 15;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(171, 20);
            this.textBox1.TabIndex = 16;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // recplay
            // 
            this.recplay.Controls.Add(this.label1);
            this.recplay.Controls.Add(this.speedBox);
            this.recplay.Controls.Add(this.speedBar);
            this.recplay.Controls.Add(this.playButton);
            this.recplay.Controls.Add(this.recPlayStopButton);
            this.recplay.Controls.Add(this.recButton);
            this.recplay.Controls.Add(this.sourceFLabel);
            this.recplay.Controls.Add(this.recplayCheckThisPC);
            this.recplay.Controls.Add(this.ipRecPlayLabel);
            this.recplay.Controls.Add(this.portRecPlayLabel);
            this.recplay.Controls.Add(this.colonRecPlayLabel);
            this.recplay.Controls.Add(this.portRecPlayTextBox);
            this.recplay.Controls.Add(this.recPlayIpTextBox);
            this.recplay.Controls.Add(this.fromToLabel);
            this.recplay.Controls.Add(this.fileLabel);
            this.recplay.Controls.Add(this.fileCBox);
            this.recplay.Controls.Add(this.recLabel);
            this.recplay.Controls.Add(this.folderButton);
            this.recplay.Location = new System.Drawing.Point(4, 22);
            this.recplay.Name = "recplay";
            this.recplay.Size = new System.Drawing.Size(286, 242);
            this.recplay.TabIndex = 2;
            this.recplay.Text = "Rec/Play";
            this.recplay.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(126, 152);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 39;
            this.label1.Text = "Play speed (in ms)";
            // 
            // speedBox
            // 
            this.speedBox.Location = new System.Drawing.Point(177, 215);
            this.speedBox.MaxLength = 3;
            this.speedBox.Name = "speedBox";
            this.speedBox.Size = new System.Drawing.Size(50, 20);
            this.speedBox.TabIndex = 38;
            this.speedBox.Text = "25";
            this.speedBox.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // speedBar
            // 
            this.speedBar.Location = new System.Drawing.Point(129, 167);
            this.speedBar.Maximum = 500;
            this.speedBar.Name = "speedBar";
            this.speedBar.Size = new System.Drawing.Size(150, 45);
            this.speedBar.TabIndex = 37;
            // 
            // playButton
            // 
            this.playButton.Location = new System.Drawing.Point(45, 126);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(75, 23);
            this.playButton.TabIndex = 36;
            this.playButton.Text = "Play";
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // recPlayStopButton
            // 
            this.recPlayStopButton.Location = new System.Drawing.Point(23, 155);
            this.recPlayStopButton.Name = "recPlayStopButton";
            this.recPlayStopButton.Size = new System.Drawing.Size(97, 80);
            this.recPlayStopButton.TabIndex = 28;
            this.recPlayStopButton.Text = "Stop";
            this.recPlayStopButton.UseVisualStyleBackColor = true;
            this.recPlayStopButton.Click += new System.EventHandler(this.recPlayStopButton_Click);
            // 
            // recButton
            // 
            this.recButton.Location = new System.Drawing.Point(45, 97);
            this.recButton.Name = "recButton";
            this.recButton.Size = new System.Drawing.Size(75, 23);
            this.recButton.TabIndex = 27;
            this.recButton.Text = "Record";
            this.recButton.UseVisualStyleBackColor = true;
            this.recButton.Click += new System.EventHandler(this.recButton_Click);
            // 
            // sourceFLabel
            // 
            this.sourceFLabel.AutoSize = true;
            this.sourceFLabel.Location = new System.Drawing.Point(196, 33);
            this.sourceFLabel.Name = "sourceFLabel";
            this.sourceFLabel.Size = new System.Drawing.Size(95, 13);
            this.sourceFLabel.TabIndex = 26;
            this.sourceFLabel.Text = "Source/Save path";
            // 
            // recplayCheckThisPC
            // 
            this.recplayCheckThisPC.AutoSize = true;
            this.recplayCheckThisPC.Location = new System.Drawing.Point(46, 74);
            this.recplayCheckThisPC.Name = "recplayCheckThisPC";
            this.recplayCheckThisPC.Size = new System.Drawing.Size(59, 17);
            this.recplayCheckThisPC.TabIndex = 25;
            this.recplayCheckThisPC.Text = "this PC";
            this.recplayCheckThisPC.UseVisualStyleBackColor = true;
            this.recplayCheckThisPC.CheckedChanged += new System.EventHandler(this.recplayCheckThisPC_checkedChanged);
            // 
            // ipRecPlayLabel
            // 
            this.ipRecPlayLabel.AutoSize = true;
            this.ipRecPlayLabel.Location = new System.Drawing.Point(68, 33);
            this.ipRecPlayLabel.Name = "ipRecPlayLabel";
            this.ipRecPlayLabel.Size = new System.Drawing.Size(52, 13);
            this.ipRecPlayLabel.TabIndex = 24;
            this.ipRecPlayLabel.Text = "IP-Adress";
            // 
            // portRecPlayLabel
            // 
            this.portRecPlayLabel.AutoSize = true;
            this.portRecPlayLabel.Location = new System.Drawing.Point(165, 33);
            this.portRecPlayLabel.Name = "portRecPlayLabel";
            this.portRecPlayLabel.Size = new System.Drawing.Size(26, 13);
            this.portRecPlayLabel.TabIndex = 23;
            this.portRecPlayLabel.Text = "Port";
            // 
            // colonRecPlayLabel
            // 
            this.colonRecPlayLabel.AutoSize = true;
            this.colonRecPlayLabel.Location = new System.Drawing.Point(148, 52);
            this.colonRecPlayLabel.Name = "colonRecPlayLabel";
            this.colonRecPlayLabel.Size = new System.Drawing.Size(10, 13);
            this.colonRecPlayLabel.TabIndex = 22;
            this.colonRecPlayLabel.Text = ":";
            // 
            // portRecPlayTextBox
            // 
            this.portRecPlayTextBox.Location = new System.Drawing.Point(160, 48);
            this.portRecPlayTextBox.MaxLength = 4;
            this.portRecPlayTextBox.Name = "portRecPlayTextBox";
            this.portRecPlayTextBox.Size = new System.Drawing.Size(37, 20);
            this.portRecPlayTextBox.TabIndex = 21;
            this.portRecPlayTextBox.Text = "5001";
            // 
            // recPlayIpTextBox
            // 
            this.recPlayIpTextBox.Location = new System.Drawing.Point(46, 48);
            this.recPlayIpTextBox.MaxLength = 15;
            this.recPlayIpTextBox.Name = "recPlayIpTextBox";
            this.recPlayIpTextBox.Size = new System.Drawing.Size(100, 20);
            this.recPlayIpTextBox.TabIndex = 6;
            // 
            // fromToLabel
            // 
            this.fromToLabel.AutoSize = true;
            this.fromToLabel.Location = new System.Drawing.Point(3, 52);
            this.fromToLabel.Name = "fromToLabel";
            this.fromToLabel.Size = new System.Drawing.Size(44, 13);
            this.fromToLabel.TabIndex = 5;
            this.fromToLabel.Text = "from/to:";
            // 
            // fileLabel
            // 
            this.fileLabel.AutoSize = true;
            this.fileLabel.Location = new System.Drawing.Point(126, 107);
            this.fileLabel.Name = "fileLabel";
            this.fileLabel.Size = new System.Drawing.Size(26, 13);
            this.fileLabel.TabIndex = 4;
            this.fileLabel.Text = "File:";
            // 
            // fileCBox
            // 
            this.fileCBox.FormattingEnabled = true;
            this.fileCBox.Location = new System.Drawing.Point(126, 128);
            this.fileCBox.Name = "fileCBox";
            this.fileCBox.Size = new System.Drawing.Size(155, 21);
            this.fileCBox.TabIndex = 3;
            // 
            // recLabel
            // 
            this.recLabel.AutoSize = true;
            this.recLabel.Location = new System.Drawing.Point(23, 13);
            this.recLabel.Name = "recLabel";
            this.recLabel.Size = new System.Drawing.Size(67, 13);
            this.recLabel.TabIndex = 1;
            this.recLabel.Text = "Record/Play";
            // 
            // folderButton
            // 
            this.folderButton.Location = new System.Drawing.Point(199, 46);
            this.folderButton.Name = "folderButton";
            this.folderButton.Size = new System.Drawing.Size(84, 23);
            this.folderButton.TabIndex = 0;
            this.folderButton.Text = "choose folder";
            this.folderButton.UseVisualStyleBackColor = true;
            this.folderButton.Click += new System.EventHandler(this.folderButton_Click);
            // 
            // log
            // 
            this.log.Controls.Add(this.logBox);
            this.log.Location = new System.Drawing.Point(4, 22);
            this.log.Name = "log";
            this.log.Padding = new System.Windows.Forms.Padding(3);
            this.log.Size = new System.Drawing.Size(286, 242);
            this.log.TabIndex = 1;
            this.log.Text = "Log";
            this.log.UseVisualStyleBackColor = true;
            // 
            // logBox
            // 
            this.logBox.Location = new System.Drawing.Point(0, 0);
            this.logBox.Multiline = true;
            this.logBox.Name = "logBox";
            this.logBox.ReadOnly = true;
            this.logBox.Size = new System.Drawing.Size(286, 246);
            this.logBox.TabIndex = 1;
            // 
            // fEmulation
            // 
            this.fEmulation.Controls.Add(this.emulationDescLabel2);
            this.fEmulation.Controls.Add(this.emulationDescLabel);
            this.fEmulation.Controls.Add(this.emulationCheck);
            this.fEmulation.Location = new System.Drawing.Point(4, 22);
            this.fEmulation.Name = "fEmulation";
            this.fEmulation.Size = new System.Drawing.Size(286, 242);
            this.fEmulation.TabIndex = 3;
            this.fEmulation.Text = "Flystick-Emulation";
            this.fEmulation.UseVisualStyleBackColor = true;
            // 
            // emulationCheck
            // 
            this.emulationCheck.AutoSize = true;
            this.emulationCheck.Location = new System.Drawing.Point(27, 80);
            this.emulationCheck.Name = "emulationCheck";
            this.emulationCheck.Size = new System.Drawing.Size(145, 17);
            this.emulationCheck.TabIndex = 3;
            this.emulationCheck.Text = "Enable Flystick emulation";
            this.emulationCheck.UseVisualStyleBackColor = true;
            this.emulationCheck.CheckedChanged += new System.EventHandler(this.emulationCheck_CheckedChanged);
            // 
            // emulationDescLabel
            // 
            this.emulationDescLabel.Location = new System.Drawing.Point(24, 33);
            this.emulationDescLabel.Name = "emulationDescLabel";
            this.emulationDescLabel.Size = new System.Drawing.Size(240, 44);
            this.emulationDescLabel.TabIndex = 4;
            this.emulationDescLabel.Text = "By checking the check box you will enable flystick emulation. With this you can e" +
    "mulate flystick button presses with your keyboad.";
            // 
            // emulationDescLabel2
            // 
            this.emulationDescLabel2.Location = new System.Drawing.Point(24, 103);
            this.emulationDescLabel2.Name = "emulationDescLabel2";
            this.emulationDescLabel2.Size = new System.Drawing.Size(240, 66);
            this.emulationDescLabel2.TabIndex = 5;
            this.emulationDescLabel2.Text = "The button mappings are:  F = Trigger; D = Right Button;  S = Middle Button; A = " +
    "Left Button; The arrow buttons will add or subtract 0.1 to the value of the resp" +
    "ective direction of the stick.";
            // 
            // DummyTrack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 269);
            this.Controls.Add(this.tabs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "DummyTrack";
            this.Text = "DummyTrack";
            this.tabs.ResumeLayout(false);
            this.randomize.ResumeLayout(false);
            this.randomize.PerformLayout();
            this.recplay.ResumeLayout(false);
            this.recplay.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speedBar)).EndInit();
            this.log.ResumeLayout(false);
            this.log.PerformLayout();
            this.fEmulation.ResumeLayout(false);
            this.fEmulation.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage randomize;
        private System.Windows.Forms.TextBox toText;
        private System.Windows.Forms.TextBox fromText;
        private System.Windows.Forms.Label toLabel;
        private System.Windows.Forms.Label fromLabel;
        private System.Windows.Forms.Label generationText;
        private System.Windows.Forms.Label generationLabel;
        private System.Windows.Forms.Label flystickLabel;
        private System.Windows.Forms.ComboBox flystickCount;
        private System.Windows.Forms.Label sixdobjLabel;
        private System.Windows.Forms.ComboBox sixdCount;
        private System.Windows.Forms.CheckBox checkThisPC;
        private System.Windows.Forms.Label PortLabel;
        private System.Windows.Forms.Label IP;
        private System.Windows.Forms.Label colon;
        private System.Windows.Forms.TextBox Port;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TabPage log;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.TextBox logBox;
        private System.Windows.Forms.CheckBox checkLog;
        private System.Windows.Forms.TabPage recplay;
        private System.Windows.Forms.Label fileLabel;
        private System.Windows.Forms.ComboBox fileCBox;
        private System.Windows.Forms.Label recLabel;
        private System.Windows.Forms.Button folderButton;
        private System.Windows.Forms.Label sourceFLabel;
        private System.Windows.Forms.CheckBox recplayCheckThisPC;
        private System.Windows.Forms.Label ipRecPlayLabel;
        private System.Windows.Forms.Label portRecPlayLabel;
        private System.Windows.Forms.Label colonRecPlayLabel;
        private System.Windows.Forms.TextBox portRecPlayTextBox;
        private System.Windows.Forms.TextBox recPlayIpTextBox;
        private System.Windows.Forms.Label fromToLabel;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Button recPlayStopButton;
        private System.Windows.Forms.Button recButton;
        private System.Windows.Forms.CheckBox jamCheck;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox speedBox;
        private System.Windows.Forms.TrackBar speedBar;
        private System.Windows.Forms.TabPage fEmulation;
        private System.Windows.Forms.CheckBox emulationCheck;
        private System.Windows.Forms.Label emulationDescLabel;
        private System.Windows.Forms.Label emulationDescLabel2;

    }
}

