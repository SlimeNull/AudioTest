
namespace AudioTest
{
    partial class MainWindow
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Timer globalTimer;
            this.windowMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.PlayButton = new System.Windows.Forms.Button();
            this.PauseButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.PlayRepeatButton = new System.Windows.Forms.Button();
            this.GetModeButton = new System.Windows.Forms.Button();
            this.SeekToStartButton = new System.Windows.Forms.Button();
            this.PlayWaitButton = new System.Windows.Forms.Button();
            this.GetLengthButton = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.positionLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.GetPositionButton = new System.Windows.Forms.Button();
            globalTimer = new System.Windows.Forms.Timer(this.components);
            this.windowMenu.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            this.SuspendLayout();
            // 
            // globalTimer
            // 
            globalTimer.Enabled = true;
            globalTimer.Interval = 500;
            globalTimer.Tick += new System.EventHandler(this.GlobalTimer_Tick);
            // 
            // windowMenu
            // 
            this.windowMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.windowMenu.Location = new System.Drawing.Point(0, 0);
            this.windowMenu.Name = "windowMenu";
            this.windowMenu.Size = new System.Drawing.Size(800, 24);
            this.windowMenu.TabIndex = 0;
            this.windowMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // listBox1
            // 
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(0, 0);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(189, 411);
            this.listBox1.TabIndex = 1;
            // 
            // RemoveButton
            // 
            this.RemoveButton.Location = new System.Drawing.Point(255, 113);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(75, 23);
            this.RemoveButton.TabIndex = 2;
            this.RemoveButton.Text = "Remove";
            this.RemoveButton.UseVisualStyleBackColor = true;
            this.RemoveButton.Click += new System.EventHandler(this.RemoveMusic_Click);
            // 
            // PlayButton
            // 
            this.PlayButton.Location = new System.Drawing.Point(12, 113);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(75, 23);
            this.PlayButton.TabIndex = 3;
            this.PlayButton.Text = "Play";
            this.PlayButton.UseVisualStyleBackColor = true;
            this.PlayButton.Click += new System.EventHandler(this.PlayMusic_Click);
            // 
            // PauseButton
            // 
            this.PauseButton.Location = new System.Drawing.Point(93, 113);
            this.PauseButton.Name = "PauseButton";
            this.PauseButton.Size = new System.Drawing.Size(75, 23);
            this.PauseButton.TabIndex = 4;
            this.PauseButton.Text = "Pause";
            this.PauseButton.UseVisualStyleBackColor = true;
            this.PauseButton.Click += new System.EventHandler(this.PauseMusic_Click);
            // 
            // StopButton
            // 
            this.StopButton.Location = new System.Drawing.Point(174, 113);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(75, 23);
            this.StopButton.TabIndex = 5;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopMusic_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(13, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(133, 100);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PlayType";
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(15, 72);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(59, 16);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.Text = "NAudio";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(15, 47);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(83, 16);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "MciCommand";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(15, 22);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(89, 16);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "SoundPlayer";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // PlayRepeatButton
            // 
            this.PlayRepeatButton.Location = new System.Drawing.Point(368, 142);
            this.PlayRepeatButton.Name = "PlayRepeatButton";
            this.PlayRepeatButton.Size = new System.Drawing.Size(107, 23);
            this.PlayRepeatButton.TabIndex = 10;
            this.PlayRepeatButton.Text = "Play Repeat";
            this.PlayRepeatButton.UseVisualStyleBackColor = true;
            this.PlayRepeatButton.Click += new System.EventHandler(this.PlayMusicRepeat_Click);
            // 
            // GetModeButton
            // 
            this.GetModeButton.Location = new System.Drawing.Point(174, 142);
            this.GetModeButton.Name = "GetModeButton";
            this.GetModeButton.Size = new System.Drawing.Size(75, 23);
            this.GetModeButton.TabIndex = 9;
            this.GetModeButton.Text = "Get Mode";
            this.GetModeButton.UseVisualStyleBackColor = true;
            this.GetModeButton.Click += new System.EventHandler(this.GetMusicMode_Click);
            // 
            // SeekToStartButton
            // 
            this.SeekToStartButton.Location = new System.Drawing.Point(336, 113);
            this.SeekToStartButton.Name = "SeekToStartButton";
            this.SeekToStartButton.Size = new System.Drawing.Size(107, 23);
            this.SeekToStartButton.TabIndex = 8;
            this.SeekToStartButton.Text = "Seek to start";
            this.SeekToStartButton.UseVisualStyleBackColor = true;
            this.SeekToStartButton.Click += new System.EventHandler(this.SeekMusic_Click);
            // 
            // PlayWaitButton
            // 
            this.PlayWaitButton.Location = new System.Drawing.Point(12, 142);
            this.PlayWaitButton.Name = "PlayWaitButton";
            this.PlayWaitButton.Size = new System.Drawing.Size(75, 23);
            this.PlayWaitButton.TabIndex = 9;
            this.PlayWaitButton.Text = "Play wait";
            this.PlayWaitButton.UseVisualStyleBackColor = true;
            this.PlayWaitButton.Click += new System.EventHandler(this.PlayMusicWait_Click);
            // 
            // GetLengthButton
            // 
            this.GetLengthButton.Location = new System.Drawing.Point(93, 142);
            this.GetLengthButton.Name = "GetLengthButton";
            this.GetLengthButton.Size = new System.Drawing.Size(75, 23);
            this.GetLengthButton.TabIndex = 10;
            this.GetLengthButton.Text = "Get Length";
            this.GetLengthButton.UseVisualStyleBackColor = true;
            this.GetLengthButton.Click += new System.EventHandler(this.GetMusicLength_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 27);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.PlayRepeatButton);
            this.splitContainer1.Panel2.Controls.Add(this.positionLabel);
            this.splitContainer1.Panel2.Controls.Add(this.SeekToStartButton);
            this.splitContainer1.Panel2.Controls.Add(this.GetModeButton);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.trackBar2);
            this.splitContainer1.Panel2.Controls.Add(this.GetPositionButton);
            this.splitContainer1.Panel2.Controls.Add(this.RemoveButton);
            this.splitContainer1.Panel2.Controls.Add(this.GetLengthButton);
            this.splitContainer1.Panel2.Controls.Add(this.PlayButton);
            this.splitContainer1.Panel2.Controls.Add(this.PlayWaitButton);
            this.splitContainer1.Panel2.Controls.Add(this.PauseButton);
            this.splitContainer1.Panel2.Controls.Add(this.StopButton);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Size = new System.Drawing.Size(776, 411);
            this.splitContainer1.SplitterDistance = 189;
            this.splitContainer1.TabIndex = 11;
            // 
            // positionLabel
            // 
            this.positionLabel.AutoSize = true;
            this.positionLabel.Location = new System.Drawing.Point(82, 214);
            this.positionLabel.Name = "positionLabel";
            this.positionLabel.Size = new System.Drawing.Size(35, 12);
            this.positionLabel.TabIndex = 14;
            this.positionLabel.Text = "0 / 0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 214);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "Position:";
            // 
            // trackBar2
            // 
            this.trackBar2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar2.Location = new System.Drawing.Point(13, 171);
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(552, 45);
            this.trackBar2.TabIndex = 12;
            this.trackBar2.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBar2_MouseUp);
            // 
            // GetPositionButton
            // 
            this.GetPositionButton.Location = new System.Drawing.Point(255, 142);
            this.GetPositionButton.Name = "GetPositionButton";
            this.GetPositionButton.Size = new System.Drawing.Size(107, 23);
            this.GetPositionButton.TabIndex = 11;
            this.GetPositionButton.Text = "Get Position";
            this.GetPositionButton.UseVisualStyleBackColor = true;
            this.GetPositionButton.Click += new System.EventHandler(this.GetMusicPosition_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.windowMenu);
            this.MainMenuStrip = this.windowMenu;
            this.Name = "MainWindow";
            this.Text = "Null.AudioTest";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.windowMenu.ResumeLayout(false);
            this.windowMenu.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip windowMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.Button PlayButton;
        private System.Windows.Forms.Button PauseButton;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button SeekToStartButton;
        private System.Windows.Forms.Button PlayWaitButton;
        private System.Windows.Forms.Button GetLengthButton;
        private System.Windows.Forms.Button GetModeButton;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button GetPositionButton;
        private System.Windows.Forms.Button PlayRepeatButton;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.Label positionLabel;
        private System.Windows.Forms.Label label1;
    }
}

