using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;

namespace AudioVisualizer
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();

            DrawPanel.Resize += DrawPanel_Resize;

            capture = new WasapiLoopbackCapture(WasapiLoopbackCapture.GetDefaultLoopbackCaptureDevice());
            capture.DataAvailable += DrawFrame;
            capture.DataAvailable += WriteFrame;
        }

        WasapiLoopbackCapture capture;
        BufferedGraphics bufferedGraphics;
        private void DrawPanel_Resize(object sender, EventArgs e)
        {
            if (bufferedGraphics != null)
                bufferedGraphics.Dispose();
            bufferedGraphics = BufferedGraphicsManager.Current.Allocate(DrawPanel.Handle, new Rectangle(Point.Empty, DrawPanel.Size));
        }
        private void DrawFrame(object sender, WaveInEventArgs e)
        {
            if (bufferedGraphics == null)
                return;
            Graphics buf = bufferedGraphics.Graphics;
            buf.Clear(DrawPanel.BackColor);
            for (int i = 0, end = e.BytesRecorded; i < end; i++)
                buf.DrawLine(Pens.Black, new Point((int)(i / (double)end * DrawPanel.Width), 0), new Point((int)(i / (double)end * DrawPanel.Width), e.Buffer[i] / 255 * DrawPanel.Height));
            buf.Flush();
        }

        private void WriteFrame(object sender, WaveInEventArgs e)
        {
            if (writer != null)
                writer.Write(e.Buffer, 0, e.BytesRecorded);
            this.Invoke((Action)(() => DataWriteTip.Text = $"Data wrote:Size.{e.BytesRecorded}"));
        }

        WaveFileWriter writer;
        private void StartBtn_Click(object sender, EventArgs e)
        {
            if (bufferedGraphics == null)
                bufferedGraphics = BufferedGraphicsManager.Current.Allocate(DrawPanel.Handle, DrawPanel.ClientRectangle);
            string filename = Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + ".wav";
            writer = new WaveFileWriter(filename, capture.WaveFormat);
            FileNameContent.Text = filename;
            capture.StartRecording();
        }
        private void StopBtn_Click(object sender, EventArgs e)
        {
            capture.StopRecording();
            writer.Close();
        }
    }
}
