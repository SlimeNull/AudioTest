using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AudioVisualizer.ViewModule;
using NAudio.CoreAudioApi;
using NAudio.Dsp;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace AudioVisualizer
{
    public partial class MainWindow : Form
    {
        public MainWindowModule ViewModule;

        public MainWindow()
        {
            InitializeComponent();
            InitializeCapture();

            this.ViewModule = new MainWindowModule();

            DrawPanel.Resize += DrawPanelResize;
            DrawPanel.Paint += RenderPanel;

            Timer timer = new Timer();
            timer.Interval = 15;
            timer.Tick += ProcessFrame;
            //timer.Tick += RefreshPanel;
            timer.Tick += RenderPanel;
            timer.Tick += RefreshOffset;
            timer.Tick += RefreshUIElement;
            timer.Start();

            this.FormClosed += (sender, e) => Application.Exit();
        }
        private void RefreshPanel(object sender, EventArgs e)
        {
            DrawPanel.Invalidate();
            DrawPanel.Update();
        }
        private void InitializeCapture()
        {
            capture?.Dispose();

            capture = new WasapiLoopbackCapture();
            capture.DataAvailable += SaveSamples;
            capture.DataAvailable += WriteFrame;

            bitsPerSample = capture.WaveFormat.BitsPerSample;
            sampleRate = capture.WaveFormat.SampleRate;
            channelCount = capture.WaveFormat.Channels;
        }
        private void ConvertSamples(object sender, EventArgs e)
        {
            if (ViewModule.IsPlaying && reader != null)
            {
                byte[] buffer = new byte[4096 * 4];
                long position = reader.Position;
                int readed = reader.Read(buffer, 0, 4096 * 4);
                reader.Position = position;
                Samples = Enumerable
                    .Range(0, readed / 4)
                    .Select(i => BitConverter.ToSingle(buffer, i * 4))
                    .ToArray();
            }
        }
        private void RefreshUIElement(object sender, EventArgs e)
        {
            //DrawPanel.Enabled = !playing;
            //MusicPlayPanel.Enabled = !recording;
            IsSaveFile.Enabled = !ViewModule.IsRecording;
            StartBtn.Text = ViewModule.IsRecording ? "Stop" : "Start";
        }
        private void RefreshOffset(object sender, EventArgs e)
        {
            if (reader != null && !ViewModule.IsOffseting)
            {
                PlayOffsetBar.Minimum = 0;
                PlayOffsetBar.Maximum = (int)reader.TotalTime.TotalMilliseconds;
                PlayOffsetBar.Value = (int)reader.CurrentTime.TotalMilliseconds;
                CurrentTimeLb.Text = reader.CurrentTime.ToString(@"mm\:ss");
                TotalTimeLb.Text = reader.TotalTime.ToString(@"mm\:ss");
            }
        }

        AudioFileReader reader;
        WaveFileWriter writer;
        OffsetSampleProvider offsetSampleProvider;

        WaveOut wout;

        WasapiCapture capture;
        BufferedGraphics bufferedGraphics;
        Func<float, float> dftDataFilter;

        int bitsPerSample;
        int sampleRate;
        int channelCount;

        double frequencyPerIndex;
        float[] Samples;           // 保存的样本
        double[] DftData;          // 

        object SamplesLock = new object();
        object DftDataLock = new object();

        /// <summary>
        /// 生成一个适用于过滤绘制数据的委托, 它可以压制绘制数据在一定范围内 (原理是激活函数)
        /// </summary>
        /// <param name="xmin">x最小值</param>
        /// <param name="xmax">x最大值</param>
        /// <param name="ymin">y最小值</param>
        /// <param name="ymax">y最大值</param>
        /// <returns></returns>
        private Func<float, float> GenDataFilter(float xmin, float xmax, float ymin, float ymax)
        {
            Func<float, float> sigmoid = (z) => (float)(1f / (1f + Math.Pow(Math.E, (-z))));
            return (num) => (float)(Math.Tanh((num - xmin) / (xmax - xmin) * 2) * (ymax - ymin) + ymin);
        }

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
            if (ViewModule.IsRecording)
                writer?.Write(e.Buffer, 0, e.BytesRecorded);
        }

        /// <summary>
        /// 当 Panel 尺寸变更时, 重新分配 BufferedGraphics
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawPanelResize(object sender, EventArgs e)
        {
            if (bufferedGraphics == null)
                return;
            lock (bufferedGraphics)
            {
                dftDataFilter = null;
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

        Action drawAction;

        /// <summary>
        /// 根据 DftData, 将频谱绘制到窗体
        /// </summary>
        /// <param name="s"></param>
        /// <param name="args"></param>
        private void RenderPanel(object s, EventArgs args)
        {
            if (bufferedGraphics == null || bufferedGraphics.Graphics == null)
                bufferedGraphics = BufferedGraphicsManager.Current.Allocate(DrawPanel.CreateGraphics(), DrawPanel.ClientRectangle);
            if (DftData == null || DftData.Length == 0 || frequencyPerIndex == 0)
                return;
            drawAction ??= MusicCircleVisualDraw;
            lock (DftDataLock)
            {
                bufferedGraphics.Graphics.Clear(DrawPanel.BackColor);
                //DarkerRender(DrawPanel.BackColor);
                //ColorRender(Color.Black, Color.Purple);
                MusicLineVisualDraw();
                MusicCircleVisualDraw();
                bufferedGraphics.Render();
            }
        }

        double darkRate = 0.5;
        private void DarkerRender(Color color)
        {
            Graphics g = bufferedGraphics.Graphics;
            g.FillRectangle(new SolidBrush(Color.FromArgb((int)(255 * darkRate), color.R, color.G, color.B)), DrawPanel.ClientRectangle);
        }

        double maxNow;
        int penWidth = 1;
        private void ColorRender(Color color1, Color color2)
        {
            int fqEndIndex = (int)(circleFrequencyEnd / frequencyPerIndex);
            double[] resultPaint = DftData.Take(fqEndIndex).ToArray();
            Graphics g = bufferedGraphics.Graphics;
            double average = resultPaint.Average();
            if (maxNow < average)
                maxNow = average;
            double light = average / maxNow;
            Pen pen = new Pen(Color.FromArgb((int)(color1.R + (color2.R - color1.R) * light),
                                             (int)(color1.G + (color2.G - color1.G) * light),
                                             (int)(color1.B + (color2.B - color1.B) * light)));
            pen.Width = penWidth;
            Rectangle rect = DrawPanel.ClientRectangle;
            g.DrawLines(pen, new Point[]
            {
                new Point(rect.X, rect.Y),
                new Point(rect.X, rect.Height - 1),
                new Point(rect.Width - 1, rect.Height - 1),
                new Point(rect.Width - 1, rect.Y),
                new Point(rect.X, rect.Y),
            });
        }

        Pen globalDrawPen = Pens.Green;

        float curveMultiple = 1;
        double curveFrequencyEnd = 2500d;
        private void MusicLineVisualDraw()
        {
            int hz2500index = (int)(curveFrequencyEnd / frequencyPerIndex);
            double[] resultPaint = DftData.Take(hz2500index).ToArray();
            Graphics g = bufferedGraphics.Graphics;
            float
                dataRight = resultPaint.Length, panelRight = DrawPanel.Width, panelHeight = DrawPanel.Height;
            dftDataFilter ??= (v) => v;
            PointF[] points = Enumerable.Range(0, resultPaint.Length).Select(i =>
                new PointF(
                    (int)(i / dataRight * panelRight),
                    panelHeight - dftDataFilter((float)resultPaint[i] * curveMultiple)))
                .ToArray();
            g.DrawCurve(globalDrawPen, points, 1);
        }

        float circleMultiple = 0.5f;
        float circleOffsetPerFrame = 0.1f;
        float circleCurOffset = 0;
        double circleFrequencyEnd = 4500d;
        float maxOffset = 10;
        float 
            curOffsetX = 0,
            curOffsetY = 0;
        float offsetSpeed = 0.5f;
        private void MusicCircleVisualDraw()
        {
            int fqEndIndex = (int)(circleFrequencyEnd / frequencyPerIndex);
            double[] resultPaint = DftData.Take(fqEndIndex).ToArray();
            Graphics g = bufferedGraphics.Graphics;
            float
                dataRight = resultPaint.Length, panelRight = DrawPanel.Width, panelHeight = DrawPanel.Height;
            dftDataFilter ??= (v) => v;

            int centerX = DrawPanel.Width / 2,
                centerY = DrawPanel.Height / 2;

            float offsetXPix = curOffsetX, offsetYPix = curOffsetY;
            Point mouse = DrawPanel.PointToClient(MousePosition);

            if (mouse.X > 0 && mouse.Y > 0 && mouse.X < DrawPanel.Width && mouse.Y < DrawPanel.Height || true)
            {
                double
                    halfX = DrawPanel.Width / 2,
                    halfY = DrawPanel.Height / 2;
                double
                    offsetX = (halfX - mouse.X) / halfX * maxOffset,
                    offsetY = (halfY - mouse.Y) / halfY * maxOffset;

                offsetXPix = (int)(curOffsetX + (offsetX - curOffsetX) * offsetSpeed);
                offsetYPix = (int)(curOffsetY + (offsetY - curOffsetY) * offsetSpeed);

                curOffsetX = offsetXPix;
                curOffsetY = offsetYPix;
            }

            if (circleCurOffset > 360)
                circleCurOffset = 0;
            double piOffset = circleCurOffset / 360f * Math.PI * 2;
            double radius = Math.Min(DrawPanel.Width, DrawPanel.Height) / 2d;
            double halfradius = radius / 2;
            double scale = resultPaint.Average() / halfradius / 1 + 1;
            int resultPaintLength = resultPaint.Length;
            PointF[] points = Enumerable.Range(0, resultPaintLength).Select((v) => {
                double deg = (double)v / resultPaintLength * Math.PI * 2 + piOffset,
                    value = dftDataFilter((float)resultPaint[v] * circleMultiple),
                    sin = Math.Sin(deg),
                    cos = Math.Cos(deg);
                PointF p = new PointF(
                    (float)(centerX + halfradius * cos * scale + value * cos) + offsetXPix,
                    (float)(centerY + halfradius * sin * scale + value * sin) + offsetYPix);
                return p;
            }).ToArray();

            circleCurOffset += circleOffsetPerFrame;

            g.DrawClosedCurve(globalDrawPen, points);
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
                    .Range(0, channelCount)
                    .Select(i => Enumerable
                        .Range(0, Samples.Length / channelCount)
                        .Select(j => Samples[i + j * channelCount])
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
            if (DftData == null || DftData.Length == 0)
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
            if (ViewModule.IsRecording)
            {
                if (writer != null)
                    writer.Close();
                capture.StopRecording();
                if (IsSaveFile.Checked)
                    FileNameContent.Text += "(Saved)";
            }
            else
            {
                if (bufferedGraphics == null)
                    bufferedGraphics = BufferedGraphicsManager.Current.Allocate(DrawPanel.CreateGraphics(), DrawPanel.ClientRectangle);
                if (IsSaveFile.Checked)
                {
                    string filename = Path.GetFileName(Path.GetRandomFileName()) + ".wav";
                    writer = new WaveFileWriter(filename, capture.WaveFormat);
                    FileNameContent.Text = filename;
                }
                capture.StartRecording();
            }

            ViewModule.IsRecording ^= true;
        }

        OpenFileDialog ofd;
        private void AddBtn_Click(object sender, EventArgs e)
        {
            ofd ??= new OpenFileDialog()
            {
                Title = "Select a audio file.",
                Multiselect = false,
                Filter = "Audio|*.wav;*.mp3;*.aiff;*.cue|Wave file|*.wav|MPEG3|*.mp3|AIFF|*.aiff|Cue Wave|*.cue",
                CheckFileExists = true,
            };

            if (ofd.ShowDialog().Equals(DialogResult.OK))
                PlayListBox.Items.Add(ofd.FileName);
        }

        private void RemoveBtn_Click(object sender, EventArgs e)
        {
            if (PlayListBox.SelectedIndex >= 0)
                PlayListBox.Items.RemoveAt(PlayListBox.SelectedIndex);
        }

        private void PlayBtn_Click(object sender, EventArgs e)
        {
            if (PlayListBox.SelectedIndex < 0)
                return;
            wout ??= new WaveOut();
            if (MusicNameLb.Text == Path.GetFileNameWithoutExtension(PlayListBox.SelectedItem as string))
            {
                wout.Play();
                wout.Resume();
                return;
            }

            reader?.Dispose();

            reader = new AudioFileReader(PlayListBox.SelectedItem as string);
            offsetSampleProvider = new OffsetSampleProvider(reader);
            wout.Init(offsetSampleProvider);
            wout.Play();

            wout.PlaybackStopped += (sender, e) => MusicNameLb.Text = "";

            MusicNameLb.Text = Path.GetFileNameWithoutExtension(PlayListBox.SelectedItem as string);
            ViewModule.IsPlaying = true;
        }

        private void PlayOffsetBar_MouseDown(object sender, MouseEventArgs e)
        {
            ViewModule.IsOffseting = true;
        }

        private void PlayOffsetBar_MouseUp(object sender, MouseEventArgs e)
        {
            reader.CurrentTime = TimeSpan.FromMilliseconds(PlayOffsetBar.Value);
            ViewModule.IsOffseting = false;
        }

        private void PauseBtn_Click(object sender, EventArgs e)
        {
            wout?.Pause();
        }

        private void StopBtn_Click(object sender, EventArgs e)
        {
            wout?.Stop();
            ViewModule.IsPlaying = false;
        }

        private void RefreshBtn_Click(object sender, EventArgs e) => InitializeCapture();

        private void DrawPanel_MouseClick(object sender, MouseEventArgs e)
        {
            //if (e.Button.HasFlag(MouseButtons.Right))
            //{
            //    contextMenuStrip1.Show();
            //}
        }

        private void contextMenuStrip1_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {

        }

        private void WindowTopMost_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = WindowTopMost.Checked;
        }
    }
}
