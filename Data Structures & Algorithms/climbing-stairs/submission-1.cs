public class Solution {
    public int ClimbStairsMemo(Dictionary<int, int> cache, 
    int n)
    {
       if (!cache.ContainsKey(n))
       {
           if (n > 0)
           cache.Add(n, 
           ClimbStairsMemo(cache, n - 1)
            + ClimbStairsMemo(cache, n - 2));
       } 
       else
           return cache[n];
       if (n == 0)
       {
           cache.Add(n, 1);
           return 1;
       }
       else if (n < 0)
       {
           cache.Add(n, 0);
           return 0;
       }
       return cache[n];
    }
    public int ClimbStairs(int n) {     
        Dictionary<int,  int> cache = new();
        return ClimbStairsMemo(cache, n);
    }
}
