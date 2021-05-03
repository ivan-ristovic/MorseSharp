using System;
using System.IO;
using System.Media;
using System.Text;

namespace MorseSharp
{
    public static class AudioPlayer
    {
        public static void PlayBeep(ushort frequency, int msDuration, ushort volume = 16383)
        {
            using var ms = new MemoryStream();
            using var writer = new BinaryWriter(ms);

            int formatChunkSize = 16;
            int headerSize = 8;
            short formatType = 1;
            short tracks = 1;
            int samplesPerSecond = 44100;
            short bitsPerSample = 16;
            short frameSize = (short)(tracks * ((bitsPerSample + 7) / 8));
            int bytesPerSecond = samplesPerSecond * frameSize;
            int waveSize = 4;
            int samples = (int)((decimal)samplesPerSecond * msDuration / 1000);
            int dataChunkSize = samples * frameSize;
            int fileSize = waveSize + headerSize + formatChunkSize + headerSize + dataChunkSize;
            
            writer.Write(Encoding.UTF8.GetBytes("RIFF"));
            writer.Write(fileSize);
            writer.Write(Encoding.UTF8.GetBytes("WAVE"));
            writer.Write(Encoding.UTF8.GetBytes("fmt "));
            writer.Write(formatChunkSize);
            writer.Write(formatType);
            writer.Write(tracks);
            writer.Write(samplesPerSecond);
            writer.Write(bytesPerSecond);
            writer.Write(frameSize);
            writer.Write(bitsPerSample);
            writer.Write(Encoding.UTF8.GetBytes("data"));
            writer.Write(dataChunkSize);
            {
                double theta = frequency * 2 * Math.PI / samplesPerSecond;
                // 'volume' is UInt16 with range 0 thru Uint16.MaxValue ( = 65 535)
                // we need 'amp' to have the range of 0 thru Int16.MaxValue ( = 32 767)
                double amp = volume >> 2; // so we simply set amp = volume / 2
                for (int step = 0; step < samples; step++) {
                    short s = (short)(amp * Math.Sin(theta * step));
                    writer.Write(s);
                }
            }

            ms.Seek(0, SeekOrigin.Begin);

#pragma warning disable CA1416 // Validate platform compatibility
            using (var mp = new SoundPlayer(ms))
                mp.Play();
#pragma warning restore CA1416 // Validate platform compatibility
        }
    }
}
