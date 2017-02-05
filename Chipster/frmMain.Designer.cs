namespace Chipster
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadROMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.loadStateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveStateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debuggerToggleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.decompileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.soundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.speedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.khz1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.khz2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.khz3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.khz4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.khz5ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.khz6ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.khz7ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.khz8ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.khz9ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.x10ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x100ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.khzUnlimitedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkForUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtProgramCounter = new System.Windows.Forms.TextBox();
            this.txtInstruction = new System.Windows.Forms.TextBox();
            this.lblProgramCounter = new System.Windows.Forms.Label();
            this.lblInstruction = new System.Windows.Forms.Label();
            this.grpGeneralPurpose = new System.Windows.Forms.GroupBox();
            this.lblRF = new System.Windows.Forms.Label();
            this.txtRF = new System.Windows.Forms.TextBox();
            this.lblRE = new System.Windows.Forms.Label();
            this.txtRE = new System.Windows.Forms.TextBox();
            this.lblRD = new System.Windows.Forms.Label();
            this.txtRD = new System.Windows.Forms.TextBox();
            this.lblRC = new System.Windows.Forms.Label();
            this.txtRC = new System.Windows.Forms.TextBox();
            this.lblRB = new System.Windows.Forms.Label();
            this.txtRB = new System.Windows.Forms.TextBox();
            this.lblRA = new System.Windows.Forms.Label();
            this.txtRA = new System.Windows.Forms.TextBox();
            this.lblR9 = new System.Windows.Forms.Label();
            this.txtR9 = new System.Windows.Forms.TextBox();
            this.lblR8 = new System.Windows.Forms.Label();
            this.txtR8 = new System.Windows.Forms.TextBox();
            this.lblR7 = new System.Windows.Forms.Label();
            this.txtR7 = new System.Windows.Forms.TextBox();
            this.lblR6 = new System.Windows.Forms.Label();
            this.txtR6 = new System.Windows.Forms.TextBox();
            this.lblR5 = new System.Windows.Forms.Label();
            this.txtR5 = new System.Windows.Forms.TextBox();
            this.lblR4 = new System.Windows.Forms.Label();
            this.txtR4 = new System.Windows.Forms.TextBox();
            this.lblR3 = new System.Windows.Forms.Label();
            this.txtR3 = new System.Windows.Forms.TextBox();
            this.lblR2 = new System.Windows.Forms.Label();
            this.txtR2 = new System.Windows.Forms.TextBox();
            this.lblR1 = new System.Windows.Forms.Label();
            this.txtR1 = new System.Windows.Forms.TextBox();
            this.lblR0 = new System.Windows.Forms.Label();
            this.txtR0 = new System.Windows.Forms.TextBox();
            this.grpSpecialPurpose = new System.Windows.Forms.GroupBox();
            this.txtAdress = new System.Windows.Forms.TextBox();
            this.lblIndex = new System.Windows.Forms.Label();
            this.btnStep = new System.Windows.Forms.Button();
            this.chkHex = new System.Windows.Forms.CheckBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.txtSound = new System.Windows.Forms.TextBox();
            this.lblSound = new System.Windows.Forms.Label();
            this.glDisplay = new OpenTK.GLControl();
            this.txtFPS = new System.Windows.Forms.TextBox();
            this.lblFPS = new System.Windows.Forms.Label();
            this.txtIPS = new System.Windows.Forms.TextBox();
            this.lblIPS = new System.Windows.Forms.Label();
            this.btnUnstep = new System.Windows.Forms.Button();
            this.mnuMain.SuspendLayout();
            this.grpGeneralPurpose.SuspendLayout();
            this.grpSpecialPurpose.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(817, 24);
            this.mnuMain.TabIndex = 1;
            this.mnuMain.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadROMToolStripMenuItem,
            this.toolStripSeparator3,
            this.loadStateToolStripMenuItem,
            this.saveStateToolStripMenuItem,
            this.toolStripSeparator4,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadROMToolStripMenuItem
            // 
            this.loadROMToolStripMenuItem.Name = "loadROMToolStripMenuItem";
            this.loadROMToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.loadROMToolStripMenuItem.Text = "Load ROM";
            this.loadROMToolStripMenuItem.Click += new System.EventHandler(this.loadROMToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(127, 6);
            // 
            // loadStateToolStripMenuItem
            // 
            this.loadStateToolStripMenuItem.Name = "loadStateToolStripMenuItem";
            this.loadStateToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.loadStateToolStripMenuItem.Text = "Load State";
            // 
            // saveStateToolStripMenuItem
            // 
            this.saveStateToolStripMenuItem.Name = "saveStateToolStripMenuItem";
            this.saveStateToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.saveStateToolStripMenuItem.Text = "Save State";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(127, 6);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.debuggerToggleToolStripMenuItem,
            this.toolStripSeparator5,
            this.decompileToolStripMenuItem,
            this.compileToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // debuggerToggleToolStripMenuItem
            // 
            this.debuggerToggleToolStripMenuItem.Name = "debuggerToggleToolStripMenuItem";
            this.debuggerToggleToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.debuggerToggleToolStripMenuItem.Text = "Debugger (Slows speed)";
            this.debuggerToggleToolStripMenuItem.Click += new System.EventHandler(this.debuggerToggleToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(198, 6);
            // 
            // decompileToolStripMenuItem
            // 
            this.decompileToolStripMenuItem.Name = "decompileToolStripMenuItem";
            this.decompileToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.decompileToolStripMenuItem.Text = "Decompile .ch8 to .txt";
            this.decompileToolStripMenuItem.Click += new System.EventHandler(this.decompileToolStripMenuItem_Click);
            // 
            // compileToolStripMenuItem
            // 
            this.compileToolStripMenuItem.Name = "compileToolStripMenuItem";
            this.compileToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.compileToolStripMenuItem.Text = "Compile .txt to .ch8";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.soundToolStripMenuItem,
            this.colorsToolStripMenuItem,
            this.speedToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // soundToolStripMenuItem
            // 
            this.soundToolStripMenuItem.Name = "soundToolStripMenuItem";
            this.soundToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.soundToolStripMenuItem.Text = "Sound";
            // 
            // colorsToolStripMenuItem
            // 
            this.colorsToolStripMenuItem.Name = "colorsToolStripMenuItem";
            this.colorsToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.colorsToolStripMenuItem.Text = "Colors";
            // 
            // speedToolStripMenuItem
            // 
            this.speedToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.khz1ToolStripMenuItem,
            this.khz2ToolStripMenuItem,
            this.khz3ToolStripMenuItem,
            this.khz4ToolStripMenuItem,
            this.khz5ToolStripMenuItem,
            this.khz6ToolStripMenuItem,
            this.khz7ToolStripMenuItem,
            this.khz8ToolStripMenuItem,
            this.khz9ToolStripMenuItem,
            this.toolStripSeparator1,
            this.x10ToolStripMenuItem,
            this.x100ToolStripMenuItem,
            this.toolStripSeparator2,
            this.khzUnlimitedToolStripMenuItem});
            this.speedToolStripMenuItem.Name = "speedToolStripMenuItem";
            this.speedToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.speedToolStripMenuItem.Text = "Speed";
            // 
            // khz1ToolStripMenuItem
            // 
            this.khz1ToolStripMenuItem.Name = "khz1ToolStripMenuItem";
            this.khz1ToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.khz1ToolStripMenuItem.Tag = "100";
            this.khz1ToolStripMenuItem.Text = "0.1 Khz";
            this.khz1ToolStripMenuItem.Click += new System.EventHandler(this.SetClockSpeed);
            // 
            // khz2ToolStripMenuItem
            // 
            this.khz2ToolStripMenuItem.Name = "khz2ToolStripMenuItem";
            this.khz2ToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.khz2ToolStripMenuItem.Tag = "200";
            this.khz2ToolStripMenuItem.Text = "0.2 Khz";
            this.khz2ToolStripMenuItem.Click += new System.EventHandler(this.SetClockSpeed);
            // 
            // khz3ToolStripMenuItem
            // 
            this.khz3ToolStripMenuItem.Name = "khz3ToolStripMenuItem";
            this.khz3ToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.khz3ToolStripMenuItem.Tag = "300";
            this.khz3ToolStripMenuItem.Text = "0.3 Khz";
            this.khz3ToolStripMenuItem.Click += new System.EventHandler(this.SetClockSpeed);
            // 
            // khz4ToolStripMenuItem
            // 
            this.khz4ToolStripMenuItem.Name = "khz4ToolStripMenuItem";
            this.khz4ToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.khz4ToolStripMenuItem.Tag = "400";
            this.khz4ToolStripMenuItem.Text = "0.4 Khz";
            this.khz4ToolStripMenuItem.Click += new System.EventHandler(this.SetClockSpeed);
            // 
            // khz5ToolStripMenuItem
            // 
            this.khz5ToolStripMenuItem.Checked = true;
            this.khz5ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.khz5ToolStripMenuItem.Name = "khz5ToolStripMenuItem";
            this.khz5ToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.khz5ToolStripMenuItem.Tag = "500";
            this.khz5ToolStripMenuItem.Text = "0.5 Khz (Default)";
            this.khz5ToolStripMenuItem.Click += new System.EventHandler(this.SetClockSpeed);
            // 
            // khz6ToolStripMenuItem
            // 
            this.khz6ToolStripMenuItem.Name = "khz6ToolStripMenuItem";
            this.khz6ToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.khz6ToolStripMenuItem.Tag = "600";
            this.khz6ToolStripMenuItem.Text = "0.6 Khz";
            this.khz6ToolStripMenuItem.Click += new System.EventHandler(this.SetClockSpeed);
            // 
            // khz7ToolStripMenuItem
            // 
            this.khz7ToolStripMenuItem.Name = "khz7ToolStripMenuItem";
            this.khz7ToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.khz7ToolStripMenuItem.Tag = "700";
            this.khz7ToolStripMenuItem.Text = "0.7 Khz";
            this.khz7ToolStripMenuItem.Click += new System.EventHandler(this.SetClockSpeed);
            // 
            // khz8ToolStripMenuItem
            // 
            this.khz8ToolStripMenuItem.Name = "khz8ToolStripMenuItem";
            this.khz8ToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.khz8ToolStripMenuItem.Tag = "800";
            this.khz8ToolStripMenuItem.Text = "0.8 Khz";
            this.khz8ToolStripMenuItem.Click += new System.EventHandler(this.SetClockSpeed);
            // 
            // khz9ToolStripMenuItem
            // 
            this.khz9ToolStripMenuItem.Name = "khz9ToolStripMenuItem";
            this.khz9ToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.khz9ToolStripMenuItem.Tag = "900";
            this.khz9ToolStripMenuItem.Text = "0.9 Khz";
            this.khz9ToolStripMenuItem.Click += new System.EventHandler(this.SetClockSpeed);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(178, 6);
            // 
            // x10ToolStripMenuItem
            // 
            this.x10ToolStripMenuItem.Name = "x10ToolStripMenuItem";
            this.x10ToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.x10ToolStripMenuItem.Tag = "10";
            this.x10ToolStripMenuItem.Text = "x10";
            this.x10ToolStripMenuItem.Click += new System.EventHandler(this.MulClockSpeed);
            // 
            // x100ToolStripMenuItem
            // 
            this.x100ToolStripMenuItem.Name = "x100ToolStripMenuItem";
            this.x100ToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.x100ToolStripMenuItem.Tag = "100";
            this.x100ToolStripMenuItem.Text = "x100";
            this.x100ToolStripMenuItem.Click += new System.EventHandler(this.MulClockSpeed);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(178, 6);
            // 
            // khzUnlimitedToolStripMenuItem
            // 
            this.khzUnlimitedToolStripMenuItem.Name = "khzUnlimitedToolStripMenuItem";
            this.khzUnlimitedToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.khzUnlimitedToolStripMenuItem.Text = "Unlimited (Very fast)";
            this.khzUnlimitedToolStripMenuItem.Click += new System.EventHandler(this.UnlimitedClockSpeed);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.checkForUpdatesToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.helpToolStripMenuItem.Text = "About";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // checkForUpdatesToolStripMenuItem
            // 
            this.checkForUpdatesToolStripMenuItem.Name = "checkForUpdatesToolStripMenuItem";
            this.checkForUpdatesToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.checkForUpdatesToolStripMenuItem.Text = "Check for Updates";
            // 
            // txtProgramCounter
            // 
            this.txtProgramCounter.Location = new System.Drawing.Point(35, 23);
            this.txtProgramCounter.Name = "txtProgramCounter";
            this.txtProgramCounter.ReadOnly = true;
            this.txtProgramCounter.Size = new System.Drawing.Size(50, 20);
            this.txtProgramCounter.TabIndex = 2;
            // 
            // txtInstruction
            // 
            this.txtInstruction.Location = new System.Drawing.Point(158, 23);
            this.txtInstruction.Name = "txtInstruction";
            this.txtInstruction.ReadOnly = true;
            this.txtInstruction.Size = new System.Drawing.Size(80, 20);
            this.txtInstruction.TabIndex = 3;
            // 
            // lblProgramCounter
            // 
            this.lblProgramCounter.AutoSize = true;
            this.lblProgramCounter.Location = new System.Drawing.Point(8, 26);
            this.lblProgramCounter.Name = "lblProgramCounter";
            this.lblProgramCounter.Size = new System.Drawing.Size(21, 13);
            this.lblProgramCounter.TabIndex = 4;
            this.lblProgramCounter.Text = "PC";
            // 
            // lblInstruction
            // 
            this.lblInstruction.AutoSize = true;
            this.lblInstruction.Location = new System.Drawing.Point(96, 26);
            this.lblInstruction.Name = "lblInstruction";
            this.lblInstruction.Size = new System.Drawing.Size(56, 13);
            this.lblInstruction.TabIndex = 5;
            this.lblInstruction.Text = "Instruction";
            // 
            // grpGeneralPurpose
            // 
            this.grpGeneralPurpose.Controls.Add(this.lblRF);
            this.grpGeneralPurpose.Controls.Add(this.txtRF);
            this.grpGeneralPurpose.Controls.Add(this.lblRE);
            this.grpGeneralPurpose.Controls.Add(this.txtRE);
            this.grpGeneralPurpose.Controls.Add(this.lblRD);
            this.grpGeneralPurpose.Controls.Add(this.txtRD);
            this.grpGeneralPurpose.Controls.Add(this.lblRC);
            this.grpGeneralPurpose.Controls.Add(this.txtRC);
            this.grpGeneralPurpose.Controls.Add(this.lblRB);
            this.grpGeneralPurpose.Controls.Add(this.txtRB);
            this.grpGeneralPurpose.Controls.Add(this.lblRA);
            this.grpGeneralPurpose.Controls.Add(this.txtRA);
            this.grpGeneralPurpose.Controls.Add(this.lblR9);
            this.grpGeneralPurpose.Controls.Add(this.txtR9);
            this.grpGeneralPurpose.Controls.Add(this.lblR8);
            this.grpGeneralPurpose.Controls.Add(this.txtR8);
            this.grpGeneralPurpose.Controls.Add(this.lblR7);
            this.grpGeneralPurpose.Controls.Add(this.txtR7);
            this.grpGeneralPurpose.Controls.Add(this.lblR6);
            this.grpGeneralPurpose.Controls.Add(this.txtR6);
            this.grpGeneralPurpose.Controls.Add(this.lblR5);
            this.grpGeneralPurpose.Controls.Add(this.txtR5);
            this.grpGeneralPurpose.Controls.Add(this.lblR4);
            this.grpGeneralPurpose.Controls.Add(this.txtR4);
            this.grpGeneralPurpose.Controls.Add(this.lblR3);
            this.grpGeneralPurpose.Controls.Add(this.txtR3);
            this.grpGeneralPurpose.Controls.Add(this.lblR2);
            this.grpGeneralPurpose.Controls.Add(this.txtR2);
            this.grpGeneralPurpose.Controls.Add(this.lblR1);
            this.grpGeneralPurpose.Controls.Add(this.txtR1);
            this.grpGeneralPurpose.Controls.Add(this.lblR0);
            this.grpGeneralPurpose.Controls.Add(this.txtR0);
            this.grpGeneralPurpose.Location = new System.Drawing.Point(452, 99);
            this.grpGeneralPurpose.Name = "grpGeneralPurpose";
            this.grpGeneralPurpose.Size = new System.Drawing.Size(359, 128);
            this.grpGeneralPurpose.TabIndex = 6;
            this.grpGeneralPurpose.TabStop = false;
            this.grpGeneralPurpose.Text = "General Purpose Registers";
            // 
            // lblRF
            // 
            this.lblRF.AutoSize = true;
            this.lblRF.Location = new System.Drawing.Point(268, 100);
            this.lblRF.Name = "lblRF";
            this.lblRF.Size = new System.Drawing.Size(21, 13);
            this.lblRF.TabIndex = 46;
            this.lblRF.Text = "RF";
            // 
            // txtRF
            // 
            this.txtRF.Location = new System.Drawing.Point(295, 97);
            this.txtRF.Name = "txtRF";
            this.txtRF.ReadOnly = true;
            this.txtRF.Size = new System.Drawing.Size(50, 20);
            this.txtRF.TabIndex = 45;
            // 
            // lblRE
            // 
            this.lblRE.AutoSize = true;
            this.lblRE.Location = new System.Drawing.Point(268, 74);
            this.lblRE.Name = "lblRE";
            this.lblRE.Size = new System.Drawing.Size(22, 13);
            this.lblRE.TabIndex = 44;
            this.lblRE.Text = "RE";
            // 
            // txtRE
            // 
            this.txtRE.Location = new System.Drawing.Point(295, 71);
            this.txtRE.Name = "txtRE";
            this.txtRE.ReadOnly = true;
            this.txtRE.Size = new System.Drawing.Size(50, 20);
            this.txtRE.TabIndex = 43;
            // 
            // lblRD
            // 
            this.lblRD.AutoSize = true;
            this.lblRD.Location = new System.Drawing.Point(268, 48);
            this.lblRD.Name = "lblRD";
            this.lblRD.Size = new System.Drawing.Size(23, 13);
            this.lblRD.TabIndex = 42;
            this.lblRD.Text = "RD";
            // 
            // txtRD
            // 
            this.txtRD.Location = new System.Drawing.Point(295, 45);
            this.txtRD.Name = "txtRD";
            this.txtRD.ReadOnly = true;
            this.txtRD.Size = new System.Drawing.Size(50, 20);
            this.txtRD.TabIndex = 41;
            // 
            // lblRC
            // 
            this.lblRC.AutoSize = true;
            this.lblRC.Location = new System.Drawing.Point(268, 22);
            this.lblRC.Name = "lblRC";
            this.lblRC.Size = new System.Drawing.Size(22, 13);
            this.lblRC.TabIndex = 40;
            this.lblRC.Text = "RC";
            // 
            // txtRC
            // 
            this.txtRC.Location = new System.Drawing.Point(295, 19);
            this.txtRC.Name = "txtRC";
            this.txtRC.ReadOnly = true;
            this.txtRC.Size = new System.Drawing.Size(50, 20);
            this.txtRC.TabIndex = 39;
            // 
            // lblRB
            // 
            this.lblRB.AutoSize = true;
            this.lblRB.Location = new System.Drawing.Point(181, 100);
            this.lblRB.Name = "lblRB";
            this.lblRB.Size = new System.Drawing.Size(22, 13);
            this.lblRB.TabIndex = 38;
            this.lblRB.Text = "RB";
            // 
            // txtRB
            // 
            this.txtRB.Location = new System.Drawing.Point(208, 97);
            this.txtRB.Name = "txtRB";
            this.txtRB.ReadOnly = true;
            this.txtRB.Size = new System.Drawing.Size(50, 20);
            this.txtRB.TabIndex = 37;
            // 
            // lblRA
            // 
            this.lblRA.AutoSize = true;
            this.lblRA.Location = new System.Drawing.Point(181, 74);
            this.lblRA.Name = "lblRA";
            this.lblRA.Size = new System.Drawing.Size(22, 13);
            this.lblRA.TabIndex = 36;
            this.lblRA.Text = "RA";
            // 
            // txtRA
            // 
            this.txtRA.Location = new System.Drawing.Point(208, 71);
            this.txtRA.Name = "txtRA";
            this.txtRA.ReadOnly = true;
            this.txtRA.Size = new System.Drawing.Size(50, 20);
            this.txtRA.TabIndex = 35;
            // 
            // lblR9
            // 
            this.lblR9.AutoSize = true;
            this.lblR9.Location = new System.Drawing.Point(181, 48);
            this.lblR9.Name = "lblR9";
            this.lblR9.Size = new System.Drawing.Size(21, 13);
            this.lblR9.TabIndex = 34;
            this.lblR9.Text = "R9";
            // 
            // txtR9
            // 
            this.txtR9.Location = new System.Drawing.Point(208, 45);
            this.txtR9.Name = "txtR9";
            this.txtR9.ReadOnly = true;
            this.txtR9.Size = new System.Drawing.Size(50, 20);
            this.txtR9.TabIndex = 33;
            // 
            // lblR8
            // 
            this.lblR8.AutoSize = true;
            this.lblR8.Location = new System.Drawing.Point(181, 22);
            this.lblR8.Name = "lblR8";
            this.lblR8.Size = new System.Drawing.Size(21, 13);
            this.lblR8.TabIndex = 32;
            this.lblR8.Text = "R8";
            // 
            // txtR8
            // 
            this.txtR8.Location = new System.Drawing.Point(208, 19);
            this.txtR8.Name = "txtR8";
            this.txtR8.ReadOnly = true;
            this.txtR8.Size = new System.Drawing.Size(50, 20);
            this.txtR8.TabIndex = 31;
            // 
            // lblR7
            // 
            this.lblR7.AutoSize = true;
            this.lblR7.Location = new System.Drawing.Point(95, 100);
            this.lblR7.Name = "lblR7";
            this.lblR7.Size = new System.Drawing.Size(21, 13);
            this.lblR7.TabIndex = 26;
            this.lblR7.Text = "R7";
            // 
            // txtR7
            // 
            this.txtR7.Location = new System.Drawing.Point(122, 97);
            this.txtR7.Name = "txtR7";
            this.txtR7.ReadOnly = true;
            this.txtR7.Size = new System.Drawing.Size(50, 20);
            this.txtR7.TabIndex = 25;
            // 
            // lblR6
            // 
            this.lblR6.AutoSize = true;
            this.lblR6.Location = new System.Drawing.Point(95, 74);
            this.lblR6.Name = "lblR6";
            this.lblR6.Size = new System.Drawing.Size(21, 13);
            this.lblR6.TabIndex = 24;
            this.lblR6.Text = "R6";
            // 
            // txtR6
            // 
            this.txtR6.Location = new System.Drawing.Point(122, 71);
            this.txtR6.Name = "txtR6";
            this.txtR6.ReadOnly = true;
            this.txtR6.Size = new System.Drawing.Size(50, 20);
            this.txtR6.TabIndex = 23;
            // 
            // lblR5
            // 
            this.lblR5.AutoSize = true;
            this.lblR5.Location = new System.Drawing.Point(95, 48);
            this.lblR5.Name = "lblR5";
            this.lblR5.Size = new System.Drawing.Size(21, 13);
            this.lblR5.TabIndex = 22;
            this.lblR5.Text = "R5";
            // 
            // txtR5
            // 
            this.txtR5.Location = new System.Drawing.Point(122, 45);
            this.txtR5.Name = "txtR5";
            this.txtR5.ReadOnly = true;
            this.txtR5.Size = new System.Drawing.Size(50, 20);
            this.txtR5.TabIndex = 21;
            // 
            // lblR4
            // 
            this.lblR4.AutoSize = true;
            this.lblR4.Location = new System.Drawing.Point(95, 22);
            this.lblR4.Name = "lblR4";
            this.lblR4.Size = new System.Drawing.Size(21, 13);
            this.lblR4.TabIndex = 20;
            this.lblR4.Text = "R4";
            // 
            // txtR4
            // 
            this.txtR4.Location = new System.Drawing.Point(122, 19);
            this.txtR4.Name = "txtR4";
            this.txtR4.ReadOnly = true;
            this.txtR4.Size = new System.Drawing.Size(50, 20);
            this.txtR4.TabIndex = 19;
            // 
            // lblR3
            // 
            this.lblR3.AutoSize = true;
            this.lblR3.Location = new System.Drawing.Point(8, 100);
            this.lblR3.Name = "lblR3";
            this.lblR3.Size = new System.Drawing.Size(21, 13);
            this.lblR3.TabIndex = 14;
            this.lblR3.Text = "R3";
            // 
            // txtR3
            // 
            this.txtR3.Location = new System.Drawing.Point(35, 97);
            this.txtR3.Name = "txtR3";
            this.txtR3.ReadOnly = true;
            this.txtR3.Size = new System.Drawing.Size(50, 20);
            this.txtR3.TabIndex = 13;
            // 
            // lblR2
            // 
            this.lblR2.AutoSize = true;
            this.lblR2.Location = new System.Drawing.Point(8, 74);
            this.lblR2.Name = "lblR2";
            this.lblR2.Size = new System.Drawing.Size(21, 13);
            this.lblR2.TabIndex = 12;
            this.lblR2.Text = "R2";
            // 
            // txtR2
            // 
            this.txtR2.Location = new System.Drawing.Point(35, 71);
            this.txtR2.Name = "txtR2";
            this.txtR2.ReadOnly = true;
            this.txtR2.Size = new System.Drawing.Size(50, 20);
            this.txtR2.TabIndex = 11;
            // 
            // lblR1
            // 
            this.lblR1.AutoSize = true;
            this.lblR1.Location = new System.Drawing.Point(8, 48);
            this.lblR1.Name = "lblR1";
            this.lblR1.Size = new System.Drawing.Size(21, 13);
            this.lblR1.TabIndex = 10;
            this.lblR1.Text = "R1";
            // 
            // txtR1
            // 
            this.txtR1.Location = new System.Drawing.Point(35, 45);
            this.txtR1.Name = "txtR1";
            this.txtR1.ReadOnly = true;
            this.txtR1.Size = new System.Drawing.Size(50, 20);
            this.txtR1.TabIndex = 9;
            // 
            // lblR0
            // 
            this.lblR0.AutoSize = true;
            this.lblR0.Location = new System.Drawing.Point(8, 22);
            this.lblR0.Name = "lblR0";
            this.lblR0.Size = new System.Drawing.Size(21, 13);
            this.lblR0.TabIndex = 8;
            this.lblR0.Text = "R0";
            // 
            // txtR0
            // 
            this.txtR0.Location = new System.Drawing.Point(35, 19);
            this.txtR0.Name = "txtR0";
            this.txtR0.ReadOnly = true;
            this.txtR0.Size = new System.Drawing.Size(50, 20);
            this.txtR0.TabIndex = 7;
            // 
            // grpSpecialPurpose
            // 
            this.grpSpecialPurpose.Controls.Add(this.txtAdress);
            this.grpSpecialPurpose.Controls.Add(this.lblIndex);
            this.grpSpecialPurpose.Controls.Add(this.txtInstruction);
            this.grpSpecialPurpose.Controls.Add(this.txtProgramCounter);
            this.grpSpecialPurpose.Controls.Add(this.lblInstruction);
            this.grpSpecialPurpose.Controls.Add(this.lblProgramCounter);
            this.grpSpecialPurpose.Location = new System.Drawing.Point(452, 40);
            this.grpSpecialPurpose.Name = "grpSpecialPurpose";
            this.grpSpecialPurpose.Size = new System.Drawing.Size(359, 53);
            this.grpSpecialPurpose.TabIndex = 7;
            this.grpSpecialPurpose.TabStop = false;
            this.grpSpecialPurpose.Text = "Special Purpose Registers";
            // 
            // txtAdress
            // 
            this.txtAdress.Location = new System.Drawing.Point(295, 23);
            this.txtAdress.Name = "txtAdress";
            this.txtAdress.ReadOnly = true;
            this.txtAdress.Size = new System.Drawing.Size(50, 20);
            this.txtAdress.TabIndex = 6;
            // 
            // lblIndex
            // 
            this.lblIndex.AutoSize = true;
            this.lblIndex.Location = new System.Drawing.Point(244, 26);
            this.lblIndex.Name = "lblIndex";
            this.lblIndex.Size = new System.Drawing.Size(33, 13);
            this.lblIndex.TabIndex = 7;
            this.lblIndex.Text = "Index";
            // 
            // btnStep
            // 
            this.btnStep.Location = new System.Drawing.Point(530, 261);
            this.btnStep.Name = "btnStep";
            this.btnStep.Size = new System.Drawing.Size(143, 23);
            this.btnStep.TabIndex = 8;
            this.btnStep.Text = "Step";
            this.btnStep.UseVisualStyleBackColor = true;
            this.btnStep.Click += new System.EventHandler(this.btnStep_Click);
            // 
            // chkHex
            // 
            this.chkHex.AutoSize = true;
            this.chkHex.Location = new System.Drawing.Point(773, 235);
            this.chkHex.Name = "chkHex";
            this.chkHex.Size = new System.Drawing.Size(45, 17);
            this.chkHex.TabIndex = 9;
            this.chkHex.Text = "Hex";
            this.chkHex.UseVisualStyleBackColor = true;
            this.chkHex.CheckedChanged += new System.EventHandler(this.chkHex_CheckedChanged);
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(579, 233);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ReadOnly = true;
            this.txtMessage.Size = new System.Drawing.Size(94, 20);
            this.txtMessage.TabIndex = 8;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(527, 236);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(50, 13);
            this.lblMessage.TabIndex = 9;
            this.lblMessage.Text = "Message";
            // 
            // txtSound
            // 
            this.txtSound.Location = new System.Drawing.Point(723, 233);
            this.txtSound.Name = "txtSound";
            this.txtSound.ReadOnly = true;
            this.txtSound.Size = new System.Drawing.Size(44, 20);
            this.txtSound.TabIndex = 10;
            // 
            // lblSound
            // 
            this.lblSound.AutoSize = true;
            this.lblSound.Location = new System.Drawing.Point(679, 236);
            this.lblSound.Name = "lblSound";
            this.lblSound.Size = new System.Drawing.Size(38, 13);
            this.lblSound.TabIndex = 11;
            this.lblSound.Text = "Sound";
            // 
            // glDisplay
            // 
            this.glDisplay.BackColor = System.Drawing.Color.Black;
            this.glDisplay.Location = new System.Drawing.Point(0, 27);
            this.glDisplay.Name = "glDisplay";
            this.glDisplay.Size = new System.Drawing.Size(443, 263);
            this.glDisplay.TabIndex = 12;
            this.glDisplay.VSync = false;
            this.glDisplay.Load += new System.EventHandler(this.glDisplay_Load);
            // 
            // txtFPS
            // 
            this.txtFPS.Location = new System.Drawing.Point(476, 261);
            this.txtFPS.Name = "txtFPS";
            this.txtFPS.ReadOnly = true;
            this.txtFPS.Size = new System.Drawing.Size(45, 20);
            this.txtFPS.TabIndex = 13;
            // 
            // lblFPS
            // 
            this.lblFPS.AutoSize = true;
            this.lblFPS.Location = new System.Drawing.Point(446, 266);
            this.lblFPS.Name = "lblFPS";
            this.lblFPS.Size = new System.Drawing.Size(27, 13);
            this.lblFPS.TabIndex = 14;
            this.lblFPS.Text = "FPS";
            // 
            // txtIPS
            // 
            this.txtIPS.Location = new System.Drawing.Point(476, 233);
            this.txtIPS.Name = "txtIPS";
            this.txtIPS.ReadOnly = true;
            this.txtIPS.Size = new System.Drawing.Size(45, 20);
            this.txtIPS.TabIndex = 15;
            // 
            // lblIPS
            // 
            this.lblIPS.AutoSize = true;
            this.lblIPS.Location = new System.Drawing.Point(449, 236);
            this.lblIPS.Name = "lblIPS";
            this.lblIPS.Size = new System.Drawing.Size(24, 13);
            this.lblIPS.TabIndex = 16;
            this.lblIPS.Text = "IPS";
            // 
            // btnUnstep
            // 
            this.btnUnstep.Location = new System.Drawing.Point(682, 261);
            this.btnUnstep.Name = "btnUnstep";
            this.btnUnstep.Size = new System.Drawing.Size(123, 23);
            this.btnUnstep.TabIndex = 17;
            this.btnUnstep.Text = "UnStep";
            this.btnUnstep.UseVisualStyleBackColor = true;
            this.btnUnstep.Click += new System.EventHandler(this.btnUnstep_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 290);
            this.Controls.Add(this.btnUnstep);
            this.Controls.Add(this.txtIPS);
            this.Controls.Add(this.lblIPS);
            this.Controls.Add(this.txtFPS);
            this.Controls.Add(this.lblFPS);
            this.Controls.Add(this.glDisplay);
            this.Controls.Add(this.txtSound);
            this.Controls.Add(this.lblSound);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.chkHex);
            this.Controls.Add(this.btnStep);
            this.Controls.Add(this.grpSpecialPurpose);
            this.Controls.Add(this.grpGeneralPurpose);
            this.Controls.Add(this.mnuMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.mnuMain;
            this.Name = "frmMain";
            this.Text = "Chipster";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.grpGeneralPurpose.ResumeLayout(false);
            this.grpGeneralPurpose.PerformLayout();
            this.grpSpecialPurpose.ResumeLayout(false);
            this.grpSpecialPurpose.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadROMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadStateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem soundToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.TextBox txtProgramCounter;
        private System.Windows.Forms.TextBox txtInstruction;
        private System.Windows.Forms.Label lblProgramCounter;
        private System.Windows.Forms.Label lblInstruction;
        private System.Windows.Forms.GroupBox grpGeneralPurpose;
        private System.Windows.Forms.Label lblRF;
        private System.Windows.Forms.TextBox txtRF;
        private System.Windows.Forms.Label lblRE;
        private System.Windows.Forms.TextBox txtRE;
        private System.Windows.Forms.Label lblRD;
        private System.Windows.Forms.TextBox txtRD;
        private System.Windows.Forms.Label lblRC;
        private System.Windows.Forms.TextBox txtRC;
        private System.Windows.Forms.Label lblRB;
        private System.Windows.Forms.TextBox txtRB;
        private System.Windows.Forms.Label lblRA;
        private System.Windows.Forms.TextBox txtRA;
        private System.Windows.Forms.Label lblR9;
        private System.Windows.Forms.TextBox txtR9;
        private System.Windows.Forms.Label lblR8;
        private System.Windows.Forms.TextBox txtR8;
        private System.Windows.Forms.Label lblR7;
        private System.Windows.Forms.TextBox txtR7;
        private System.Windows.Forms.Label lblR6;
        private System.Windows.Forms.TextBox txtR6;
        private System.Windows.Forms.Label lblR5;
        private System.Windows.Forms.TextBox txtR5;
        private System.Windows.Forms.Label lblR4;
        private System.Windows.Forms.TextBox txtR4;
        private System.Windows.Forms.Label lblR3;
        private System.Windows.Forms.TextBox txtR3;
        private System.Windows.Forms.Label lblR2;
        private System.Windows.Forms.TextBox txtR2;
        private System.Windows.Forms.Label lblR1;
        private System.Windows.Forms.TextBox txtR1;
        private System.Windows.Forms.Label lblR0;
        private System.Windows.Forms.TextBox txtR0;
        private System.Windows.Forms.GroupBox grpSpecialPurpose;
        private System.Windows.Forms.TextBox txtAdress;
        private System.Windows.Forms.Label lblIndex;
        private System.Windows.Forms.Button btnStep;
        private System.Windows.Forms.CheckBox chkHex;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.TextBox txtSound;
        private System.Windows.Forms.Label lblSound;
        private OpenTK.GLControl glDisplay;
        private System.Windows.Forms.TextBox txtFPS;
        private System.Windows.Forms.Label lblFPS;
        private System.Windows.Forms.TextBox txtIPS;
        private System.Windows.Forms.Label lblIPS;
        private System.Windows.Forms.Button btnUnstep;
        private System.Windows.Forms.ToolStripMenuItem saveStateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem debuggerToggleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem decompileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem speedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem khz1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem khz2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem khz3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem khz4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem khz5ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem khz6ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem khz7ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem khz8ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem khz9ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x100ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem khzUnlimitedToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem x10ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkForUpdatesToolStripMenuItem;
    }
}

