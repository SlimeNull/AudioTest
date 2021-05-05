using NAudio.Wave;
using Null.AudioSync.Model;
using NullLib.ArgsAnalysis;
using NullLib.ArgsAnalysis.Analyzers;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

namespace Null.AudioSync
{
    class Program
    {
        static void Main(string[] sysargs)
        {
            WaveFormat format = WaveFormat.CreateIeeeFloatWaveFormat(1000000, 2);
            StartupArgs args = Initialize(sysargs);
            if (args.Host)
            {
                if (!int.TryParse(args.Port, out int port) || port < 0)
                    ErrorExit(-1, "Invalid port specified.");

                using WasapiLoopbackCapture capture = new WasapiLoopbackCapture();
                TcpListener listener = new TcpListener(IPAddress.Any, port);
                List<WaveFileWriter> clients = new List<WaveFileWriter>();
                listener.Start();
                listener.BeginAcceptTcpClient((rst) =>
                {
                    lock (clients)
                    {
                        clients.Add(new WaveFileWriter(listener.EndAcceptTcpClient(rst).GetStream(), format));
                    }
                }, null);
                capture.DataAvailable += (sender, args) =>
                {
                    lock (clients)
                    {
                        Queue<WaveFileWriter> clientsToRemove = new Queue<WaveFileWriter>();
                        foreach (var client in clients)
                        {
                            try
                            {
                                client.WriteAsync(args.Buffer, 0, args.BytesRecorded)
                                    .ContinueWith((task) => client.FlushAsync());
                            }
                            catch
                            {
                                clientsToRemove.Enqueue(client);
                            }
                        }
                        foreach (var client in clientsToRemove)
                        {
                            try
                            {
                                client.Close();
                            }
                            catch { }
                            clients.Remove(client);
                        }
                    }
                };
                capture.StartRecording();
                while (capture.CaptureState != NAudio.CoreAudioApi.CaptureState.Stopped) ;
            }
            else if (args.Sync)
            {
                if (!TryGetAddress(args.Address, out IPAddress address))
                    ErrorExit(-1, "Invalid address specified.");
                if (!int.TryParse(args.Port, out int port) || port < 0)
                    ErrorExit(-1, "Invalid port specified.");
                TcpClient client = new TcpClient();
                client.Connect(address, port);
                StreamMediaFoundationReader reader = new StreamMediaFoundationReader(client.GetStream());
                WaveOut wout = new WaveOut();
                wout.Init(reader);
                wout.Play();
                while (wout.PlaybackState != PlaybackState.Stopped) ;
            }
            else if (args.Help)
            {
                Console.WriteLine(
$@"Null.AudioSync : Sync audio with another computer
  Null.AudioSync Command Arguments
    Commands:
      Host : Build a AudioSync server.
      Sync : Connect a AudioSync server.
    Arguments:
      Address : Should be specified when SyncAudio from a server.
      Port    : Port will be listened or connected. default is 10001.
");
            }
            else
            {
                Console.WriteLine("Unknown command, use 'Null.AudioSync Help' for help");
            }
        }
        static StartupArgs Initialize(string[] sysargs)
        {
            NArgsAnalyzer analyzer = new NArgsAnalyzer()
            {
                new CommandAnalyzer()
                {
                    new SwitchAnalyzer(),
                    new FieldAnalyzer(),
                },
            };

            analyzer.IgnoreCases = true;
            analyzer.Analysis(sysargs);

            return analyzer.ToObject<StartupArgs>();
        }
        static void ErrorExit(int exitCode, string msg)
        {
            Console.WriteLine(msg);
            Environment.Exit(exitCode);
        }
        static bool TryGetAddress(string addstr, out IPAddress address)
        {
            address = null;
            try
            {
                IPAddress[] addresses = Dns.GetHostAddresses(addstr);
                if (addresses == null)
                    return false;
                if (addresses.Length < 1)
                    return false;
                address = addresses[0];
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
