using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Trees
{
    /// <summary>
    /// Tries Useing Array
    /// </summary>
    public class Trie
    {
        public Node Root;

        public Trie()
        {
            Root = new Node(' ');
        }

        public void Insert(string word)
        {
            var current = Root;
            foreach(var ch in word)
            {
                    if (!current.HasChild(ch))
                    {
                      current.AddNode(ch);
                    }
                current = current.GetChild(ch);
             
            }
            current.IsEndOfWord = true; 
        }

        public bool Contains (string word)
        {
            if (string.IsNullOrWhiteSpace(word))
            {
                return false;
            }
            var current = Root;

            foreach(var ch in word)
            {
                if (!current.HasChild(ch))
                {
                    return false;
                }
                current = current.GetChild(ch);
            }

            if (!current.IsEndOfWord)
            {
                return false;
            }

            return true; 
        }
    }


    public class Node
    {
        public char Value { get; private set; }

        private readonly Node[] Children;

        private const int NodeLength = 26;

        public bool IsEndOfWord;

        public Node(char item)
        {
            Value = item;

            Children = new Node[NodeLength];
        }

        public void AddNode(char ch)
        {
            int index = ch - 'a';
            Children[index] = new Node(ch); 
        }
        public Node GetChild(char ch)
        {
            int index = ch - 'a';
            return Children[index];
        }
        
        public bool HasChild(char ch)
        {
            int index = ch - 'a';
            return Children[index] != null; 
        }


        public override string ToString()
        {
            return $"Value {Value}";
        }
    }

}
