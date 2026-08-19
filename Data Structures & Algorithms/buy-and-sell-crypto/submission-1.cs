public class Solution 
{
    public int MaxProfit(int[] prices) 
    {
        int n = prices.Length;
        int l = 0, r = 1;
        var max = 0;
        while (r < n)
        {
            int left = prices[l], right = prices[r];
            if (left > right)
            {
                l=r;
                r++;
                continue;
            }
            if (right - left > max)
                max = right - left;
            r++;
        }
            
        return max;
    }
}
