
using System;

namespace Homework2
{
    class Program
    {
        static void Main()
        {
        }
    }

    public class Greeter : IGreetThee
    {
        public void SayHelloTo(string name)
        {
            if(name == null)
                throw new ArgumentNullException();
            else
                Console.WriteLine("Hello, "+name);
        }
    }
}
