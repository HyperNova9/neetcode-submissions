public class Solution 
{
    public int Trap(int[] height) 
    {
        int n = height.Length;
        int pos = 1;
        int water = 0;
        var left_max = height[pos-1];
        var right_max_list = height.ToList();
        var max_prepare = 0;
        for (int i = n - 1; i >= 0; i--)
        {
            max_prepare = Math.Max(max_prepare, height[i]);
            right_max_list[i] = max_prepare;
        }
            
        while (pos < n - 1)
        {
            if (height[pos] > left_max)
                left_max = height[pos];
            int current = Math.Min(left_max, right_max_list[pos]) - height[pos];
            if (current > 0)
                water += current;
            pos++;
        }
        return water;
    }   
}
