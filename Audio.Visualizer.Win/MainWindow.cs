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
using Audio.Visualizer.Win;
using NAudio.Wave;

namespace AudioVisualizer
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();

            DrawPanel.Resize += ReallocBuffer;

            capture = new WasapiLoopbackCapture(WasapiLoopbackCapture.GetDefaultLoopbackCaptureDevice());
            capture.DataAvailable += DrawFrame;
            //capture.DataAvailable += WriteFrame;
        }

        WasapiLoopbackCapture capture;
        BufferedGraphics bufferedGraphics;
        private void ReallocBuffer(object sender, EventArgs e)
        {
            if (bufferedGraphics != null)
                bufferedGraphics.Dispose();
            bufferedGraphics = BufferedGraphicsManager.Current.Allocate(DrawPanel.CreateGraphics(), DrawPanel.ClientRectangle);
        }

        double multiple = 4;
        private void DrawFrame(object sender, WaveInEventArgs e)
        {
            if (bufferedGraphics == null)
                return;
            Graphics buf = bufferedGraphics.Graphics;
            buf.Clear(DrawPanel.BackColor);

            int sampleRate = (sender as WasapiLoopbackCapture).WaveFormat.SampleRate;
            float[] samples = Enumerable.Range(0, e.BytesRecorded / 4).Select(i => BitConverter.ToSingle(e.Buffer, i * 4)).ToArray();
            NAudio.Dsp.Complex[] complexSrc = samples.Select((v, i) => new NAudio.Dsp.Complex()
            {
                //X = i / sampleRate,
                //Y = v
                X = (float)(Math.Cos(i / (double)sampleRate * Math.PI * 2) * v),
                Y = (float)(Math.Sin(i / (double)sampleRate * Math.PI * 2) * v)
            }).ToArray();
            int dataEnd = (int)Math.Log(complexSrc.Length, 2);
            NAudio.Dsp.FastFourierTransform.FFT(false, dataEnd, complexSrc);
            double[] sts = complexSrc.Select(v => Math.Sqrt(v.X * v.X + v.Y * v.Y)).ToArray();
            double max = sts.Max();
            int x = 0;

            int dataLen = (int)Math.Pow(2, dataEnd);
            for (int end = DrawPanel.Width; x < end; x++)
            {
                double data = sts[(int)(x / (float)end * dataLen)];
                int y = (int)(data * multiple);
                buf.DrawLine(Pens.Black, new Point(x, 0), new Point(x, y));
            }
            bufferedGraphics.Render();
        }

        void NFFT(ref double[] samples) => MathNet.Numerics.IntegralTransforms.Fourier.ForwardReal(samples, samples.Length);

        private void WriteFrame(object sender, WaveInEventArgs e)
        {
            if (writer != null)
                writer.Write(e.Buffer, 0, e.BytesRecorded);
        }

        WaveFileWriter writer;
        private void StartBtn_Click(object sender, EventArgs e)
        {
            if (bufferedGraphics == null)
                bufferedGraphics = BufferedGraphicsManager.Current.Allocate(DrawPanel.CreateGraphics(), DrawPanel.ClientRectangle);
            //if (writer != null)
            //    writer.Close();
            //string filename = Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + ".wav";
            //writer = new WaveFileWriter(filename, capture.WaveFormat);
            //FileNameContent.Text = filename;
            capture.StartRecording();
        }
        private void StopBtn_Click(object sender, EventArgs e)
        {
            capture.StopRecording();
            //writer.Flush();
            FileNameContent.Text = "录制已停止";
        }
    }
}
