
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
            this.FileNameContent = new System.Windows.Forms.Label();
            this.DataWriteTip = new System.Windows.Forms.Label();
            this.IsSaveFile = new System.Windows.Forms.CheckBox();
            this.ViewModule = new System.Windows.Forms.BindingSource(this.components);
            this.ControlPanel = new System.Windows.Forms.Panel();
            this.SimpleComplexBox = new System.Windows.Forms.CheckBox();
            this.SampleRateBox = new System.Windows.Forms.TextBox();
            this.ResetBtn = new System.Windows.Forms.Button();
            this.SubmitBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ReGetBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ViewModule)).BeginInit();
            this.ControlPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // StartBtn
            // 
            this.StartBtn.Location = new System.Drawing.Point(13, 13);
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
            this.DrawPanel.Location = new System.Drawing.Point(13, 42);
            this.DrawPanel.Name = "DrawPanel";
            this.DrawPanel.Size = new System.Drawing.Size(682, 396);
            this.DrawPanel.TabIndex = 2;
            // 
            // FileNameContent
            // 
            this.FileNameContent.AutoSize = true;
            this.FileNameContent.Location = new System.Drawing.Point(241, 16);
            this.FileNameContent.Name = "FileNameContent";
            this.FileNameContent.Size = new System.Drawing.Size(68, 17);
            this.FileNameContent.TabIndex = 4;
            this.FileNameContent.Text = "未开始录制";
            // 
            // DataWriteTip
            // 
            this.DataWriteTip.AutoSize = true;
            this.DataWriteTip.Location = new System.Drawing.Point(501, 16);
            this.DataWriteTip.Name = "DataWriteTip";
            this.DataWriteTip.Size = new System.Drawing.Size(56, 17);
            this.DataWriteTip.TabIndex = 5;
            this.DataWriteTip.Text = "等待录制";
            // 
            // IsSaveFile
            // 
            this.IsSaveFile.AutoSize = true;
            this.IsSaveFile.Location = new System.Drawing.Point(160, 15);
            this.IsSaveFile.Name = "IsSaveFile";
            this.IsSaveFile.Size = new System.Drawing.Size(78, 21);
            this.IsSaveFile.TabIndex = 6;
            this.IsSaveFile.Text = "保存文件:";
            this.IsSaveFile.UseVisualStyleBackColor = true;
            // 
            // ControlPanel
            // 
            this.ControlPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ControlPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ControlPanel.Controls.Add(this.SimpleComplexBox);
            this.ControlPanel.Controls.Add(this.SampleRateBox);
            this.ControlPanel.Controls.Add(this.ReGetBtn);
            this.ControlPanel.Controls.Add(this.ResetBtn);
            this.ControlPanel.Controls.Add(this.SubmitBtn);
            this.ControlPanel.Controls.Add(this.label1);
            this.ControlPanel.Location = new System.Drawing.Point(701, 42);
            this.ControlPanel.Name = "ControlPanel";
            this.ControlPanel.Size = new System.Drawing.Size(261, 396);
            this.ControlPanel.TabIndex = 7;
            // 
            // SimpleComplexBox
            // 
            this.SimpleComplexBox.AutoSize = true;
            this.SimpleComplexBox.Location = new System.Drawing.Point(14, 60);
            this.SimpleComplexBox.Name = "SimpleComplexBox";
            this.SimpleComplexBox.Size = new System.Drawing.Size(169, 21);
            this.SimpleComplexBox.TabIndex = 3;
            this.SimpleComplexBox.Text = "Simple ComplexNumber";
            this.SimpleComplexBox.UseVisualStyleBackColor = true;
            // 
            // SampleRateBox
            // 
            this.SampleRateBox.Location = new System.Drawing.Point(14, 31);
            this.SampleRateBox.Name = "SampleRateBox";
            this.SampleRateBox.Size = new System.Drawing.Size(109, 23);
            this.SampleRateBox.TabIndex = 2;
            // 
            // ResetBtn
            // 
            this.ResetBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ResetBtn.Location = new System.Drawing.Point(94, 363);
            this.ResetBtn.Name = "ResetBtn";
            this.ResetBtn.Size = new System.Drawing.Size(75, 23);
            this.ResetBtn.TabIndex = 1;
            this.ResetBtn.Text = "Reset";
            this.ResetBtn.UseVisualStyleBackColor = true;
            this.ResetBtn.Click += new System.EventHandler(this.ResetBtn_Click);
            // 
            // SubmitBtn
            // 
            this.SubmitBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SubmitBtn.Location = new System.Drawing.Point(175, 363);
            this.SubmitBtn.Name = "SubmitBtn";
            this.SubmitBtn.Size = new System.Drawing.Size(75, 23);
            this.SubmitBtn.TabIndex = 1;
            this.SubmitBtn.Text = "Submit";
            this.SubmitBtn.UseVisualStyleBackColor = true;
            this.SubmitBtn.Click += new System.EventHandler(this.SubmitBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "SampleRate";
            // 
            // ReGetBtn
            // 
            this.ReGetBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ReGetBtn.Location = new System.Drawing.Point(13, 363);
            this.ReGetBtn.Name = "ReGetBtn";
            this.ReGetBtn.Size = new System.Drawing.Size(75, 23);
            this.ReGetBtn.TabIndex = 1;
            this.ReGetBtn.Text = "ReGet";
            this.ReGetBtn.UseVisualStyleBackColor = true;
            this.ReGetBtn.Click += new System.EventHandler(this.ReGetBtn_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 450);
            this.Controls.Add(this.ControlPanel);
            this.Controls.Add(this.IsSaveFile);
            this.Controls.Add(this.DataWriteTip);
            this.Controls.Add(this.FileNameContent);
            this.Controls.Add(this.DrawPanel);
            this.Controls.Add(this.StartBtn);
            this.Name = "MainWindow";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.ViewModule)).EndInit();
            this.ControlPanel.ResumeLayout(false);
            this.ControlPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartBtn;
        private System.Windows.Forms.Panel DrawPanel;
        private System.Windows.Forms.Label FileNameContent;
        private System.Windows.Forms.Label DataWriteTip;
        private System.Windows.Forms.CheckBox IsSaveFile;
        private System.Windows.Forms.BindingSource ViewModule;
        private System.Windows.Forms.Panel ControlPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox SampleRateBox;
        private System.Windows.Forms.Button ResetBtn;
        private System.Windows.Forms.Button SubmitBtn;
        private System.Windows.Forms.CheckBox SimpleComplexBox;
        private System.Windows.Forms.Button ReGetBtn;
    }
}

