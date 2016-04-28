using System;

namespace Homework4
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
