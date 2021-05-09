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
using NAudio.CoreAudioApi;
using NAudio.Dsp;
using NAudio.Wave;

namespace AudioVisualizer
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();

            capture = new WasapiLoopbackCapture();
            capture.DataAvailable += SaveSamples;
            capture.DataAvailable += WriteFrame;

            DrawPanel.Resize += DrawPanel_Resize;
            DrawPanel.Paint += RenderFrame;

            Timer timer = new Timer();
            timer.Interval = 15;
            timer.Tick += ProcessFrame;
            timer.Tick += RenderFrame;
            timer.Start();

            bitsPerSample = capture.WaveFormat.BitsPerSample;
            sampleRate = capture.WaveFormat.SampleRate;
            channelCount = capture.WaveFormat.Channels;
        }

        WaveFileWriter writer;

        WasapiCapture capture;
        BufferedGraphics bufferedGraphics;

        double multiple = 1;
        int bitsPerSample;
        int sampleRate;
        int channelCount;

        double frequencyPerIndex;
        float[] Samples;           // 保存的样本
        double[] DftData;          // 

        object SamplesLock = new object();
        object DftDataLock = new object();

        bool recording = false;    // 是否正在录制


        /// <summary>
        /// 将 WasapiCapture 所捕捉到的数据转换为样本保存到数组
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveSamples(object sender, WaveInEventArgs e)
        {
            if (e.BytesRecorded == 0)
                return;
            int bytesPerSample = bitsPerSample / 8;
            lock (SamplesLock)
                Samples = Enumerable
                              .Range(0, e.BytesRecorded / 4)
                              .Select(i => BitConverter.ToSingle(e.Buffer, i * 4)).ToArray();   // 获取采样
        }

        /// <summary>
        /// 将录制的数据写入到保存到文件或流
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WriteFrame(object sender, WaveInEventArgs e)
        {
            writer?.Write(e.Buffer, 0, e.BytesRecorded);
        }

        /// <summary>
        /// 当 Panel 尺寸变更时, 重新分配 BufferedGraphics
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// 从 double 中平滑的取得一个值
        /// 例如 curve[0] = 0, curve[1] = 100, 那么通过此方法访问 curve[0.5], 可得到 50
        /// </summary>
        /// <param name="curve"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        double IndexCurvePoint(double[] curve, double index)
        {
            int
                floor = (int)Math.Min(Math.Floor(index), curve.Length - 1),
                ceiling = (int)Math.Min(Math.Ceiling(index), curve.Length - 1);
            if (floor == ceiling)
                return curve[floor];
            double
                left = curve[floor],
                right = curve[ceiling];
            return left + (right - left) * (index - floor);
        }

        /// <summary>
        /// 从 double 中平滑的获取一个值
        /// 索引以百分比的形式指定, 基本原理时调用 GetCurvePoint
        /// </summary>
        /// <param name="sequence"></param>
        /// <param name="percent"></param>
        /// <returns></returns>
        double GetCurvePoint(double[] sequence, double percent)
        {
            return IndexCurvePoint(sequence, percent * sequence.Length);
        }

        /// <summary>
        /// 根据 DftData, 将频谱绘制到窗体
        /// </summary>
        /// <param name="s"></param>
        /// <param name="args"></param>
        private void RenderFrame(object s, EventArgs args)
        {
            if (bufferedGraphics == null || bufferedGraphics.Graphics == null)
                bufferedGraphics = BufferedGraphicsManager.Current.Allocate(DrawPanel.CreateGraphics(), DrawPanel.ClientRectangle);
            if (DftData == null)
                return;
            lock (DftDataLock)
            {
                int hz2500index = (int)(2500d / frequencyPerIndex);
                double[] resultPaint = DftData.Take(hz2500index).ToArray();
                Graphics g = bufferedGraphics.Graphics;
                g.Clear(DrawPanel.BackColor);
                float 
                    dataRight = resultPaint.Length,
                    panelRight = DrawPanel.Width,
                    panelHeight = DrawPanel.Height;
                PointF[] points = Enumerable.Range(0, resultPaint.Length).Select(i =>
                        new PointF((int)(i / dataRight * panelRight), panelHeight - (float)resultPaint[i]))
                    .ToArray();
                g.DrawCurve(Pens.Purple, points, 1);
                bufferedGraphics.Render();
            }
        }

        /// <summary>
        /// 根据 Samples, 将采样进行傅里叶变换以求得 DftData
        /// </summary>
        /// <param name="s"></param>
        /// <param name="args"></param>
        private void ProcessFrame(object s, EventArgs args)
        {
            if (Samples == null)
                return;
            float[][] chanelSamples;
            lock (SamplesLock)
                chanelSamples = Enumerable
                    .Range(0, channelCount).Select(i => Enumerable
                        .Range(0, Samples.Length / channelCount)

                        .Select(j => Samples[i + j * 2])
                        .ToArray())
                    .ToArray();
            float[] chanelAverageSamples = Enumerable
                .Range(0, chanelSamples[0].Length)
                .Select(i => Enumerable
                    .Range(0, channelCount)
                    .Select(j => chanelSamples[j][i])
                    .Average())
                .ToArray();

            float[] sampleSrc = chanelAverageSamples;
            int log = (int)Math.Floor(Math.Log(sampleSrc.Length, 2));
            float[] filledSamples = new float[(int)Math.Pow(2, log)];
            Array.Copy(sampleSrc, filledSamples, Math.Min(sampleSrc.Length, filledSamples.Length));   // 填充数据
            Complex[] complexSrc = filledSamples.Select((v, i) => new Complex() { X = v }).ToArray();
            FastFourierTransform.FFT(false, log, complexSrc);     // 进行傅里叶变换
            double[] result = complexSrc.Select(v => Math.Sqrt(v.X * v.X + v.Y * v.Y)).ToArray();    // 取得结果
            double[] reresult = result.Take(result.Length / 2).ToArray();                            // 取一半

            frequencyPerIndex = (double)sampleRate / filledSamples.Length;
            UpdateDftData(reresult, 0.8, 0.5);
        }

        /// <summary>
        /// 平滑的更新 DftData
        /// </summary>
        /// <param name="newData"></param>
        /// <param name="upParam"></param>
        /// <param name="downParam"></param>
        /// <returns></returns>
        private double[] UpdateDftData(double[] newData, double upParam = 1, double downParam = 1)
        {
            if (DftData == null)
                return DftData = newData.Select(v => v * upParam).ToArray();
            lock (DftDataLock)
            {
                try
                {
                    return DftData = newData.Select((v, i) =>
                    {
                        double lastData = GetCurvePoint(DftData, (double)i / newData.Length);
                        double incre = v - lastData;
                        return lastData + incre * (incre > 0 ? upParam : downParam);
                    }).ToArray();
                }
                catch (IndexOutOfRangeException)
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// 开始与暂停
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartStopBtn_Click(object sender, EventArgs e)
        {
            if (recording)
            {
                if (capture.CaptureState != NAudio.CoreAudioApi.CaptureState.Capturing)
                    return;
                if (writer != null)
                    writer.Close();
                capture.StopRecording();
                IsSaveFile.Enabled = true;
                if (IsSaveFile.Checked)
                    FileNameContent.Text += "(已保存)";

                (sender as Button).Text = "Start";
            }
            else
            {
                if (capture.CaptureState == NAudio.CoreAudioApi.CaptureState.Capturing)
                    return;
                if (bufferedGraphics == null)
                    bufferedGraphics = BufferedGraphicsManager.Current.Allocate(DrawPanel.CreateGraphics(), DrawPanel.ClientRectangle);
                if (IsSaveFile.Checked)
                {
                    string filename = Path.GetFileName(Path.GetRandomFileName()) + ".wav";
                    writer = new WaveFileWriter(filename, capture.WaveFormat);
                    FileNameContent.Text = filename;
                }
                capture.StartRecording();
                IsSaveFile.Enabled = false;

                (sender as Button).Text = "Stop";
            }

            recording ^= true;
        }

        private void SubmitBtn_Click(object sender, EventArgs e)
        {
            if (int.TryParse(SampleRateBox.Text, out int result))
                SampleRateBox.Text = (sampleRate = result).ToString();
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            SampleRateBox.Text = (sampleRate = capture.WaveFormat.SampleRate).ToString();
        }

        private void ReGetBtn_Click(object sender, EventArgs e)
        {
            SampleRateBox.Text = sampleRate.ToString();
        }
    }
}
