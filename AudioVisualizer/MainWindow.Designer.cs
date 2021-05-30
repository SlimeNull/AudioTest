
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
            this.RefreshBtn = new System.Windows.Forms.Button();
            this.FileNameContent = new System.Windows.Forms.Label();
            this.IsSaveFile = new System.Windows.Forms.CheckBox();
            this.ViewModule = new System.Windows.Forms.BindingSource(this.components);
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
            this.DrawPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ViewModule)).BeginInit();
            this.MusicPlayPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PlayOffsetBar)).BeginInit();
            this.SuspendLayout();
            // 
            // StartBtn
            // 
            this.StartBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.StartBtn.Location = new System.Drawing.Point(604, 2);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(75, 23);
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
            this.DrawPanel.Controls.Add(this.RefreshBtn);
            this.DrawPanel.Controls.Add(this.StartBtn);
            this.DrawPanel.Controls.Add(this.FileNameContent);
            this.DrawPanel.Controls.Add(this.IsSaveFile);
            this.DrawPanel.Location = new System.Drawing.Point(13, 12);
            this.DrawPanel.Name = "DrawPanel";
            this.DrawPanel.Size = new System.Drawing.Size(682, 433);
            this.DrawPanel.TabIndex = 2;
            // 
            // RefreshBtn
            // 
            this.RefreshBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RefreshBtn.Location = new System.Drawing.Point(523, 2);
            this.RefreshBtn.Name = "RefreshBtn";
            this.RefreshBtn.Size = new System.Drawing.Size(75, 23);
            this.RefreshBtn.TabIndex = 0;
            this.RefreshBtn.Text = "Refresh";
            this.RefreshBtn.UseVisualStyleBackColor = true;
            this.RefreshBtn.Click += new System.EventHandler(this.RefreshBtn_Click);
            // 
            // FileNameContent
            // 
            this.FileNameContent.AutoSize = true;
            this.FileNameContent.Location = new System.Drawing.Point(75, 5);
            this.FileNameContent.Name = "FileNameContent";
            this.FileNameContent.Size = new System.Drawing.Size(81, 17);
            this.FileNameContent.TabIndex = 4;
            this.FileNameContent.Text = "Not start yet";
            // 
            // IsSaveFile
            // 
            this.IsSaveFile.AutoSize = true;
            this.IsSaveFile.Location = new System.Drawing.Point(3, 4);
            this.IsSaveFile.Name = "IsSaveFile";
            this.IsSaveFile.Size = new System.Drawing.Size(76, 21);
            this.IsSaveFile.TabIndex = 6;
            this.IsSaveFile.Text = "SaveFile:";
            this.IsSaveFile.UseVisualStyleBackColor = true;
            // 
            // MusicPlayPanel
            // 
            this.MusicPlayPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MusicPlayPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
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
            this.MusicPlayPanel.Location = new System.Drawing.Point(701, 12);
            this.MusicPlayPanel.Name = "MusicPlayPanel";
            this.MusicPlayPanel.Size = new System.Drawing.Size(261, 433);
            this.MusicPlayPanel.TabIndex = 7;
            // 
            // MusicNameLb
            // 
            this.MusicNameLb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.MusicNameLb.AutoSize = true;
            this.MusicNameLb.Location = new System.Drawing.Point(1, 336);
            this.MusicNameLb.Name = "MusicNameLb";
            this.MusicNameLb.Size = new System.Drawing.Size(81, 17);
            this.MusicNameLb.TabIndex = 5;
            this.MusicNameLb.Text = "Not start yet";
            // 
            // TotalTimeLb
            // 
            this.TotalTimeLb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TotalTimeLb.AutoSize = true;
            this.TotalTimeLb.Location = new System.Drawing.Point(215, 384);
            this.TotalTimeLb.Name = "TotalTimeLb";
            this.TotalTimeLb.Size = new System.Drawing.Size(39, 17);
            this.TotalTimeLb.TabIndex = 4;
            this.TotalTimeLb.Text = "00:00";
            // 
            // CurrentTimeLb
            // 
            this.CurrentTimeLb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CurrentTimeLb.AutoSize = true;
            this.CurrentTimeLb.Location = new System.Drawing.Point(-1, 384);
            this.CurrentTimeLb.Name = "CurrentTimeLb";
            this.CurrentTimeLb.Size = new System.Drawing.Size(39, 17);
            this.CurrentTimeLb.TabIndex = 3;
            this.CurrentTimeLb.Text = "00:00";
            // 
            // PlayListBox
            // 
            this.PlayListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PlayListBox.FormattingEnabled = true;
            this.PlayListBox.ItemHeight = 17;
            this.PlayListBox.Location = new System.Drawing.Point(1, 1);
            this.PlayListBox.Name = "PlayListBox";
            this.PlayListBox.Size = new System.Drawing.Size(257, 327);
            this.PlayListBox.TabIndex = 1;
            // 
            // RemoveBtn
            // 
            this.RemoveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RemoveBtn.Location = new System.Drawing.Point(25, 407);
            this.RemoveBtn.Name = "RemoveBtn";
            this.RemoveBtn.Size = new System.Drawing.Size(23, 23);
            this.RemoveBtn.TabIndex = 0;
            this.RemoveBtn.Text = "-";
            this.RemoveBtn.UseVisualStyleBackColor = true;
            this.RemoveBtn.Click += new System.EventHandler(this.RemoveBtn_Click);
            // 
            // AddBtn
            // 
            this.AddBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AddBtn.Location = new System.Drawing.Point(1, 407);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(23, 23);
            this.AddBtn.TabIndex = 0;
            this.AddBtn.Text = "+";
            this.AddBtn.UseVisualStyleBackColor = true;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // StopBtn
            // 
            this.StopBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.StopBtn.Location = new System.Drawing.Point(156, 407);
            this.StopBtn.Name = "StopBtn";
            this.StopBtn.Size = new System.Drawing.Size(30, 23);
            this.StopBtn.TabIndex = 0;
            this.StopBtn.Text = "◼";
            this.StopBtn.UseVisualStyleBackColor = true;
            this.StopBtn.Click += new System.EventHandler(this.StopBtn_Click);
            // 
            // PauseBtn
            // 
            this.PauseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.PauseBtn.Location = new System.Drawing.Point(192, 407);
            this.PauseBtn.Name = "PauseBtn";
            this.PauseBtn.Size = new System.Drawing.Size(30, 23);
            this.PauseBtn.TabIndex = 0;
            this.PauseBtn.Text = "II";
            this.PauseBtn.UseVisualStyleBackColor = true;
            this.PauseBtn.Click += new System.EventHandler(this.PauseBtn_Click);
            // 
            // PlayBtn
            // 
            this.PlayBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.PlayBtn.Location = new System.Drawing.Point(228, 407);
            this.PlayBtn.Name = "PlayBtn";
            this.PlayBtn.Size = new System.Drawing.Size(30, 23);
            this.PlayBtn.TabIndex = 0;
            this.PlayBtn.Text = "▶";
            this.PlayBtn.UseVisualStyleBackColor = true;
            this.PlayBtn.Click += new System.EventHandler(this.PlayBtn_Click);
            // 
            // PlayOffsetBar
            // 
            this.PlayOffsetBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PlayOffsetBar.Location = new System.Drawing.Point(1, 356);
            this.PlayOffsetBar.Name = "PlayOffsetBar";
            this.PlayOffsetBar.Size = new System.Drawing.Size(257, 45);
            this.PlayOffsetBar.TabIndex = 2;
            this.PlayOffsetBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.PlayOffsetBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PlayOffsetBar_MouseDown);
            this.PlayOffsetBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PlayOffsetBar_MouseUp);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 457);
            this.Controls.Add(this.MusicPlayPanel);
            this.Controls.Add(this.DrawPanel);
            this.DoubleBuffered = true;
            this.Name = "MainWindow";
            this.Text = "Null.AudioVisualizer";
            this.DrawPanel.ResumeLayout(false);
            this.DrawPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ViewModule)).EndInit();
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
        private System.Windows.Forms.BindingSource ViewModule;
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
    }
}

