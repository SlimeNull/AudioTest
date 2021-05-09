using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Null.MciPlayer;
using Null.Library;
using System.Reflection;
using System.Runtime.InteropServices;
using NullLib.HttpWebHelper;
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
using NAudio.Wave.Asio;
using NAudio.Wave.SampleProviders;
using NAudio.Wave.Compression;

namespace TestConsole
{
    class Program
    {
        static MciPlayer player;
        static Type playerType = typeof(MciPlayer);
        [DllImport("winmm.dll", EntryPoint = "mciSendString", CharSet = CharSet.Unicode)]
        extern static int MciSendString(string command, string buffer, int bufferSize, IntPtr callback);
        static void RunCmd(string cmd)
        {
            string errorInfo = string.Empty;
            List<string> commandLine = ConsArgsSplitter.Split(cmd);
            if (commandLine.Count > 0)
            {
                MethodInfo info = playerType.GetMethod(commandLine[0]);
                if (info == null)
                {
                    errorInfo = "No such method.";
                    goto ErrorEnd;
                }

                ParameterInfo[] paramInfos = info.GetParameters();
                if (paramInfos.Length != paramInfos.Length)
                {
                    errorInfo = "Parameter count not equal.";
                }
            }

            ErrorEnd:
            {
                Console.WriteLine($"Error, Bad call. {errorInfo}");
                return;
            }
            NormalEnd:
            {
                return;
            }
        }
        static void Main(string[] args)
        {
            MediaFoundationReader reader = new MediaFoundationReader(@"C:\Users\Null\Desktop\Disconnected - Pegboard Nerds.mp3");
            WaveOut wout = new WaveOut();
            wout.Init(reader);
            wout.Play();

            Console.Write("Input file path: ");
            player = new MciPlayer(Console.ReadLine().Trim('"'));
            player.Open();
            player.Play();

            MciSendString($"set {player.AliasName} time format msf", null, 0, IntPtr.Zero);
            Console.WriteLine($"Device Alias Name: {player.AliasName}");
            Console.WriteLine($"Length: {player.GetLength()}; Position: {player.GetPosition()}");

            string rst = new string('\0', 256);
            string before = string.Copy(rst);
            int err;
            while (true)
            {
                if ((err = MciSendString(Console.ReadLine(), rst, rst.Length, IntPtr.Zero)) != 0)
                {
                    Console.WriteLine($"Execute failed. {new MciException(err)}");
                }
                if (rst != before)
                {
                    Console.WriteLine($"Return text: {rst.TrimEnd('\0')}");
                    rst = new string('\0', 256);
                    before = string.Copy(rst);
                }
            }
        }
    }
}
