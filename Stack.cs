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
            top = 0;
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
            if (top == 0)
            {
                throw new InvalidOperationException();
            }

            var item = items[top];
            top--;
            return item;
        }

        public void Clear()
        {
            top = 0;
        }

        public void PrintStack()
        {
            if (top == 0)
            {
                Console.WriteLine("Stack is empty");
                return;
            }

            Console.Write("Stack: ");
            for (int i = top; i >= 0; i--)
            {
                Console.Write(items[i] + " ");
            }
            Console.WriteLine();
        }
    }
}