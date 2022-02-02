using System.Collections.Generic;

namespace DSAProblems.DataStructures.Tree.Tries
{
    class LC_212_WordSearchII
    {
        public IList<string> FindWords(char[][] board, string[] words)
        {
            List<string> result = new List<string>();
            TrieWithDictionary trie = new TrieWithDictionary();
            foreach (string word in words)
                trie.Insert(word);
            TrieNode root = trie.Root;
            (int, int)[] directions = new (int, int)[] { (-1, 0), (1, 0), (0, -1), (0, 1)};
            int rows = board.Length;
            int columns = board[0].Length;
            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    if (root.Children.ContainsKey(board[row][column]))
                        Dfs(board, row, column, root, directions, result);
                }
            }
            return result;
        }

        private void Dfs(char[][] board, int row, int column, TrieNode current, (int, int)[] directions, List<string> result)
        {
            if (current.IsEndOfWord)
            {
                result.Add(current.Value);
                current.IsEndOfWord = false;
            }
            if (row < 0 || column < 0 || row >= board.Length || column >= board[0].Length || !current.Children.ContainsKey(board[row][column]))
                return;

            var tmp = board[row][column];
            board[row][column] = '0';
            foreach(var direction in directions)
                Dfs(board, row + direction.Item1, column + direction.Item2, current.Children[tmp], directions, result);
            board[row][column] = tmp;
        }
    }
}
