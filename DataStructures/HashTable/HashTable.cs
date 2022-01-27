using DataStructures.LinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.HashTable
{
    /// <summary>
    /// HashTable equivalent of a dictionary in C# 
    /// using array, and Linkedlist to implement value 
    /// chaining for collisions
    /// </summary>
    public class HashTable
    {
        readonly LinkedList<KeyValuePair>[] Items;

        public int Count { get; private set; }

        private const int length = 10;

        public HashTable()
        {
            Items = new LinkedList<KeyValuePair>[length];
        }

        public void Put(int key, string value)
        {
            int index = HashFunction(key);

            if (Items[index] == null)
            {
                Items[index] = new LinkedList<KeyValuePair>();
            }
       
            foreach(var keyvalue in Items[index])
            {
                if(keyvalue.Key == key)
                {
                    keyvalue.Value = value;
                    return;
                }
            }

            Items[index].AddLast(new KeyValuePair(key, value));

            Count++;

        }

        public string Get(int key)
        {
            int index = HashFunction(key);

            var keyvalue = Find(Items[index], key);
            if (keyvalue != null)
            {
                return keyvalue.Value;
            }
            return null;
        }

        public void Remove(int key)
        {
            int index = HashFunction(key);

            var keyvalue = Find(Items[index], key);
            if (keyvalue != null)
            {
                Items[index].Remove(keyvalue);
                Count--;
            }
        }

        private KeyValuePair Find(LinkedList<KeyValuePair> items, int key)
        {
            if (items != null)
            {
                foreach (var keyvalue in items)
                {
                    if (keyvalue.Key == key)
                    {
                        return keyvalue;
                    }
                }
            }

            return null;
        }
        private static int HashFunction(int key)
        {
            return key % length;
        }



    }

    public class KeyValuePair
    {
        public int Key { get; private set; }
        public string Value { get; set; }
        public KeyValuePair(int key, string value)
        {
            Key = key;
            Value = value;
        }
    }
}
