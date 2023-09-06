using System;

namespace DataStructures
{
    public class Stack
    {
        private object[] items;
        private int top;

        public Stack(int capacity)
        {
            items = new object[capacity];
            top = -1;
        }

        public void Push(object item)
        {
            
            if (top == items.Length - 1)
            {
                throw new StackOverflowException();
            }

            top++;
            items[top] = item;
        }

        public object Pop()
        {
            if (top == -1)
            {
                throw new InvalidOperationException("Cannot pop empty stack!");
            }

            var item = items[top];
            top--;
            Console.Write("Popped ");
            return item;
        }

        public void Clear()
        {
            top = -1;
            Console.WriteLine("Cleared stack!");
        }

        public void PrintStack()
        {
            Console.WriteLine("\nStack Items:");
            if (top == -1)
            {
                Console.WriteLine("Stack is empty");
                return;
            }

            //Console.Write("Stack: ");
            for (int i = 0; i <= top; i++)
            {
                Console.Write($"Item no.{i + 1} ");
                Console.WriteLine(items[i] + " ");
            }
            Console.WriteLine();
        }

        public static void StackImplementation() // Create an instance of this
                                     // class for the method to work.
        {
            var s = new Stack(5);
            s.Push("mazdak");
            s.Push(DateTime.Today);
            s.Push(5);

            s.PrintStack();

            Console.WriteLine(s.Pop());

            s.Clear();

            s.PrintStack();

            //this.Pop();
        }
    }
}