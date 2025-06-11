using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System;
using NAudio.Wave;

namespace Madu
{
    // Класс Sounds для проигрывания звуков
    public class Sounds
    {   

        private IWavePlayer waveOut;
        private AudioFileReader reader;

        public void PlaySound(string filePath, bool loop = false)
        {
            Stop(); // Остановим предыдущий звук, если есть
            if (!System.IO.File.Exists(filePath))
            {
                throw new System.IO.FileNotFoundException($"Файл не найден: {filePath}");
            }

            waveOut = new WaveOutEvent();
            reader = new AudioFileReader(filePath);

            if (loop)
            {
                var loopStream = new LoopStream(reader); // Зацикленный поток
                waveOut.Init(loopStream);
            }
            else
            {
                waveOut.Init(reader);
            }

            waveOut.Play();
        }

        public void Stop()
        {
            waveOut?.Stop();
            waveOut?.Dispose();
            reader?.Dispose();
            waveOut = null;
            reader = null;
        }
    }


    // Класс для зацикливания аудио
    public class LoopStream : WaveStream
    {
        private readonly WaveStream _sourceStream;

        public LoopStream(WaveStream source)
        {
            _sourceStream = source;
            EnableLooping = true;
        }

        public bool EnableLooping { get; set; }

        public override WaveFormat WaveFormat => _sourceStream.WaveFormat;
        public override long Length => _sourceStream.Length;

        public override long Position
        {
            get => _sourceStream.Position;
            set => _sourceStream.Position = value;
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            int totalBytesRead = 0;

            while (totalBytesRead < count)
            {
                int bytesRead = _sourceStream.Read(buffer, offset + totalBytesRead, count - totalBytesRead);
                if (bytesRead == 0)
                {
                    if (_sourceStream.Position == 0 || !EnableLooping)
                        break;

                    _sourceStream.Position = 0;
                }

                totalBytesRead += bytesRead;
            }

            return totalBytesRead;
        }
    }
}
