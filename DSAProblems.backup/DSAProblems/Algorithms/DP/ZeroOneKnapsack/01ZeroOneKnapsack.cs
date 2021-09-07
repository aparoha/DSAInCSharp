using System;

namespace DSAProblems.Algorithms.DP.ZeroOneKnapsack
{
    /*
        0/1 means - either pick item or dont pick it
        If we can split item then solve using Greedy - sort the item to value/weight in non-decreasing order and then keep picking the items 
        and then if the last item cannot be picked totally, split it up and pick the ratio
        Sume of values is maximum and weight is equal to given weight						

        We want to find the maximum profit for every sub-array and for every possible capacity. This means, dp[i][c] will represent the maximum knapsack profit for capacity ‘c’ calculated 
        from the first ‘i’ items.

        So, for each item at index ‘i’ (0 <= i < items.length) and capacity ‘c’ (0 <= c <= capacity), we have two options:
        1. Exclude the item at index ‘i’. In this case, we will take whatever profit we get from the sub-array excluding this item => dp[i-1][c]
        2. Include the item at index ‘i’ if its weight is not more than the capacity. In this case, we include its profit plus whatever profit 
        we get from the remaining capacity and from remaining items => profits[i] + dp[i-1][c-weights[i]]

        Finally, our optimal solution will be maximum of the above two values:

        dp[i][c] = max (dp[i-1][c], profits[i] + dp[i-1][c-weights[i]]) 

        Total weight = 7
        int[] profits = {1, 6, 10, 16};
        int[] weights = {1, 2, 3, 5};
                            
                                        Capacity --->
        profit[]    weight[]    index   0   1   2   3   4   5   6   7
        1           1           0       0   1   1   1   1   1   1   1
        6           2           1       0   1   6   7   7   7   7   7
        10          3           2       0   1   6   10  11  16  17  17
        16          5           3       0   1   6   10  11  16  17  22

        With '0' capacity, maximum profit we can have for every subarray is '0'
        Capacity = 1-7, Index = 0, i.e., if we consider the sub-array till index '0', this means we have only one item to put in the knapsack, we will take it if it is not more than the capacity
        Capacity = 1, Index =1, since item at index '1' has weight '2', which is greater than the capacity '1', so we will take the dp[index-1][capacity]
        Capacity = 2, Index =1, from the formula discussed above: max( dp[0][2], profit[1] + dp[0][0] )
        Capacity = 3, Index =1, from the formula discussed above: max( dp[0][3], profit[1] + dp[0][1] )
        Capacity = 4, Index =1, from the formula discussed above: max( dp[0][4], profit[1] + dp[0][2] )
        Capacity = 5, Index =1, from the formula discussed above: max( dp[0][5], profit[1] + dp[0][3] )
        Capacity = 6, Index =1, from the formula discussed above: max( dp[0][6], profit[1] + dp[0][4] )
        Capacity = 7, Index =1, from the formula discussed above: max( dp[0][7], profit[1] + dp[0][5] )
        Capacity = 1, Index =2, since item at index '2' has weight '3', which is greater than the capacity '1', so we will take the dp[index-1][capacity]
        Capacity = 2, Index =2, since item at index '2' has weight '3', which is greater than the capacity '1', so we will take the dp[index-1][capacity]
        Capacity = 3, Index =2, from the formula discussed above: max( dp[1][3], profit[2] + dp[1][0] )
        Capacity = 4, Index =2, from the formula discussed above: max( dp[1][4], profit[2] + dp[1][1] )
        Capacity = 5, Index =2, from the formula discussed above: max( dp[1][5], profit[2] + dp[1][2] )
        Capacity = 6, Index =2, from the formula discussed above: max( dp[1][6], profit[2] + dp[1][3] )
        Capacity = 7, Index =2, from the formula discussed above: max( dp[1][7], profit[2] + dp[1][4] )
        Capacity = 1, Index =3, since item at index '3' has weight '5', which is greater than the capacity '1', so we will take the dp[index-1][capacity]
        Capacity = 2, Index =3, since item at index '3' has weight '5', which is greater than the capacity '2', so we will take the dp[index-1][capacity]
        Capacity = 3, Index =3, since item at index '3' has weight '5', which is greater than the capacity '3', so we will take the dp[index-1][capacity]
        Capacity = 4, Index =3, since item at index '3' has weight '5', which is greater than the capacity '4', so we will take the dp[index-1][capacity]
        Capacity = 5, Index =3, from the formula discussed above: max( dp[2][5], profit[3] + dp[2][0] )
        Capacity = 6, Index =3, from the formula discussed above: max( dp[2][6], profit[3] + dp[2][1] )
        Capacity = 7, Index =3, from the formula discussed above: max( dp[2][7], profit[3] + dp[2][2] )
         */

    class ZeroOneKnapsack
    {
        //Top down
        public int solveR(int[] profits, int[] weights, int capacity, int size)
        {
            if (size == 0 || capacity == 0)
                return 0;
            //Maximum of include and not include
            if (weights[size - 1] <= capacity)
                return Math.Max(profits[size - 1] + solveR(profits, weights, capacity - weights[size - 1], size - 1),
                    solveR(profits, weights, capacity, size - 1));
            return solveR(profits, weights, capacity, size - 1);
        }

        //Recursion with Memoization
        //State variables - capacity and size
        //Draw dp table for state variables - variables changing with each call
        //Create dp table with size capacity + 1, size + 1 and initialize with some invalid values
        public int solveRMemo(int[] profits, int[] weights, int capacity, int size)
        {
            //Initialize dp cache with some invalid value
            int[,] dp = new int[size + 1, capacity + 1];
            for (int i = 0; i < dp.GetLength(0); i++)
            {
                for (int j = 0; j < dp.GetLength(1); j++)
                {
                    dp[i, j] = -1;
                }
            }
            return solveRMemoHelper(dp, profits, weights, capacity, size);
        }

        private int solveRMemoHelper(int[,] dp, int[] profits, int[] weights, int capacity, int size)
        {
            if (size == 0 || capacity == 0)
                return 0;
            if (dp[size, capacity] != -1)
                return dp[size, capacity];
            //Maximum of include and not include
            if (weights[size - 1] <= capacity)
            {
                dp[size, capacity] = Math.Max(
                    profits[size - 1] + solveRMemoHelper(dp, profits, weights, capacity - weights[size - 1], size - 1),
                    solveRMemoHelper(dp, profits, weights, capacity, size - 1)
                    );
                return dp[size, capacity];
            }            
            dp[size, capacity] = solveRMemoHelper(dp, profits, weights, capacity, size - 1);
            return dp[size, capacity];
        }

        public int solveBottomup(int[] profits, int[] weights, int capacity, int size)
        {
            //Convert base condition to initialization
            int[,] dp = new int[size + 1, capacity + 1];
            for (int i = 0; i < size + 1; i++)
            {
                for (int j = 0; j < capacity + 1; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        dp[i, j] = 0;
                    }
                }
            }

            for (int i = 1; i < size + 1; i++)
            {
                for (int j = 1; j < capacity + 1; j++)
                {
                    if (weights[i - 1] <= j)
                        dp[i, j] = Math.Max(profits[i - 1] + dp[i - 1, j - weights[i - 1]], dp[i - 1, j]);
                    else
                        dp[i, j] = dp[i - 1, j];
                }
            }

            return dp[size, capacity];
        }

        //How to find the selected items?
        private void PrintSelectedElements(int[,] dp, int[] weights, int[] profits, int capacity){
            Console.WriteLine("Selected weights:");
            int totalProfit = dp[weights.Length-1, capacity];
            for(int i=weights.Length-1; i > 0; i--) {
                if(totalProfit != dp[i-1, capacity]) {
                    Console.WriteLine(" " + weights[i]);
                    capacity -= weights[i];
                    totalProfit -= profits[i];
                }
            }

            if(totalProfit != 0)
                Console.WriteLine(" " + weights[0]);
            Console.WriteLine("");
        }
        
    }
}
