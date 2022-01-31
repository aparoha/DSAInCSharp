using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProblems.DataStructures.Tree.Tries
{
    public class TrieWithArray
    {
        TrieNode root;

        class TrieNode
        {
            public TrieNode[] children { get; set; }
            public bool isEnd { get; set; }
            public TrieNode()
            {
                children = new TrieNode[26];
            }
        }

        public TrieWithArray()
        {
            root = new TrieNode();
        }

        public void Insert(string word)
        {
            TrieNode current = root;
            foreach (char ch in word)
            {
                TrieNode key = current.children[ch - 'a'];
                if (key == null)
                    current.children[ch - 'a'] = new TrieNode();
                current = current.children[ch - 'a'];
            }
            current.isEnd = true;
        }

        public bool Search(string word)
        {
            TrieNode current = root;
            foreach (char ch in word)
            {
                TrieNode key = current.children[ch - 'a'];
                if (key == null)
                    return false;
                current = key;
            }
            return current.isEnd;
        }

        public bool StartsWith(string prefix)
        {
            TrieNode current = root;
            foreach (char ch in prefix)
            {
                TrieNode key = current.children[ch - 'a'];
                if (key == null)
                    return false;
                current = key;
            }
            return true;
        }
    }
}
