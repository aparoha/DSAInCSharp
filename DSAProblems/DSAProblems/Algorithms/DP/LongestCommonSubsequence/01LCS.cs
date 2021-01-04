using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProblems.Algorithms.DP.LongestCommonSubsequence
{
    /*
     1.The longest common subsequence (LCS) problem is the problem of finding the longest subsequence common to all sequences in a set of sequences (often just two sequences) 
     2.Unlike substrings, subsequences are not required to occupy consecutive positions within the original sequences. 
     3.It is the basis of data comparison programs such as the diff utility, and has applications in computational linguistics and bioinformatics. 
     4.It is also widely used by revision control systems such as Git for reconciling multiple changes made to a revision-controlled collection of files.

        For example, consider the sequences (ABCD) and (ACBAD). 
        They have 5 length-2 common subsequences: (AB), (AC), (AD), (BD), and (CD); 
        2 length-3 common subsequences: (ABD) and (ACD); 
        So (ABD) and (ACD) are their longest common subsequences.   

     5.For the general case of an arbitrary number of input sequences, the problem is NP-hard.
     6.When the number of sequences is constant, the problem is solvable in polynomial time by dynamic programming.
     7.For the case of two sequences of n and m elements, the running time of the dynamic programming approach is O(n × m)

    Solution for 2 sequences
    ------------------------

    1.Optimal substructure: the problem can be broken down into smaller, simpler subproblems, which can in turn be broken down into simpler subproblems, and so on, until, finally, the solution becomes trivial. 
    2.Overlapping subproblems: the solutions to high-level subproblems often reuse solutions to lower level subproblems. 
         
    Relation to other problems
    --------------------------
    
    1.For two strings X(length m) and Y(length n), the length of the shortest common supersequence is related to the length of the LCS by
        |SCS(X,Y)| = n + m - |LCS(X,Y)|

    2.The edit distance when only insertion and deletion is allowed (no substitution), or when the cost of the substitution is the double of the cost of an insertion or deletion, is:
        d(X,Y) = n + m - 2*|LCS(X,Y)|

    3.The longest increasing subsequence of a sequence S is the longest common subsequence of S and T, where T is the result of sorting S
         
    */
    class LCS
    {
        /*
         Choice Diagram - Choice1 + Choice 2
         Choice 1 - If last character of 2 string matches, remove last character from both string and recur for remining characters + 1 (to increase length)
            Why +1? As last character already matched so +1 to increase length by 1
         Choice 2 - If last character os 2 string is not matching, then we have 2 choices again
            Choice 2.a - Remove last character of string s1 and take all characters of string s2, recur
            Choice 2.b - Remove last character of string s2 and take all characters of string s1, recur
            Take Max of 2.a and 2.b
        */
        public int solveR(string X, string Y, int n, int m)
        {
            if (n == 0 || m == 0) //base condition, if one of the strings is empty then LCS length is 0
                return 0;
            if (X[n - 1] == Y[m - 1])
                return 1 + solveR(X, Y, n - 1, m - 1);
            return Math.Max(solveR(X, Y, n - 1, m), solveR(X, Y, n, m - 1));
        }

        //Memoization using Dictionary
        public int solveRMemoDict(string X, string Y, int n, int m)
        {
            Dictionary<String, int> memo = new Dictionary<string, int>();
            return solveRMemoDictHelper(X, Y, n, m, memo);
        }

        public int solveRMemoDictHelper(string X, string Y, int n, int m, Dictionary<string, int> memo)
        {
            if (n == 0 || m == 0)
                return 0;
            string key = n + "|" + m;
            if (!memo.ContainsKey(key))
            {
                if (X[n - 1] == Y[m - 1])
                    memo.Add(key, solveRMemoDictHelper(X, Y, n - 1, m - 1, memo) + 1);
                else
                    memo[key] = Math.Max(solveRMemoDictHelper(X, Y, n - 1, m, memo), solveRMemoDictHelper(X, Y, n, m - 1, memo));
            }
            return memo[key];
        }

        //Memoization using 2d array
        //"ezupkr"
        //"ubmrapg"
        public int solveRMemo2DArray(string X, string Y, int n, int m)
        {
            //Create 2d table for variables changing in recursive call, here lengths of stirng changing in each recursive call
            int[,] memo = new int[n + 1,m + 1];

            for (int i = 0; i < n + 1; i++)
            {
                for (int j = 0; j < m + 1; j++)
                {
                    memo[i, j] = -1;
                }
            }

            if (n == 0 || m == 0)
                return 0;
            if (memo[n, m] == -1)
            {
                if (X[n - 1] == Y[m - 1])
                    memo[n, m] = solveRMemo2DArray(X, Y, n - 1, m - 1) + 1;
                else
                    memo[n, m] = Math.Max(solveRMemo2DArray(X, Y, n - 1, m), solveRMemo2DArray(X, Y, n, m - 1));
            }

            return memo[n, m];
        }

    }
}
