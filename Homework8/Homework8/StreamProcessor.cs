using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Homework8
{
    public class StreamProcessor : IReportStatus , IParse<int>, IParse<string>
    {
        private readonly Stream _memStream;
        private int _bytesRead;
        public long RecordsProcessed { get; private set; }
        public long BytesProcessed { get; private set; }
        public TimeSpan TotalProcessingTime { get; private set; }
        public TimeSpan AverageProcessingTime { get; private set; }
        public StreamProcessor():this(0,0,new TimeSpan(0),new TimeSpan(0))
        {
        }

        public StreamProcessor(Stream stream):this(0, 0, new TimeSpan(0), new TimeSpan(0))
        {
            _memStream = stream;
        }

        private StreamProcessor(int bytesProcessed, int recordsProcessed,TimeSpan totTimeSpan, TimeSpan avgTimeSpan)
        {
            RecordsProcessed = recordsProcessed;
            BytesProcessed = bytesProcessed;
            TotalProcessingTime = totTimeSpan;
            AverageProcessingTime = avgTimeSpan;
        }

        public List<string> ProcessStream()
        {
            if (_memStream == null || _memStream.Length == 0)
                return null;
            var processedStream = new List<string>();
            long ticks = 0;
            var timer = new Stopwatch();
            while (true)
            {
                var type = _memStream.ReadByte();
                if (type == -1)
                    break;
                BytesProcessed++;
                timer.Start();
                var expectedLength = _memStream.ReadByte();
                if (expectedLength == -1)
                    break;
                BytesProcessed++;
                var bytesToParse = ProcessBytes(expectedLength);
                if (_bytesRead != expectedLength)
                    break;
                switch (type)
                {
                    case 0x03:
                        processedStream.Add(((IParse<string>)this).Parse(bytesToParse));
                        break;
                    case 0x01:
                        processedStream.Add(((IParse<int>)this).Parse(bytesToParse).ToString());
                        break;
                }
                timer.Stop();
                RecordsProcessed++;
                ticks += timer.ElapsedTicks;
                TotalProcessingTime = new TimeSpan(ticks);
                timer.Reset();
                AverageProcessingTime = new TimeSpan(TotalProcessingTime.Ticks / RecordsProcessed);

            }
            return processedStream;
        }

        private byte[] ProcessBytes(int length)
        {
            var processedBytes = new byte[length];
            _bytesRead = 0;
            for (int i = 0; i < length; i++)
            {
                var tmp = _memStream.ReadByte();
                if (tmp == -1)
                    break;
                processedBytes[i] = (byte)tmp;
                BytesProcessed++;
                _bytesRead++;
            }
            return processedBytes;
        }

        int IParse<int>.Parse(byte[] buffer)
        {
            if (buffer == null || buffer.Length == 0)
                return 0;
            if (!BitConverter.IsLittleEndian)
                Array.Reverse(buffer);
            try
            {
                return BitConverter.ToInt32(buffer, 0);
            }
            catch (ArgumentException)
            {
                try
                {
                    return BitConverter.ToInt16(buffer, 0);
                }
                catch (ArgumentException)
                {
                    return buffer[0];
                }
            }
        }

        string IParse<string>.Parse(byte[] buffer)
        {
            if (buffer == null || buffer.Length == 0)
                return null;
            else
            {
                try
                {
                    return System.Text.Encoding.ASCII.GetString(buffer);
                }
                catch (Exception)
                {
                    return null;
                }
            }
        } 
    }
}
