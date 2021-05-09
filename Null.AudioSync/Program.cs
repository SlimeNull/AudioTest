using System;
using System.Net;
using System.Collections.Generic;
using NAudio.Wave;
using Null.AudioSync.Model;
using NullLib.EventedSocket;
using NullLib.ArgsAnalysis;
using NullLib.ArgsAnalysis.Analyzers;

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
                EventedListener listener = new EventedListener(IPAddress.Any, port);
                List<EventedClient> clients = new List<EventedClient>();
                try
                {
                    listener.Start();
                }
                catch(Exception e)
                {
                    ErrorExit(-1, $"{e.GetType().Name}: {e.Message}");
                }
                listener.StartAcceptClient();
                listener.ClientConnected += (s, args) =>
                {
                    lock (clients)
                    {
                        EventedClient client = args.Client;
                        clients.Add(client);
                        Console.WriteLine($"Client connected: {client.BaseSocket.RemoteEndPoint}");
                    }
                };
                capture.DataAvailable += (sender, args) =>
                {
                    lock (clients)
                    {
                        List<EventedClient> clientsToRemove = new List<EventedClient>();
                        foreach (var client in clients)
                        {
                            try
                            {
                                client.SendData(args.Buffer, 0, args.BytesRecorded);
                            }
                            catch
                            {
                                clientsToRemove.Add(client);
                                Console.WriteLine($"Client disconnected: {client.BaseSocket.RemoteEndPoint}");
                            }
                        }
                        foreach (var client in clientsToRemove)
                            clients.Remove(client);
                    }
                };
                capture.StartRecording();

                Console.WriteLine("Syncing audio as host...");
                while (capture.CaptureState != NAudio.CoreAudioApi.CaptureState.Stopped) ;
            }
            else if (args.Sync)
            {
                if (!TryGetAddress(args.Address, out IPAddress address))
                    ErrorExit(-1, "Invalid address specified.");
                if (!int.TryParse(args.Port, out int port) || port < 0)
                    ErrorExit(-1, "Invalid port specified.");
                EventedClient client = new EventedClient();
                try
                {
                    client.Connect(address, port);
                }
                catch
                {
                    ErrorExit(-2, "Cannot connect to host");
                }
                NetSampleProvider src = new NetSampleProvider(client);
                client.StartReceiveData();
                WaveOut wout = new WaveOut();
                wout.Init(src);
                wout.Play();

                Console.WriteLine("Syncing audio as client...");
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
