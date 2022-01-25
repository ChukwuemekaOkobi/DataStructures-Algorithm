using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class Array
    {
        private int[] numbers;

        private int currentIndex = 0;

        public Array(int length)
        {
            numbers = new int[length];
        }

        public void Insert(int item)
        {
            if (currentIndex == numbers.Length)
            {

                int[] newItems = new int[currentIndex * 2];
                for (int i = 0; i < currentIndex; i++)
                {
                    newItems[i] = numbers[i];
                }

                numbers = newItems;
            }

            numbers[currentIndex++] = item;

        }

        public int length()
        {
            return currentIndex;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= currentIndex)
            {
                Console.WriteLine("Index cannot be found");
                return;
            }

            for (int i = index; i < currentIndex - 1; i++)
            {
                numbers[i] = numbers[i + 1];
                numbers[i + 1] = 0;
            }
            currentIndex--;

        }

        public int IndexOf(int number)
        {

            for (int i = 0; i < currentIndex; i++)
            {
                if (numbers[i] == number)
                {
                    return i;
                }
            }
            return -1;
        }

        public int Max()
        {

            int max = 0;
            for (int i = 0; i < currentIndex; i++)
            {
                if (numbers[i] > max)
                {
                    max = numbers[i];
                }
            }

            return max;
        }

        public Array Intersect(int[] items)
        {
            Array newItems = new Array(1);

            for (int i = 0; i < currentIndex; i++)
            {
                foreach (int item in items)
                {
                    if (numbers[i] == item)
                    {
                        newItems.Insert(numbers[i]);
                    }
                }
            }

            return newItems;
        }

        public void Reverse()
        {
            int[] newItems = new int[currentIndex];

            for (int i = 0; i < currentIndex; i++)
            {
                newItems[i] = numbers[currentIndex - (i + 1)];
            }
            numbers = newItems;
        }

        public void InsertAt(int index, int item)
        {
            if (index > currentIndex)
            {
                throw new ArgumentException();
            }
            int[] newItem = new int[++currentIndex];

            int count = 0;
            for (int i = 0; i < currentIndex; i++)
            {
                if (i == index)
                {
                    newItem[i] = item;
                    continue;
                }
                newItem[i] = numbers[count++];
            }
            numbers = newItem;
        }

        public void Print()
        {
            for (int i = 0; i < currentIndex; i++)
            {
                Console.WriteLine("Index" + i + ": " + numbers[i]);
            }
        }
    }
}
