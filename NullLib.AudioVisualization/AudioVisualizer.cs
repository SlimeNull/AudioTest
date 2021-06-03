using System;
using System.IO;
using System.Linq;
using NAudio.CoreAudioApi;
using NAudio.Wave;

namespace NullLib.AudioVisualization
{
    public class AudioVisualizer
    {
        private int currentDataLen;
        private float[][] currentData;
        private MemoryStream bufferToStorage;
        private bool listening;
        private float upwardAcceleration;
        private float downwardAcceleration;

        private int channelCount;
        private readonly int bytesPerSample;
        private readonly Func<byte[], int, float> sampleConverter;
        private readonly System.Timers.Timer timer;

        public WasapiCapture Capture { get; private set; }

        public bool Listening { get => listening; }
        public CaptureState CaptureState { get => Capture.CaptureState; }
        public float UpwardAcceleration
        {
            get => upwardAcceleration; set
            {
                if (value < 0 || value > 1)
                    throw new ArgumentOutOfRangeException(nameof(value), "Must between 0 and 1.");
                upwardAcceleration = value;
            }
        }
        public float DownwardAcceleration
        {
            get => downwardAcceleration; set
            {
                if (value < 0 || value > 1)
                    throw new ArgumentOutOfRangeException(nameof(value), "Must between 0 and 1.");
                downwardAcceleration = value;
            }
        }
        public double RefreshInterval { get => timer.Interval; set => timer.Interval = value; }

        public AudioVisualizer(WasapiCapture capture)
        {
            if (capture is null)
                throw new ArgumentNullException(nameof(capture));
            Capture = capture;

            WaveFormat format = capture.WaveFormat;
            channelCount = format.Channels;

            bufferToStorage = new MemoryStream();
            timer = new System.Timers.Timer()
            {
                Interval = 15
            };
            currentData = new float[capture.WaveFormat.Channels][];

            timer.Elapsed += (sender, e) => RefreshBuffer();
            timer.Elapsed += (sender, e) => OnDataAvailable();

            switch (format.BitsPerSample)
            {
                case 8:
                    bytesPerSample = 1;
                    sampleConverter = (bytes, offset) => bytes[offset];
                    break;
                case 16:
                    bytesPerSample = 2;
                    sampleConverter = (bytes, offset) => BitConverter.ToInt16(bytes, offset);
                    break;
                case 32:
                    bytesPerSample = 4;
                    sampleConverter = BitConverter.ToSingle;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(capture), "Unsupported wave format");
            }

        }
        public AudioVisualizer() : this(new WasapiLoopbackCapture()) { }
        ~AudioVisualizer()
        {
            bufferToStorage.Dispose();
            timer.Dispose();
        }


        public void StartCapture()
        {
            Capture.StartRecording();
        }
        public void StopCapture()
        {
            Capture.StopRecording();
        }
        public void StartListen()
        {
            Capture.DataAvailable += CaptureDataAvailable;
            timer.Start();
        }
        public void StopListen()
        {
            Capture.DataAvailable -= CaptureDataAvailable;
            timer.Stop();
        }

        private void OnDataAvailable()
        {
            //DataAvailable?.Invoke(this, new AudioVisualizerDataAvailableEventArgs(currentData, currentDataLen, ));
        }

        private void RefreshBuffer()
        {
            int newDataSeqLen = (int)bufferToStorage.Length;
            byte[] newDataBuffer = bufferToStorage.GetBuffer();
            float[] allSamples = Enumerable
                .Range(0, newDataSeqLen / bytesPerSample)
                .Select(i => sampleConverter.Invoke(newDataBuffer, i * bytesPerSample))
                .ToArray();
            float[][] newDataSeqs = Enumerable
                .Range(0, channelCount)
                .Select(off => Enumerable
                    .Range(0, allSamples.Length / channelCount)
                    .Select(i => allSamples[i * channelCount + off])
                    .ToArray())
                .ToArray();

            for (int i = 0, end0 = newDataSeqs.Length; i < end0; i++)
            {
                float[]
                    oldData = currentData[i],
                    newData = newDataSeqs[i];
                int
                    oldDataLen = oldData.Length,
                    newDataLen = newData.Length;
                currentDataLen = newDataLen;
                for (int j = 0; j < newDataLen; j++)
                {
                    float
                        oldValue = oldData[(int)((float)j / newDataLen * oldDataLen)],
                        newValue = newData[j];
                    float finalValue = newValue > oldValue ?
                        oldValue + (newValue - oldValue) * upwardAcceleration :
                        oldValue + (newValue - oldValue) * downwardAcceleration;
                    newData[j] = finalValue;
                }
            }
        }

        private void CaptureDataAvailable(object sender, WaveInEventArgs e)
        {
            bufferToStorage.SetLength(0);
            bufferToStorage.Write(e.Buffer, 0, e.BytesRecorded);
        }

        public event EventHandler<AudioVisualizerDataAvailableEventArgs> DataAvailable;
    }
    public class AudioVisualizerDataAvailableEventArgs
    {
        public float[][] ChannelSamples { get; }
        public int SampleCount { get; }
        public int FrequencyPerData { get; }

        public AudioVisualizerDataAvailableEventArgs(float[][] samples, int count, int fpd)
        {
            ChannelSamples = samples;
            SampleCount = count;
            FrequencyPerData = fpd;
        }
    }
}
