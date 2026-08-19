public class Solution 
{
    public int LengthOfLongestSubstring(string s) 
    {
        int l = 0, r = 0;
        int max = 0;
        HashSet<char> set = new HashSet<char>();
        while (r < s.Length)
        {
            
            // var sub = s.Substring(l, r-l);
            // var dist_sub = new string(sub.Distinct().ToArray());
            if(!set.Contains(s[r]))
            {
                set.Add(s[r]);
                r++;
            }
            else
            {
                max = Math.Max(max, set.Count);
                set.Remove(s[l]);
                l++;
            }
        }
        max = Math.Max(max, set.Count);
        return max;
    }
}
