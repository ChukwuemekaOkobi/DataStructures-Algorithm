﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Stacks
{
    public class LinkedListStack
    {
        private readonly SingleLinkedList Items; 

        public LinkedListStack()
        {
            Items = new SingleLinkedList();
        }
        public int Count => Items.Count;
  


        public void Push(int item)
        {
            Items.AddFirst(item);
        }

        public int Pop ()
        {
            if(IsEmpty())
            {
                throw new IndexOutOfRangeException();
            }
            int value = Items.First.Value;
            Items.RemoveFirst();
            return value;
        }
        
        public int Peek()
        {
            if (IsEmpty())
            {
                throw new IndexOutOfRangeException();
            }

            return Items.First.Value; 
        }

        public void Reversed()
        {
            Items.Reverse();
        }
        public bool IsEmpty()
        {
            return Count == 0; 
        }
    }
}
