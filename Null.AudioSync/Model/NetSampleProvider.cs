using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NAudio.Wave;
using NullLib.EventedSocket;

namespace Null.AudioSync.Model
{
    public class NetSampleProvider : ISampleProvider
    {
        private Queue<float> buffer;
        private bool disconnected = false;
        public EventedClient Client { get; private set; }

        public WaveFormat WaveFormat { get; set; } = WaveFormat.CreateIeeeFloatWaveFormat(48000, 2);

        public NetSampleProvider(EventedClient client)
        {
            if (client == null)
                throw new ArgumentNullException(nameof(client));
            buffer = new Queue<float>();
            Client = client;
            Client.DataReceived += Client_DataReceived;
            Client.Disconnected += Client_Disconnected;
        }

        private void Client_Disconnected(object sender, ClientDisconnectedEventArgs e)
        {
            disconnected = true;
        }
        ~NetSampleProvider()
        {
            Client.DataReceived -= Client_DataReceived;
            Client.Disconnected -= Client_Disconnected;
        }

        private void Client_DataReceived(object sender, ClientDataReceivedEventArgs e)
        {
            foreach (var sample in
            Enumerable.Range(0, e.Size / 4).Select(i => BitConverter.ToSingle(e.Buffer, i * 4)))
                buffer.Enqueue(sample);
        }

        public int Read(float[] buffer, int offset, int count)
        {
            int index = 0, end = Math.Min(count, this.buffer.Count);
            for (; index < end; index++)
                buffer[index] = this.buffer.Dequeue();
            for (; index < count; index++)
                buffer[index] = 0;
            if (disconnected)
                return end;
            return count;
        }
    }
}
