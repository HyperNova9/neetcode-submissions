public class Solution 
{
    public int Trap(int[] height) 
    {
                int n = height.Length;
        int left = 0, right = n - 1;
        int water = 0;
        var left_max = height[left];
        var right_max = height[right];        
        while (left < right)
        {
            if (left_max < right_max)
            {
                left++;
                if (left_max < height[left])
                    left_max = height[left];
                int current = Math.Min(left_max, right_max) - height[left];
                if (current > 0)
                    water += current;
                
            }
            else
            {
                right--;
                if (right_max < height[right])
                    right_max = height[right];
                int current = Math.Min(left_max, right_max) - height[right];
                if (current > 0)
                    water += current;
            }

        }
        return water;
    }   
}
