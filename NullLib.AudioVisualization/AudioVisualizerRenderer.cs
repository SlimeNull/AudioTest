using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using NAudio.Wave;

namespace NullLib.AudioVisualization
{
    public class AudioVisualizerRenderer
    {
        private int minFrequency = 0;
        private int maxFrequency = 2500;
        private Graphics targetGraphics;
        private Rectangle targetRectangle;
        private int channelIndex = 0;
        private WaveFormat waveFormat;

        public int ChannelIndex { get => channelIndex; set => channelIndex = value; }
        public int MinFrequency
        {
            get => minFrequency; set
            {
                if (value >= maxFrequency)
                    throw new ArgumentOutOfRangeException(nameof(value), "MinFrequency musg be less than MaxFrequency.");
                minFrequency = value;
            }
        }
        public int MaxFrequency
        {
            get => maxFrequency; set
            {
                if (value <= minFrequency)
                    throw new ArgumentOutOfRangeException(nameof(value), "MaxFrequency must be greater than MinFrequency.");
                maxFrequency = value;
            }
        }
        public AudioVisualizer AudioProvider { get; private set; }
        public Graphics TargetGraphics
        {
            get => targetGraphics; set
            {
                if (value is null)
                    throw new ArgumentNullException(nameof(value));
                targetGraphics = value;
            }
        }
        public Rectangle TargetRectangle
        {
            get => targetRectangle; set
            {
                targetRectangle = value;
            }
        }
        public float VerticalStretch { get; set; } = 1;

        public AudioVisualizerRenderer(AudioVisualizer provider)
        {
            if (provider == null)
                throw new ArgumentNullException(nameof(provider));
            AudioProvider = provider;
            waveFormat = provider.Capture.WaveFormat;
        }
        public void StartRender()
        {
            AudioProvider.DataAvailable += AudioProviderDataAvailable;
        }

        private void AudioProviderDataAvailable(object sender, AudioVisualizerDataAvailableEventArgs e)
        {
            RenderFrame(e.ChannelSamples, e.SampleCount);
        }

        public void StopRender()
        {

        }
        public void RenderFrame(float[][] samples, int count)
        {
            
            //int sampleStartIndex = 
        }
    }
}
