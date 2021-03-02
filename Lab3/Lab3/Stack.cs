using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    public class Stack<T>
    {
        private T[] array;
        private const int defaultSize = 32;
        private int freePos = 0;
        public int Length { get => freePos; }

        public Stack()
        {
            array = new T[defaultSize];
        }

        public void Push(T element)
        {
            if (freePos == array.Length)
            {
                Expand();
            }
            array[freePos] = element;
            freePos++;
        }

        private void Expand()
        {
            T[] newArray = new T[array.Length * 2];
            Array.Copy(array, newArray, array.Length);
            array = newArray;
        }

        public T Pop()
        {
            if (freePos == 0)
            {
                throw new InvalidOperationException("Trying to pop an element from an empty stack");
            }
            freePos--;
            return array[freePos];
        }

        public T Peek()
        {
            if (freePos == 0)
            {
                throw new InvalidOperationException("Trying to peek at an empty stack");
            }
            return array[freePos - 1];
        }

        public void Clear()
        {
            freePos = 0;
        }
    }
}
