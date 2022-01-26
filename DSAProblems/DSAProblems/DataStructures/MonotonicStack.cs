using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProblems.DataStructures
{
    /*  1. Smaller element - increasing stack
     *  2. Greater element - decreasing stack
     * 
    */
    public class MonotonicStack
    {
        public int[] NextGreaterElement(int[] arr)
        {
            if(arr == null || arr.Length == 0)
                return null;
            int[] result = new int[arr.Length];
            Stack<int> stack = new Stack<int>();
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                while(stack.Count > 0 && stack.Peek() <= arr[i])
                {
                    stack.Pop();
                }
                result[i] = stack.Count == 0 ? -1 : stack.Peek();
                stack.Push(arr[i]);
            }
            return result;
        }

        public int[] DNextGreaterElement(int[] arr)
        {
            if (arr == null || arr.Length == 0)
                return null;
            int[] result = new int[arr.Length];
            Stack<int> stack = new Stack<int>();
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                while (stack.Count > 0 && arr[stack.Peek()] <= arr[i])
                {
                    stack.Pop();
                }
                result[i] = stack.Count == 0 ? 0 : stack.Peek() - i;
                stack.Push(i);
            }
            return result;
        }

        public int[] PreviousGreaterElement(int[] arr)
        {
            if (arr == null || arr.Length == 0)
                return null;
            int[] result = new int[arr.Length];
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                while (stack.Count > 0 && stack.Peek() <= arr[i])
                {
                    stack.Pop();
                }
                result[i] = stack.Count == 0 ? -1 : stack.Peek();
                stack.Push(arr[i]);
            }
            return result;
        }

        public int[] DPreviousGreaterElement(int[] arr)
        {
            if (arr == null || arr.Length == 0)
                return null;
            int[] result = new int[arr.Length];
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                while (stack.Count > 0 && arr[stack.Peek()] <= arr[i])
                {
                    stack.Pop();
                }
                result[i] = stack.Count == 0 ? 0 : i - stack.Peek();
                stack.Push(i);
            }
            return result;
        }

        public int[] NextSmallerElement(int[] arr)
        {
            if (arr == null || arr.Length == 0)
                return null;
            int[] result = new int[arr.Length];
            Stack<int> stack = new Stack<int>();
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                while (stack.Count > 0 && stack.Peek() >= arr[i])
                {
                    stack.Pop();
                }
                result[i] = stack.Count == 0 ? -1 : stack.Peek();
                stack.Push(arr[i]);
            }
            return result;
        }

        public int[] DNextSmallerElement(int[] arr)
        {
            int n = arr.Length;
            if (arr == null || n == 0)
                return null;
            int[] result = new int[n];
            Stack<int> stack = new Stack<int>();
            for (int i = n - 1; i >= 0; i--)
            {
                while (stack.Count > 0 && arr[stack.Peek()] >= arr[i])
                {
                    stack.Pop();
                }
                result[i] = stack.Count == 0 ? n - i : stack.Peek() - i;
                stack.Push(i);
            }
            return result;
        }

        public int[] PreviousSmallerElement(int[] arr)
        {
            int n = arr.Length;
            if (arr == null || n == 0)
                return null;
            int[] result = new int[n];
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < n; i++)
            {
                while (stack.Count > 0 && stack.Peek() >= arr[i])
                {
                    stack.Pop();
                }
                result[i] = stack.Count == 0 ? -1 : stack.Peek();
                stack.Push(arr[i]);
            }
            return result;
        }

        public int[] DPreviousSmallerElement(int[] arr)
        {
            int n = arr.Length;
            if (arr == null || n == 0)
                return null;
            int[] result = new int[n];
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < n; i++)
            {
                while (stack.Count > 0 && arr[stack.Peek()] >= arr[i])
                {
                    stack.Pop();
                }
                result[i] = stack.Count == 0 ? i + 1 : i - stack.Peek();
                stack.Push(i);
            }
            return result;
        }
    }
}
