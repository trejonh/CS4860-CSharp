using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Homework9
{
    public class StreamProcessor : IReportStatus
    {
        private readonly Stream _memStream;
        public long RecordsProcessed { get; private set; }
        public long BytesProcessed { get; private set; }
        public TimeSpan TotalProcessingTime { get; private set; } = TimeSpan.Zero;

        public TimeSpan AverageProcessingTime
        {
            get { return RecordsProcessed != 0 ? new TimeSpan(TotalProcessingTime.Ticks/RecordsProcessed) : TotalProcessingTime; }
        }

        public event Action<int> ElementProcessed;
        public event Action<int> ErrorEncountered;
        public StreamProcessor():this(null)
        {
        }

        public StreamProcessor(Stream stream)
        {
            _memStream = stream;
        }

        public void ProcessStream()
        {
            if (!_memStream.CanRead || _memStream == null || _memStream.Length == 0)
                return;
            while (true)
            {
                var type = _memStream.ReadByte();
                if (type == -1)
                    break;
                var startTime = Stopwatch.GetTimestamp();
                BytesProcessed++;
                if (type == 0x01)
                    ParseLittleInt(startTime);
                else
                    TypeMismatch(type,startTime);
                RecordsProcessed++;

            }
        }

        private void ParseLittleInt(long startTime)
        {
            var expectedLength = _memStream.ReadByte();
            if (expectedLength == -1)
            {
                TotalProcessingTime =  new TimeSpan(Stopwatch.GetTimestamp()-startTime);
                return;
            }
            BytesProcessed++;
            if (expectedLength > 4 || expectedLength < 1)
            {
                BytesProcessed += expectedLength;
                try
                {
                    _memStream.Position += expectedLength;
                }
                catch (Exception)
                {
                    // ignored
                }
                finally
                {
                    TotalProcessingTime = new TimeSpan(Stopwatch.GetTimestamp() - startTime);
                }
                return;
            }
            var toProcess = new byte[expectedLength];
            _memStream.Read(toProcess, 0, expectedLength);
            BytesProcessed += expectedLength;
            if(!BitConverter.IsLittleEndian)
                Array.Reverse(toProcess);
            var processedInt = ConvertInt(expectedLength, toProcess);
            TotalProcessingTime = new TimeSpan(Stopwatch.GetTimestamp() - startTime);
            OnElementProcessed(processedInt);
        }

        private void TypeMismatch(int type,long startTime)
        {
            OnErrorEncountered(type);
            var len = _memStream.ReadByte();
            if (len == -1)
                return;
            BytesProcessed += len+1;
            try
            {
                _memStream.Position += len;
            }
            catch (Exception)
            {
                //Since we parsed an illegal element
                //we need to move the position past the
                //point of that illegal data
                //which can throw an error if we go past the stream
                //length in which case we are done
            }
            finally
            {
                TotalProcessingTime = new TimeSpan(Stopwatch.GetTimestamp() - startTime);
            }
        }

        private int ConvertInt(int length, byte[] buffer)
        {
            if (length<4)
                buffer = buffer.Concat(new Byte[4]).ToArray();
            return BitConverter.ToInt32(buffer, 0);/*
            switch (length)
            {
                case 1:
                    return buffer[0];
                case 2:
                    return BitConverter.ToInt16(buffer, 0);
                case 3:
                    var num = buffer[0] + (buffer[1] << 8) + (buffer[2] << 16);
                    return num;
                default:
                    return BitConverter.ToInt32(buffer, 0);
            }*/
        }
        protected virtual void OnElementProcessed(int processed)
        {
            ElementProcessed?.Invoke(processed);
        }

        protected virtual void OnErrorEncountered(int errorType)
        {
            ErrorEncountered?.Invoke( errorType);
        }
    }
}
