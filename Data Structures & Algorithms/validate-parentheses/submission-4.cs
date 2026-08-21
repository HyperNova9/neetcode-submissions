public class Solution 
{
    public bool IsValid(string s) 
    {
                var close_c = new char[] {')', '}', ']'};
        var dict_c = new Dictionary<char,char>()
        {
            {'(', ')'},
            {'{', '}'},
            {'[', ']'}        
        };
        var stack = new Stack<char>();
        foreach (var elem in s)
        {
            if (dict_c.ContainsKey(elem))
            {
                stack.Push(elem);
            }
            else if (stack.Count > 0)
            {
                if (dict_c[stack.Peek()] == elem)
                    stack.Pop();
                else
                    return false;
            }
            else
                if (close_c.Contains(elem))
                    return false;
        }
        return stack.Count == 0 ? true : false;
    }
}
