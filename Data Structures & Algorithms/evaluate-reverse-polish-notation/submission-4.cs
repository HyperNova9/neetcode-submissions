public class Solution {
    public int EvalRPN(string[] tokens) {
        var stack = new Stack<int>();
        foreach (var elem in tokens) {
            if (int.TryParse(elem, out int num)) {
                stack.Push(num);
            } else {
                int a = 0, b = 0;

                a = stack.Pop();
                b = stack.Pop();
            if (elem == "*")
                stack.Push(a * b);
            else if (elem == "/")
                stack.Push((int)b / a);
            else if (elem == "+")
                stack.Push(a + b);
            else if (elem == "-")
                stack.Push(b - a);
        }
    }
    return stack.Peek();
}
}
