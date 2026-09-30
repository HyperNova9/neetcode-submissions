public class Solution {
    public static void DFS_Parenthesis(List<string> parenthesis, StringBuilder tracking, int i_open,
                                       int i_close, int n) {
        if (i_open < n) {
            tracking.Append("(");
            DFS_Parenthesis(parenthesis, tracking, i_open + 1, i_close, n);
        }
        if (i_close < i_open) {
            tracking.Append(")");
            DFS_Parenthesis(parenthesis, tracking, i_open, i_close + 1, n);
        }
        if (i_close == n)
            parenthesis.Add(tracking.ToString());
        if (tracking.Length > 0)
            tracking.Remove(tracking.Length - 1, 1);
    }
    public List<string> GenerateParenthesis(int n) {
        var list = new List<string>();
        DFS_Parenthesis(list, new(), 0, 0, n);
        return list;
    }
}
