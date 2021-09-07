using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DSAProblems.OA.Amazon
{
    /*
     
        A virtual memory management system use least-recently-Used (LRU) cache. 
        
        1.When a requested memory page is not in the cache and the cache is full, the page that was least-recently-used should be removed from the cache to make room for the requested page. 
        2.If the cache is not full, the requested page can simply be added to the cache and considered the most-recently-used page in the cache. 
        3.A given page should occur at most once in the cache.

        Given the maximum size of the cache and a list of page requests,
        write an algorithm to calculate the number of cache misses. 
        A cache miss occurs when a page is requested and isn't found in the cache.

        int lruCacheMisses(int num, List<Integer> pages, int maxCacheSize)

        Input
        The input consists of three arguments:

        num : an integer representing the number of pages
        pages : a list of integers representing the pages requested
        maxCacheSize : an integer representing the size of the cache

        Output
        Return an integer for the number of cache misses.

        Note
        The cache is initially empty and the list contains pages numbered in the range 1-50. A page at index "i" in the list is requested before a page at index "i+1".

        Constraints
        0 <= i < num

Examples
    Example 1:
    Input:
    num = 6

    pages = [1,2,1,3,1,2]

    maxCacheSize = 2

    Output: 4
    Explanation:
      Cache state as requests come in ordered longest-time-in-cache to shortest-time-in-cache:

      1*

      1,2*

      2,1

      1,3*

      3,1

      1,2*

      Asterisk (*) represents a cache miss. Hence, the total number of a cache miss is `4`.
    */
    class LruCacheMisses
    {
        private LinkedList<KeyValuePair<int, int>> list;
        private Dictionary<int, LinkedListNode<KeyValuePair<int, int>>> map;
        private int capacity;

        public int lruCacheMisses(int num, List<int> pages, int maxCacheSize)
        {
            capacity = maxCacheSize;
            list = new LinkedList<KeyValuePair<int, int>>();
            map = new Dictionary<int, LinkedListNode<KeyValuePair<int, int>>>();

            int cacheMiss = 0;
            for (int i = 0; i < num; i++)
            {
                var key = pages[i];
                if(map.ContainsKey(key))
                {
                    LinkedListNode<KeyValuePair<int, int>> node = map[key];
                    list.Remove(node);
                    map[key] = list.AddFirst(new KeyValuePair<int, int>(key, i + 1));
                }
                else
                {
                    cacheMiss++;
                    if(list.Count >= capacity) {
                        map.Remove(list.Last().Key);
                        list.RemoveLast();
                    }
                    map[key] = list.AddFirst(new KeyValuePair<int, int>(key, i + 1));
                }
            }

            return cacheMiss;

        }

        public int lruCacheMisses_int(int num, List<int> pages, int maxCacheSize) {
//        If the max cache size is zero. Then every element will be a new item.
            if (maxCacheSize == 0) return 
                    pages.Count;
            HashSet<int> cache = new HashSet<int>();
            int count = 0;
            foreach(int page in pages) {
                if (cache.Contains(page)) {
//                Move the element to the end.
                    cache.Remove(page);
                    cache.TrimExcess();
                    cache.Add(page);
                } else {
                    if (cache.Count == maxCacheSize) {
//                    If cache is full, then get the first element and remove from cache
                        int first = cache.First();
                        cache.Remove(first);
                    }
                    cache.Add(page);
                    count++;
                }
            }
            return count;
        }

        public class LRUCache
        {
            private LinkedList<KeyValuePair<int, int>> list;
            private Dictionary<int, LinkedListNode<KeyValuePair<int, int>>> map;
            private int capacity;
            public LRUCache(int capacity)
            {
                this.capacity = capacity;
                list = new LinkedList<KeyValuePair<int, int>>();
                map = new Dictionary<int, LinkedListNode<KeyValuePair<int, int>>>();
            }
 
            public int Get(int key)
            {
                if (!map.ContainsKey(key)) return - 1;
                var node = map[key];
                list.Remove(node);
                map[key] = list.AddFirst(node.Value);
                return node.Value.Value;
            }
 
            public void Put(int key, int value)
            {
                if(map.ContainsKey(key))
                {
                    var node = map[key];
                    list.Remove(node);
                    map[key] = list.AddFirst(new KeyValuePair<int, int>(key, value));
                }
                else {
                    if(list.Count>= this.capacity) {
                        map.Remove(list.Last().Key);
                        list.RemoveLast();
                    }
                    map[key] = list.AddFirst(new KeyValuePair<int, int>(key, value));
                }
            }
        }
    }
}
