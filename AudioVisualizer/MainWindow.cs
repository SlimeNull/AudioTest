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
using NAudio.Dsp;
using NAudio.Wave;

namespace AudioVisualizer
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();

            capture = new WasapiLoopbackCapture(WasapiLoopbackCapture.GetDefaultLoopbackCaptureDevice());
            capture.DataAvailable += DrawFrame;
            //capture.DataAvailable += WriteFrame;

            DrawPanel.Resize += DrawPanel_Resize;
        }

        private void DrawPanel_Resize(object sender, EventArgs e)
        {
            if (bufferedGraphics == null)
                return;
            lock (bufferedGraphics)
            {
                bufferedGraphics.Dispose();
                bufferedGraphics = null;
            }
        }

        WasapiLoopbackCapture capture;
        BufferedGraphics bufferedGraphics;

        double multiple = 1;
        int sampleRate => capture.WaveFormat.SampleRate;
        private void DrawFrame(object s, WaveInEventArgs args)
        {
            if (bufferedGraphics == null || bufferedGraphics.Graphics == null)
                bufferedGraphics = BufferedGraphicsManager.Current.Allocate(DrawPanel.CreateGraphics(), DrawPanel.ClientRectangle);
            lock (bufferedGraphics)
            {
                if (args.BytesRecorded == 0)
                    return;
                Graphics buf = bufferedGraphics.Graphics;
                float[] samples = Enumerable
                                      .Range(0, args.BytesRecorded / 4)
                                      .Select(i => BitConverter.ToSingle(args.Buffer, i * 4)).ToArray();   // 获取采样

                int log = (int)Math.Ceiling(Math.Log(samples.Length, 2));
                float[] filledSamples = new float[(int)Math.Pow(2, log)];
                Array.Copy(samples, filledSamples, samples.Length);   // 填充数据

                Complex[] complexSrc = filledSamples.Select((v, i) =>
                {
                    double deg = i / (double)sampleRate * Math.PI * 2;                  // 获取当前采样率在圆上对应的角度 (弧度制)
                    return new Complex()
                    {
                        X = (float)(Math.Cos(deg) * v),
                        Y = (float)(Math.Sin(deg) * v)
                    };
                }).ToArray();                                                   // 将采样转换为对应的复数 (缠绕到圆)

                FastFourierTransform.FFT(false, log, complexSrc);     // 进行傅里叶变换
                double[] result = complexSrc.Select(v => Math.Sqrt(v.X * v.X + v.Y * v.Y)).ToArray();    // 取得结果

                buf.Clear(DrawPanel.BackColor);
                for (int i = 1, right = DrawPanel.Width; i < right; i++)
                {
                    Point p1 = new Point(i - 1, DrawPanel.Height - (int)(result[(int)((i - 1d) / right * result.Length)] * multiple));
                    Point p2 = new Point(i, DrawPanel.Height - (int)(result[(int)((double)i / right * result.Length)] * multiple));
                    buf.DrawLine(Pens.Purple, p1, p2);
                }

                bufferedGraphics.Render();
            }
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
            if (capture.CaptureState == NAudio.CoreAudioApi.CaptureState.Capturing)
                return;
            if (bufferedGraphics == null)
                bufferedGraphics = BufferedGraphicsManager.Current.Allocate(DrawPanel.CreateGraphics(), DrawPanel.ClientRectangle);
            //string filename = Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + ".wav";
            //writer = new WaveFileWriter(filename, capture.WaveFormat);
            //FileNameContent.Text = filename;
            capture.StartRecording();
        }
        private void StopBtn_Click(object sender, EventArgs e)
        {
            if (capture.CaptureState != NAudio.CoreAudioApi.CaptureState.Capturing)
                return;
            capture.StopRecording();
            //writer.Close();
        }
    }
}
