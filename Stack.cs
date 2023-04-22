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

        public void Implementation() // Create an instance of this
                                     // class for the method to work.
        {
            this.Push("mazdak");
            this.Push(DateTime.Today);
            this.Push(5);

            this.PrintStack();

            Console.WriteLine(this.Pop());

            this.Clear();

            this.PrintStack();

            //this.Pop();
        }
    }
}