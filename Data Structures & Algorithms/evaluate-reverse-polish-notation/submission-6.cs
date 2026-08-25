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
                switch (elem) {
                    case "*":
                        stack.Push(a * b);
                        break;
                    case "/":
                        stack.Push((int)b / a);
                        break;
                    case "+":
                        stack.Push(a + b);
                        break;
                    case "-":
                        stack.Push(b - a);
                        break;
                }
            }
        }
        return stack.Peek();
    }
}
