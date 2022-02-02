using System.Collections.Generic;

namespace DSAProblems.DataStructures.Tree.Tries
{
    /*
     * 1. Insert
     * 2. Look-up
     * 3. Remove
     * 4. Prefix Counter
     * 5. Unique words
     * 6. Words with same prefix
     * 7. Remove words with same prefix
     * 8. kth word
     * 9. Validate character sequence
     * 10. Generics
     * 11. Suggestions and Auto-Completion
     * 12. Longest common prefix

     */
    public class TrieNode
    {
        public Dictionary<char, TrieNode> Children { get; }
        public bool IsEndOfWord { get; internal set; } //indicates whether a TrieNode corresponds to the last character of a word
        public int PrefixCount { get; internal set; }
        public int EndsWithCount { get; internal set; }
        public string Value { get; }
        public TrieNode(string prefix)
        {
            Value = prefix;
            Children = new Dictionary<char, TrieNode>();
        }
    }

    public class TrieWithDictionary
    {
        private readonly TrieNode root;

        public TrieNode Root => root;

        public TrieWithDictionary()
        {
            root = new TrieNode("");
        }

        public void Insert(string word)
        {
            TrieNode current = root;
            for (int i = 0; i < word.Length; i++)
            {
                char key = word[i];
                if (!current.Children.ContainsKey(key))
                    current.Children.Add(key, new TrieNode(current.Value + key));
                current = current.Children[key];
                current.PrefixCount += 1;
            }
            current.IsEndOfWord = true;
            current.EndsWithCount += 1;
        }

        public bool Search(string word)
        {
            TrieNode current = root;
            foreach (char ch in word)
            {
                if (!current.Children.TryGetValue(ch, out TrieNode node))
                    return false;
                current = node;
            }
            return current.IsEndOfWord;
        }

        public bool StartsWith(string prefix)
        {
            TrieNode current = root;
            foreach (char ch in prefix)
            {
                if (!current.Children.TryGetValue(ch, out TrieNode node))
                    return false;
                current = node;
            }
            return true;
        }

        public int CountWordsStartingWith(string prefix)
        {
            TrieNode current = root;
            foreach (char ch in prefix)
            {
                if (!current.Children.TryGetValue(ch, out TrieNode node))
                    return 0;

                current = node;
            }
            return current.PrefixCount;
        }

        public int CountWordsEqualTo(string word)
        {
            TrieNode current = root;
            foreach (char ch in word)
            {
                if (!current.Children.TryGetValue(ch, out TrieNode node))
                    return 0;
                current = node;
            }
            return current.EndsWithCount;
        }

        /*
         For the deletion process, we need to follow the steps:

            1. Check whether this element is already part of the trie
            2. If the element is found, then remove it from the trie
            The complexity of this algorithm is O(n), where n represents the length of the key 
        */
        public void Delete(string word)
        {
            Delete(root, word, 0);
        }

        private bool Delete(TrieNode current, string word, int index)
        {
            if(index == word.Length)
            {
                //when end of word is reached only delete if currrent.endOfWord is true.
                if (!current.IsEndOfWord)
                    return false;
                current.IsEndOfWord = false;
                //if current has no other mapping then return true
                return current.Children.Count == 0;
            }
            char ch = word[index];
            if(!current.Children.ContainsKey(ch))
                return false;
            TrieNode node = current.Children[ch];
            bool shouldDeleteCurrentNode = Delete(node, word, index + 1);
            if (shouldDeleteCurrentNode)
            {
                current.Children.Remove(ch);
                return current.Children.Count == 0;
            }
            return false;
        }

        public List<string> GetWordsWithGivenPrefixDfs(string prefix)
        {
            List<string> results = new List<string>();
            TrieNode current = root;
            foreach (char ch in prefix)
            {
                if (!current.Children.ContainsKey(ch))
                    return results;
                current = current.Children[ch];
            }
            return DFS(current);
        }

        public List<string> GetWordsWithGivenPrefixBfs(string prefix)
        {
            TrieNode current = root;
            foreach (char ch in prefix)
            {
                if (!current.Children.ContainsKey(ch))
                    return new List<string>();
                current = current.Children[ch];
            }

            List<string> results = new List<string>();
            Queue<TrieNode> queue = new Queue<TrieNode>();
            queue.Enqueue(current);

            while (queue.Count > 0)
            {
                TrieNode first = queue.Dequeue();
                if (first.IsEndOfWord)
                    results.Add(first.Value);
                foreach (var child in first.Children)
                    queue.Enqueue(child.Value);
            }

            return results;
        }

        private List<string> DFS(TrieNode trieNode)
        {
            List<string> results = new List<string>();
            if (trieNode.IsEndOfWord)
                results.Add(trieNode.Value);
            foreach (KeyValuePair<char, TrieNode> kv in trieNode.Children)
                results.AddRange(DFS(kv.Value));
            return results;
        }
    }
}
