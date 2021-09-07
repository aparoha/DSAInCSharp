using System;

namespace DSAProblems.LeetCode.DynamicProgramming
{
    /*
    121. Best Time to Buy and Sell Stock
    Say you have an array for which the ith element is the price of a given stock on day i.

    If you were only permitted to complete at most one transaction (i.e., buy one and sell one share of the stock), design an algorithm to find the maximum profit.

    Note that you cannot sell a stock before you buy one.

    Example 1:

    Input: [7,1,5,3,6,4]
    Output: 5
    Explanation: Buy on day 2 (price = 1) and sell on day 5 (price = 6), profit = 6-1 = 5.
                 Not 7-1 = 6, as selling price needs to be larger than buying price.
    Example 2:

    Input: [7,6,4,3,1]
    Output: 0
    Explanation: In this case, no transaction is done, i.e. max profit = 0.
    */
    class LeetCode121
    {
        public int MaxProfitBruteForce(int[] prices) {
            if(prices == null || prices.Length <=1)
                return 0;
            if(prices.Length == 2 && prices[1] >= prices[0])
                return prices[1] - prices[0];
            int maxProfit = 0;
        
            for(int i = 0; i < prices.Length; i++){
                int current = prices[i];
                for(int j = i + 1; j < prices.Length; j++){
                    maxProfit = Math.Max(prices[j] - current, maxProfit);
                }
            }
        
            return maxProfit;
        }

        public int MaxProfitSinglePass(int[] prices) {
            int profit = 0;
            int minPrice = Int32.MaxValue;
            foreach (int price in prices)
            {
                minPrice = Math.Min(price, minPrice);
                profit = Math.Max(price - minPrice, profit);
            }
            return profit;
        }

        public int MaxProfitR(int[] prices) {
            if(prices == null || prices.Length == 0) return 0;
            return helper(prices, 0, int.MaxValue, 0);
        }
    
        public int helper(int[] prices, int index, int minBuyingPrice, int maxProfit){
            if(prices.Length == index) {
                return maxProfit;
            }
            maxProfit = Math.Max(prices[index] - minBuyingPrice, maxProfit);
            minBuyingPrice = Math.Min(minBuyingPrice, prices[index]);
            return helper(prices, ++index, minBuyingPrice, maxProfit);
        }
    }
}
