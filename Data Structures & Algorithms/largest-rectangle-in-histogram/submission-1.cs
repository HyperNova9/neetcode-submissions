public class Solution {
    public int LargestRectangleArea(int[] heights) {
        int n = heights.Length;
        var stack = new Stack<int>();
        var max_S = -int.MaxValue;

        for (int i = 0; i < n; i++) {
            while (stack.Count > 0 && heights[stack.Peek()] > heights[i]) {
                int h = heights[stack.Pop()];
                var left = stack.Count > 0 ? stack.Peek() : -1;
                int w = i - left - 1;
                max_S = Math.Max(max_S, h * w);
            }
            stack.Push(i);
        }
        while (stack.Count > 0) {
            int h = heights[stack.Pop()];
            var left = stack.Count > 0 ? stack.Peek() : -1;
            int w = n - left - 1;
            max_S = Math.Max(max_S, h * w);
        }
        return max_S;
    }
}
