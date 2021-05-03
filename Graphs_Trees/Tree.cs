using System;

namespace Graphs_Trees
{
    public class Tree
    {
        private const int Alphabet = 26;
        private readonly Node _root;

        public Tree()
        {
            _root = new Node("");
        }

        // Returns true if inserted, false if word was already there
        public bool Insert(string word)
        {
            word = word.ToLower();
            var current = _root;
            var changed = false;
            for (var i = 0; i < word.Length; i++)
            {
                for (var j = 0; j < Alphabet; j++)
                {
                    var children = current.Children;
                    if (children[j] is null)
                    {
                        children[j] = new Node(word.Substring(0, i + 1));
                        current = children[j];
                        changed = true;
                        break;
                    }

                    if (children[j].Val.StartsWith(word.Substring(0, i + 1)))
                    {
                        current = children[j];
                        break;
                    }
                }
            }

            return changed;
        }

        public bool Contains(string word)
        {
            word = word.ToLower();
            var current = _root.Children;
            for (var i = 0; i < word.Length; i++)
            {
                for (var j = 0; j < Alphabet; j++)
                {
                    if (current[j] is null) return false;
                    if (current[j].Val == word.Substring(0, i + 1))
                    {
                        if (i == word.Length - 1) return true;
                        current = current[j].Children;
                        break;
                    }
                }
            }

            return false;
        }

        class Node
        {
            public readonly string Val;
            public readonly Node[] Children;

            public Node(string val)
            {
                Val = val;
                Children = new Node[26];
            }
        }
    }
}