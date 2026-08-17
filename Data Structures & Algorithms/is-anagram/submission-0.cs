public class Solution {
    public bool IsAnagram(string s, string t) {
    int n = t.Length;
    string sort_s = new string(s.OrderBy(_ => _).ToArray());
   string sort_t = new string(t.OrderBy(_ => _).ToArray());
   if (sort_s == sort_t)
   return true;
   else
   return false;
    }
}