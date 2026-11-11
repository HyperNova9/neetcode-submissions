public class Solution {
    public int MinCostClimbingStairs(int[] cost) {
        int len = cost.Length;
        //базовые случаи
        
        int prev = cost[1];
        int prev_prev = cost[0];
        int curr = 0;
        int i = 2;
        while (i < len)
        {
            curr = cost[i];
            curr += prev <= prev_prev ? prev : prev_prev;
            prev_prev = prev;
            prev = curr;
            i++;
        }
        return prev > prev_prev ? prev_prev : prev;
    }
}
