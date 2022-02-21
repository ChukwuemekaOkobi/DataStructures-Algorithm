using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Trees
{
    public class TrieWithHashMap
    {
        public NodeHashMap Root;

        public TrieWithHashMap()
        {
            Root = new NodeHashMap(' ');
        }

        public void Insert(string word)
        {
            var current = Root;
            foreach (var ch in word)
            {

                if (!current.HasChild(ch))
                {
                    current.AddNode(ch);
                }
                current = current.GetChild(ch);

            }
            current.IsEndOfWord = true;
        }

        public bool Contains(string word)
        {
            if (string.IsNullOrWhiteSpace(word))
            {
                return false;
            }
            var current = Root;

            foreach (var ch in word)
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

        public void PreTraverse()
        {
            PreTraverse(Root);
        }

        private void PreTraverse(NodeHashMap node)
        {

            Console.WriteLine(node.Value);

            foreach (var child in node.GetChildren())
            {
                PreTraverse(child);
            }
        }

        public void Remove(string word)
        {
            if (string.IsNullOrWhiteSpace(word))
            {
                return;
            }
            Remove(Root, word, 0);
        }


        private void Remove(NodeHashMap node, string word, int index)
        {

            if (index == word.Length)
            {
                node.IsEndOfWord = false;
                return;
            }

            var ch = word.ElementAt(index);

            var child = node.GetChild(ch);

            if (child is null)
            {
                return;
            }

            Remove(child, word, index + 1);

            if (!child.HasChildren() && !child.IsEndOfWord)
            {
                node.RemoveChild(ch);
            }


        }


        public List<string> AutoComplete(string prefix)
        {

            var list = new List<string>();

            var lastNode = FindLastNodeOfPrefix(prefix); 

            FindWords(lastNode, prefix, list);

            return list;
        }


        private void FindWords(NodeHashMap node, string prefix, List<string> words)
        {
            if(node is null)
            {
                return;
            }
   

            if (node.IsEndOfWord)
            {
                words.Add(prefix);
            }

            foreach(var child in node.GetChildren())
            {
                FindWords(child, prefix + child.Value, words); 
            }
 
        }

        private NodeHashMap FindLastNodeOfPrefix (string prefix)
        {
            if(prefix is null)
            {
                return null;
            }
            var current = Root; 
            
            foreach(var ch in prefix)
            {
                if (current.HasChild(ch))
                {
                    var child = current.GetChild(ch);
                    current = child;
                }
               
            }

            return current; 
        }

    }


    public class NodeHashMap
    {
        public char Value { get; private set; }

        private readonly Dictionary<char,NodeHashMap> Children;

        public bool IsEndOfWord;

        public NodeHashMap(char item)
        {
            Value = item;

            Children = new Dictionary<char, NodeHashMap>(); 
        }
        public void AddNode(char ch)
        {
            Children.Add(ch, new NodeHashMap(ch));
        }
        public NodeHashMap GetChild(char ch)
        {
            return Children[ch];
        }

        public bool HasChild(char ch)
        {
            return Children.ContainsKey(ch);
        }

        public List<NodeHashMap> GetChildren()
        {
            return Children.Values.ToList();
        }

        public bool HasChildren()
        {
            return Children.Count != 0;
        }

        public void RemoveChild(char ch)
        {
            Children.Remove(ch);
        }
        public override string ToString()
        {
            return $"Value {Value}";
        }
    }
}

