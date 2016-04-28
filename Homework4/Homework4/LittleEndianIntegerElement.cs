using System;

namespace Homework4
{
    class LittleEndianIntegerElement : ParseElement
    {
        public override string Parse(byte[] buffer)
        {
            if(!BitConverter.IsLittleEndian)
                Array.Reverse(buffer);
            try
            {
                return "" + BitConverter.ToInt32(buffer, 0);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
