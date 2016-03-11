
using System;

namespace Homework2
{
    class Program
    {
        static void Main()
        {
        }
    }

    public class Greeter : IGreetThee.IGreetThee
    {
        void IGreetThee.IGreetThee.SayHelloTo(string name)
        {
            Console.WriteLine("Hello, "+name);
        }
    }
}
