public class Solution {
    public int[] DailyTemperatures(int[] temperatures) {
        int n = temperatures.Length;
        var stack = new Stack<int>();
        int[] daily = new int[n];
        var t = temperatures;
        for (int i = 0; i < n; i++) {
            if (stack.TryPeek(out int result)) {
                if (t[stack.Peek()] < t[i]) {
                    while (stack.TryPeek(out int notneed) && t[stack.Peek()] < t[i]) {
                        var index = stack.Peek();
                        daily[index] = i - index;
                        stack.Pop();
                    }
                    stack.Push(i);

                } else {
                    stack.Push(i);
                }
            } else
                stack.Push(i);
        }
        while (stack.TryPeek(out int notneed)) {
            daily[stack.Peek()] = 0;
            stack.Pop();
        }
        return daily;
    }
}
