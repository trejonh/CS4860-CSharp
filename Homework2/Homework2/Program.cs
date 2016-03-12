
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
            Console.WriteLine("Hello, "+name);
        }
    }
}
