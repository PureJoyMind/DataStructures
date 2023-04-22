
using System;

namespace DataStructures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var stack = new Stack(10);

            stack.Push("mazdak");
            stack.Push(DateTime.Today);

            stack.PrintStack();

            Console.WriteLine(stack.Pop());
            stack.PrintStack();

        }
    }
}
