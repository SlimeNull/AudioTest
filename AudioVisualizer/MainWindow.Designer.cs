
namespace AudioVisualizer
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.StartBtn = new System.Windows.Forms.Button();
            this.DrawPanel = new System.Windows.Forms.Panel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.curveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.multipleToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.curve_option_multiple = new System.Windows.Forms.ToolStripTextBox();
            this.circleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enableToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.optionToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.multipleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.circle_option_multiple = new System.Windows.Forms.ToolStripTextBox();
            this.offsetPerFrameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.circle_option_offsetPerFrame = new System.Windows.Forms.ToolStripTextBox();
            this.optionToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshIntervalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.option_refreshInterval = new System.Windows.Forms.ToolStripTextBox();
            this.backgroundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.RefreshBtn = new System.Windows.Forms.Button();
            this.FileNameContent = new System.Windows.Forms.Label();
            this.IsSaveFile = new System.Windows.Forms.CheckBox();
            this.MusicPlayPanel = new System.Windows.Forms.Panel();
            this.MusicNameLb = new System.Windows.Forms.Label();
            this.TotalTimeLb = new System.Windows.Forms.Label();
            this.CurrentTimeLb = new System.Windows.Forms.Label();
            this.PlayListBox = new System.Windows.Forms.ListBox();
            this.RemoveBtn = new System.Windows.Forms.Button();
            this.AddBtn = new System.Windows.Forms.Button();
            this.StopBtn = new System.Windows.Forms.Button();
            this.PauseBtn = new System.Windows.Forms.Button();
            this.PlayBtn = new System.Windows.Forms.Button();
            this.PlayOffsetBar = new System.Windows.Forms.TrackBar();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.WindowTopMost = new System.Windows.Forms.CheckBox();
            this.DrawPanel.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.MusicPlayPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PlayOffsetBar)).BeginInit();
            this.SuspendLayout();
            // 
            // StartBtn
            // 
            this.StartBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.StartBtn.Location = new System.Drawing.Point(599, 1);
            this.StartBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(64, 24);
            this.StartBtn.TabIndex = 0;
            this.StartBtn.Text = "Start";
            this.StartBtn.UseVisualStyleBackColor = true;
            this.StartBtn.Click += new System.EventHandler(this.StartStopBtn_Click);
            // 
            // DrawPanel
            // 
            this.DrawPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DrawPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DrawPanel.ContextMenuStrip = this.contextMenuStrip1;
            this.DrawPanel.Controls.Add(this.RefreshBtn);
            this.DrawPanel.Controls.Add(this.StartBtn);
            this.DrawPanel.Controls.Add(this.FileNameContent);
            this.DrawPanel.Controls.Add(this.IsSaveFile);
            this.DrawPanel.Location = new System.Drawing.Point(11, 8);
            this.DrawPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DrawPanel.Name = "DrawPanel";
            this.DrawPanel.Size = new System.Drawing.Size(666, 437);
            this.DrawPanel.TabIndex = 2;
            this.DrawPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DrawPanel_MouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.curveToolStripMenuItem,
            this.circleToolStripMenuItem,
            this.optionToolStripMenuItem2});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(117, 70);
            this.contextMenuStrip1.Closed += new System.Windows.Forms.ToolStripDropDownClosedEventHandler(this.contextMenuStrip1_Closed);
            // 
            // curveToolStripMenuItem
            // 
            this.curveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enableToolStripMenuItem,
            this.optionToolStripMenuItem});
            this.curveToolStripMenuItem.Name = "curveToolStripMenuItem";
            this.curveToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.curveToolStripMenuItem.Text = "Curve";
            // 
            // enableToolStripMenuItem
            // 
            this.enableToolStripMenuItem.Name = "enableToolStripMenuItem";
            this.enableToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.enableToolStripMenuItem.Text = "Enable";
            // 
            // optionToolStripMenuItem
            // 
            this.optionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.multipleToolStripMenuItem1});
            this.optionToolStripMenuItem.Name = "optionToolStripMenuItem";
            this.optionToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.optionToolStripMenuItem.Text = "Option";
            // 
            // multipleToolStripMenuItem1
            // 
            this.multipleToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.curve_option_multiple});
            this.multipleToolStripMenuItem1.Name = "multipleToolStripMenuItem1";
            this.multipleToolStripMenuItem1.Size = new System.Drawing.Size(123, 22);
            this.multipleToolStripMenuItem1.Text = "Multiple";
            // 
            // curve_option_multiple
            // 
            this.curve_option_multiple.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.curve_option_multiple.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.curve_option_multiple.Name = "curve_option_multiple";
            this.curve_option_multiple.Size = new System.Drawing.Size(100, 23);
            this.curve_option_multiple.Text = "1";
            // 
            // circleToolStripMenuItem
            // 
            this.circleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enableToolStripMenuItem1,
            this.optionToolStripMenuItem1});
            this.circleToolStripMenuItem.Name = "circleToolStripMenuItem";
            this.circleToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.circleToolStripMenuItem.Text = "Circle";
            // 
            // enableToolStripMenuItem1
            // 
            this.enableToolStripMenuItem1.Name = "enableToolStripMenuItem1";
            this.enableToolStripMenuItem1.Size = new System.Drawing.Size(116, 22);
            this.enableToolStripMenuItem1.Text = "Enable";
            // 
            // optionToolStripMenuItem1
            // 
            this.optionToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.multipleToolStripMenuItem,
            this.offsetPerFrameToolStripMenuItem});
            this.optionToolStripMenuItem1.Name = "optionToolStripMenuItem1";
            this.optionToolStripMenuItem1.Size = new System.Drawing.Size(116, 22);
            this.optionToolStripMenuItem1.Text = "Option";
            // 
            // multipleToolStripMenuItem
            // 
            this.multipleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.circle_option_multiple});
            this.multipleToolStripMenuItem.Name = "multipleToolStripMenuItem";
            this.multipleToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.multipleToolStripMenuItem.Text = "Multiple";
            // 
            // circle_option_multiple
            // 
            this.circle_option_multiple.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.circle_option_multiple.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.circle_option_multiple.Name = "circle_option_multiple";
            this.circle_option_multiple.Size = new System.Drawing.Size(100, 23);
            // 
            // offsetPerFrameToolStripMenuItem
            // 
            this.offsetPerFrameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.circle_option_offsetPerFrame});
            this.offsetPerFrameToolStripMenuItem.Name = "offsetPerFrameToolStripMenuItem";
            this.offsetPerFrameToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.offsetPerFrameToolStripMenuItem.Text = "OffsetPerFrame";
            // 
            // circle_option_offsetPerFrame
            // 
            this.circle_option_offsetPerFrame.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.circle_option_offsetPerFrame.Name = "circle_option_offsetPerFrame";
            this.circle_option_offsetPerFrame.Size = new System.Drawing.Size(100, 23);
            // 
            // optionToolStripMenuItem2
            // 
            this.optionToolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshIntervalToolStripMenuItem,
            this.backgroundToolStripMenuItem});
            this.optionToolStripMenuItem2.Name = "optionToolStripMenuItem2";
            this.optionToolStripMenuItem2.Size = new System.Drawing.Size(116, 22);
            this.optionToolStripMenuItem2.Text = "Option";
            // 
            // refreshIntervalToolStripMenuItem
            // 
            this.refreshIntervalToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.option_refreshInterval});
            this.refreshIntervalToolStripMenuItem.Name = "refreshIntervalToolStripMenuItem";
            this.refreshIntervalToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.refreshIntervalToolStripMenuItem.Text = "RefreshInterval";
            // 
            // option_refreshInterval
            // 
            this.option_refreshInterval.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.option_refreshInterval.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.option_refreshInterval.Name = "option_refreshInterval";
            this.option_refreshInterval.Size = new System.Drawing.Size(100, 23);
            // 
            // backgroundToolStripMenuItem
            // 
            this.backgroundToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox1});
            this.backgroundToolStripMenuItem.Name = "backgroundToolStripMenuItem";
            this.backgroundToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.backgroundToolStripMenuItem.Text = "Background";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolStripTextBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBox1.Text = "#F0F0F0";
            // 
            // RefreshBtn
            // 
            this.RefreshBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RefreshBtn.Location = new System.Drawing.Point(535, 1);
            this.RefreshBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RefreshBtn.Name = "RefreshBtn";
            this.RefreshBtn.Size = new System.Drawing.Size(64, 24);
            this.RefreshBtn.TabIndex = 0;
            this.RefreshBtn.Text = "Refresh";
            this.RefreshBtn.UseVisualStyleBackColor = true;
            this.RefreshBtn.Click += new System.EventHandler(this.RefreshBtn_Click);
            // 
            // FileNameContent
            // 
            this.FileNameContent.AutoSize = true;
            this.FileNameContent.Location = new System.Drawing.Point(83, 6);
            this.FileNameContent.Name = "FileNameContent";
            this.FileNameContent.Size = new System.Drawing.Size(83, 12);
            this.FileNameContent.TabIndex = 4;
            this.FileNameContent.Text = "Not start yet";
            // 
            // IsSaveFile
            // 
            this.IsSaveFile.AutoSize = true;
            this.IsSaveFile.Location = new System.Drawing.Point(5, 5);
            this.IsSaveFile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.IsSaveFile.Name = "IsSaveFile";
            this.IsSaveFile.Size = new System.Drawing.Size(78, 16);
            this.IsSaveFile.TabIndex = 6;
            this.IsSaveFile.Text = "SaveFile:";
            this.IsSaveFile.UseVisualStyleBackColor = true;
            // 
            // MusicPlayPanel
            // 
            this.MusicPlayPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MusicPlayPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MusicPlayPanel.Controls.Add(this.WindowTopMost);
            this.MusicPlayPanel.Controls.Add(this.MusicNameLb);
            this.MusicPlayPanel.Controls.Add(this.TotalTimeLb);
            this.MusicPlayPanel.Controls.Add(this.CurrentTimeLb);
            this.MusicPlayPanel.Controls.Add(this.PlayListBox);
            this.MusicPlayPanel.Controls.Add(this.RemoveBtn);
            this.MusicPlayPanel.Controls.Add(this.AddBtn);
            this.MusicPlayPanel.Controls.Add(this.StopBtn);
            this.MusicPlayPanel.Controls.Add(this.PauseBtn);
            this.MusicPlayPanel.Controls.Add(this.PlayBtn);
            this.MusicPlayPanel.Controls.Add(this.PlayOffsetBar);
            this.MusicPlayPanel.Location = new System.Drawing.Point(682, 8);
            this.MusicPlayPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MusicPlayPanel.Name = "MusicPlayPanel";
            this.MusicPlayPanel.Size = new System.Drawing.Size(224, 437);
            this.MusicPlayPanel.TabIndex = 7;
            // 
            // MusicNameLb
            // 
            this.MusicNameLb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.MusicNameLb.AutoSize = true;
            this.MusicNameLb.Location = new System.Drawing.Point(3, 342);
            this.MusicNameLb.Name = "MusicNameLb";
            this.MusicNameLb.Size = new System.Drawing.Size(83, 12);
            this.MusicNameLb.TabIndex = 5;
            this.MusicNameLb.Text = "Not start yet";
            // 
            // TotalTimeLb
            // 
            this.TotalTimeLb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TotalTimeLb.AutoSize = true;
            this.TotalTimeLb.Location = new System.Drawing.Point(184, 389);
            this.TotalTimeLb.Name = "TotalTimeLb";
            this.TotalTimeLb.Size = new System.Drawing.Size(35, 12);
            this.TotalTimeLb.TabIndex = 4;
            this.TotalTimeLb.Text = "00:00";
            // 
            // CurrentTimeLb
            // 
            this.CurrentTimeLb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CurrentTimeLb.AutoSize = true;
            this.CurrentTimeLb.Location = new System.Drawing.Point(3, 389);
            this.CurrentTimeLb.Name = "CurrentTimeLb";
            this.CurrentTimeLb.Size = new System.Drawing.Size(35, 12);
            this.CurrentTimeLb.TabIndex = 3;
            this.CurrentTimeLb.Text = "00:00";
            // 
            // PlayListBox
            // 
            this.PlayListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PlayListBox.FormattingEnabled = true;
            this.PlayListBox.ItemHeight = 12;
            this.PlayListBox.Location = new System.Drawing.Point(-2, -1);
            this.PlayListBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PlayListBox.Name = "PlayListBox";
            this.PlayListBox.Size = new System.Drawing.Size(225, 328);
            this.PlayListBox.TabIndex = 1;
            // 
            // RemoveBtn
            // 
            this.RemoveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RemoveBtn.Location = new System.Drawing.Point(28, 408);
            this.RemoveBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RemoveBtn.Name = "RemoveBtn";
            this.RemoveBtn.Size = new System.Drawing.Size(25, 25);
            this.RemoveBtn.TabIndex = 0;
            this.RemoveBtn.Text = "-";
            this.RemoveBtn.UseVisualStyleBackColor = true;
            this.RemoveBtn.Click += new System.EventHandler(this.RemoveBtn_Click);
            // 
            // AddBtn
            // 
            this.AddBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AddBtn.Location = new System.Drawing.Point(1, 408);
            this.AddBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(25, 25);
            this.AddBtn.TabIndex = 0;
            this.AddBtn.Text = "+";
            this.AddBtn.UseVisualStyleBackColor = true;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // StopBtn
            // 
            this.StopBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.StopBtn.Location = new System.Drawing.Point(140, 408);
            this.StopBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.StopBtn.Name = "StopBtn";
            this.StopBtn.Size = new System.Drawing.Size(25, 25);
            this.StopBtn.TabIndex = 0;
            this.StopBtn.Text = "◼";
            this.StopBtn.UseVisualStyleBackColor = true;
            this.StopBtn.Click += new System.EventHandler(this.StopBtn_Click);
            // 
            // PauseBtn
            // 
            this.PauseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.PauseBtn.Location = new System.Drawing.Point(167, 408);
            this.PauseBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PauseBtn.Name = "PauseBtn";
            this.PauseBtn.Size = new System.Drawing.Size(25, 25);
            this.PauseBtn.TabIndex = 0;
            this.PauseBtn.Text = "⏸";
            this.PauseBtn.UseVisualStyleBackColor = true;
            this.PauseBtn.Click += new System.EventHandler(this.PauseBtn_Click);
            // 
            // PlayBtn
            // 
            this.PlayBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.PlayBtn.Location = new System.Drawing.Point(194, 408);
            this.PlayBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PlayBtn.Name = "PlayBtn";
            this.PlayBtn.Size = new System.Drawing.Size(25, 25);
            this.PlayBtn.TabIndex = 0;
            this.PlayBtn.Text = "▶";
            this.PlayBtn.UseVisualStyleBackColor = true;
            this.PlayBtn.Click += new System.EventHandler(this.PlayBtn_Click);
            // 
            // PlayOffsetBar
            // 
            this.PlayOffsetBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PlayOffsetBar.Location = new System.Drawing.Point(1, 362);
            this.PlayOffsetBar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PlayOffsetBar.Name = "PlayOffsetBar";
            this.PlayOffsetBar.Size = new System.Drawing.Size(220, 45);
            this.PlayOffsetBar.TabIndex = 2;
            this.PlayOffsetBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.PlayOffsetBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PlayOffsetBar_MouseDown);
            this.PlayOffsetBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PlayOffsetBar_MouseUp);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // WindowTopMost
            // 
            this.WindowTopMost.AutoSize = true;
            this.WindowTopMost.Location = new System.Drawing.Point(60, 413);
            this.WindowTopMost.Name = "WindowTopMost";
            this.WindowTopMost.Size = new System.Drawing.Size(66, 16);
            this.WindowTopMost.TabIndex = 6;
            this.WindowTopMost.Text = "TopMost";
            this.WindowTopMost.UseVisualStyleBackColor = true;
            this.WindowTopMost.CheckedChanged += new System.EventHandler(this.WindowTopMost_CheckedChanged);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 454);
            this.Controls.Add(this.MusicPlayPanel);
            this.Controls.Add(this.DrawPanel);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(570, 335);
            this.Name = "MainWindow";
            this.Text = "Null.AudioVisualizer";
            this.DrawPanel.ResumeLayout(false);
            this.DrawPanel.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.MusicPlayPanel.ResumeLayout(false);
            this.MusicPlayPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PlayOffsetBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button StartBtn;
        private System.Windows.Forms.Panel DrawPanel;
        private System.Windows.Forms.Label FileNameContent;
        private System.Windows.Forms.CheckBox IsSaveFile;
        private System.Windows.Forms.Panel MusicPlayPanel;
        private System.Windows.Forms.ListBox PlayListBox;
        private System.Windows.Forms.Button RemoveBtn;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.Button PauseBtn;
        private System.Windows.Forms.Button PlayBtn;
        private System.Windows.Forms.TrackBar PlayOffsetBar;
        private System.Windows.Forms.Label TotalTimeLb;
        private System.Windows.Forms.Label CurrentTimeLb;
        private System.Windows.Forms.Label MusicNameLb;
        private System.Windows.Forms.Button StopBtn;
        private System.Windows.Forms.Button RefreshBtn;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem curveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem circleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enableToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem optionToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem optionToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem refreshIntervalToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox option_refreshInterval;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem multipleToolStripMenuItem1;
        private System.Windows.Forms.ToolStripTextBox curve_option_multiple;
        private System.Windows.Forms.ToolStripMenuItem multipleToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox circle_option_multiple;
        private System.Windows.Forms.ToolStripMenuItem backgroundToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripMenuItem offsetPerFrameToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox circle_option_offsetPerFrame;
        private System.Windows.Forms.CheckBox WindowTopMost;
    }
}

