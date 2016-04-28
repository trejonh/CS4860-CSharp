using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Homework7
{
    public class StreamProcessor : IReportStatus
    {
        private Stream stream;
        /*
        *I chose to implicitly implement the IReportStatus
        *interface. I went this route because i didnt want 
        *to hide this implementation from clients/childs
        *explicitly implementing the interface would make 
        *the following fields private which i think would 
        *lose the purpose for a reporter. and i wanted to 
        *explicity implemented these fields but still make
        *the data available then it would only create more 
        *work for me. Furthermore interfaces are thought of 
        * to be 'contracts' which are to be public.
        */
        public long RecordsProcessed { get; set; }
        public long BytesProcessed { get; set; }

        public TimeSpan TotalProcessingTime { get; set; }
        public TimeSpan AverageProcessingTime { get; set; }
        public StreamProcessor(Stream stream)
        {
            this.stream = stream;
            RecordsProcessed = 0;
            BytesProcessed = 0;
        }
        public List<String> ProcessStream()
        {
            ParseElement strP = new StringElement(), litP = new LittleEndianIntegerElement(), bigP = new BigEndianIntegerElement();
            const byte  str = 0x03, lit = 0x01, big = 0x02;
            var decoded = new List<string>();
            if (stream == null)
            {
                decoded.Add(null);
                TotalProcessingTime = new TimeSpan(0);
                AverageProcessingTime = new TimeSpan(0);
                return decoded;
            }
            else if (stream.Length == 0)
            {
                decoded.Add("");
                TotalProcessingTime = new TimeSpan(0);
                AverageProcessingTime = new TimeSpan(0);
                return decoded;
            }
            var timer = new Stopwatch();
            long ticks = 0;
            int readByte = 0;
            /*
            *I start my timing once i find a chunk of bytes
            *that my application is made to handle i.e. strings
            *little/big endian ints; then i time how long it
            *takes to read in those bytes and convert them
            *so i start timing before i get the size byte and stop
            *timing after conversion. i do it this way since the stream
            *is potentially infinite so we cant time and infinite stream
            *but we can time the time it takes to process chunks of data
            *in that stream
            */
            while (readByte != -1)
            {
                readByte = stream.ReadByte();
                if (readByte != -1)
                    BytesProcessed++;
                else
                    break;
                switch (readByte)
                {
                    case lit:
                        timer.Start();
                        readByte = stream.ReadByte();
                        BytesProcessed++;
                        if (readByte != -1)
                        {
                            var littleEndian = new byte[readByte];
                            for (int i = 0; i < littleEndian.Length; i++)
                            {
                                readByte = stream.ReadByte();
                                BytesProcessed++;
                                if (readByte != -1 && readByte != str && readByte != lit && readByte != big)
                                {
                                    littleEndian[i] = (byte) readByte;
                                }
                                else
                                    break;
                            }
                            timer.Stop();
                            ticks += timer.ElapsedTicks;
                            TotalProcessingTime = new TimeSpan(ticks);
                            timer.Reset();
                            decoded.Add(litP.Parse(littleEndian));
                            RecordsProcessed++;
                            AverageProcessingTime = new TimeSpan(TotalProcessingTime.Ticks/RecordsProcessed);
                        }
                        break;
                    case big:
                        timer.Start();
                        readByte = stream.ReadByte();
                        BytesProcessed++;
                        if (readByte != -1)
                        {
                            var bigEndian = new byte[readByte];
                            for (int i = 0; i < bigEndian.Length; i++)
                            {
                                readByte = stream.ReadByte();
                                BytesProcessed++;
                                if (readByte != -1 && readByte != str && readByte != lit && readByte != big)
                                {
                                    bigEndian[i] = (byte) readByte;
                                }
                                else
                                    break;
                            }
                            timer.Stop();
                            ticks += timer.ElapsedTicks;
                            TotalProcessingTime = new TimeSpan(ticks);
                            timer.Reset();
                            decoded.Add(bigP.Parse(bigEndian));
                            RecordsProcessed++;
                            AverageProcessingTime = new TimeSpan(TotalProcessingTime.Ticks / RecordsProcessed);
                        }
                        break;
                    case str:
                        timer.Start();
                        readByte = stream.ReadByte();
                        BytesProcessed++;
                        if (readByte != -1)
                        {
                            var notNullStr = new byte[readByte];
                            int expectedLen = readByte;
                            for (int i = 0; i < notNullStr.Length; i++)
                            {
                                readByte = stream.ReadByte();
                                BytesProcessed++;
                                if (readByte != -1 && readByte != str && readByte != lit && readByte != big)
                                {
                                    notNullStr[i] = (byte) readByte;
                                    expectedLen --;
                                }
                                else
                                    break;
                            }
                            if (expectedLen == 0)
                            {
                                decoded.Add(strP.Parse(notNullStr));
                                RecordsProcessed++;
                            }
                            timer.Stop();
                            ticks += timer.ElapsedTicks;
                            TotalProcessingTime = new TimeSpan(ticks);
                            timer.Reset();
                            AverageProcessingTime = new TimeSpan(TotalProcessingTime.Ticks / RecordsProcessed);
                        }
                        break;
                    default:
                        if (readByte != -1)
                            BytesProcessed++;
                        break;
                }
            }
            return decoded;
        } 
    }
}
