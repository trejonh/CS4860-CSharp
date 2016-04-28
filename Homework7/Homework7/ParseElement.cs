using System;

namespace Homework7
{
     public class ParseElement
    {
         public virtual string Parse(byte[] buffer)
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
