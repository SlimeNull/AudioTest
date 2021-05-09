using System;
using NAudio;
using NAudio.Wave;
using NAudio.Codecs;
using NAudio.CoreAudioApi;
using NAudio.FileFormats;
using NAudio.MediaFoundation;
using NAudio.Midi;
using NAudio.Dsp;
using NAudio.Utils;
using NAudio.SoundFont;
using NAudio.Dmo;
using System.Linq;

namespace NAudioRecordTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var reader = new Mp3FileReader(@"C:\Users\Null\Desktop\Disconnected - Pegboard Nerds.mp3");
            WaveFileWriter.CreateWaveFile(@"C:\Users\Null\Desktop\Disconnected - Pegboard Nerds.wav", reader);
            //// WaveFileReader waveFileReader = new WaveFileReader("");
            //WaveOut wout = new WaveOut();

            //wout.Init(reader);
            //wout.Play();
            //Console.ReadLine();
            
            //new StreamMediaFoundationReader();
            var cap = new WasapiCapture();
            //var cap = new WasapiLoopbackCapture();
            //var cap = new WaveInEvent();
            WaveFileWriter writer = new WaveFileWriter("output.wav", cap.WaveFormat);
            
            cap.DataAvailable += (s, args) =>
            {
                float waveHeight = Enumerable
                                       .Range(0, args.BytesRecorded / 32)
                                       .Select(i => BitConverter.ToSingle(args.Buffer, i * 32))
                                       .Aggregate((v1, v2) => v1 > v2 ? v1 : v2);
                writer.Write(args.Buffer, 0, args.BytesRecorded);
                Console.WriteLine($"BufferSize:{args.Buffer.Length}, Recorded:{args.BytesRecorded}");
            };
            cap.StartRecording();
            Console.WriteLine("录制已开始, 按Enter结束");
            ConsoleKey key;
            do
            {
                key = Console.ReadKey(true).Key;
            }
            while (key != ConsoleKey.Enter);
            cap.StopRecording();
            writer.Close();
            Console.WriteLine("录制结束");
            Console.ReadLine();
        }
    }
}
