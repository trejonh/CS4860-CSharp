using System;
using System.Collections.Generic;
using System.IO;

namespace Homework7
{
    public class StreamProcessor
    {
        private Stream stream;
        public StreamProcessor(Stream stream)
        {
            this.stream = stream;
        }
        public List<String> ProcessStream()
        {
            ParseElement strP = new StringElement(), litP = new LittleEndianIntegerElement(), bigP = new BigEndianIntegerElement();
            const byte  str = 0x03, lit = 0x01, big = 0x02;
            List<string> decoded = new List<string>();
            if (stream == null)
            {
                decoded.Add(null);
                return decoded;
            }
            else if (stream.Length == 0)
            {
                decoded.Add("");
                return decoded;
            }
            int bit = 0;
            while (bit != -1)
            {
                bit = stream.ReadByte();
                switch (bit)
                {
                    case lit:
                        bit = stream.ReadByte();
                        if (bit != -1)
                        {
                            byte[] littleEndian = new byte[bit];
                            for (int i = 0; i < littleEndian.Length; i++)
                            {
                                bit = stream.ReadByte();
                                if (bit != -1 && bit != str && bit != lit && bit != big)
                                {
                                    littleEndian[i] = (byte) bit;
                                }
                                else
                                    break;
                            }
                            decoded.Add(litP.Parse(littleEndian));
                        }
                        break;
                    case big:
                        bit = stream.ReadByte();
                        if (bit != -1)
                        {
                            byte[] bigEndian = new byte[bit];
                            for (int i = 0; i < bigEndian.Length; i++)
                            {
                                bit = stream.ReadByte();
                                if (bit != -1 && bit != str && bit != lit && bit != big)
                                {
                                    bigEndian[i] = (byte) bit;
                                }
                                else
                                    break;
                            }
                            decoded.Add(bigP.Parse(bigEndian));
                        }
                        break;
                    case str:
                        bit = stream.ReadByte();
                        if (bit != -1)
                        {
                            byte[] notNullStr = new byte[bit];
                            int expectedLen = bit;
                            for (int i = 0; i < notNullStr.Length; i++)
                            {
                                bit = stream.ReadByte();
                                if (bit != -1 && bit != str && bit != lit && bit != big)
                                {
                                    notNullStr[i] = (byte) bit;
                                    expectedLen --;
                                }
                                else
                                    break;
                            }
                            if(expectedLen==0)
                                decoded.Add(strP.Parse(notNullStr));
                        }
                        break;
                }
            }
            return decoded;
        } 
    }
}
