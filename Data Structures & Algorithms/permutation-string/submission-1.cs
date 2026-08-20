public class Solution {
    public bool CheckInclusion(string s1, string s2) 
    {
int l = 0;
        var n = s2.Length;
        Dictionary<char, int> s1_dict = s1.GroupBy(c => c)
        .ToDictionary(c => c.Key, c => c.Count());
        Dictionary<char, int> sym_c = new();
        for (int r = 0; r < n; r++)
        {
            if (sym_c.ContainsKey(s2[r]))
                sym_c[s2[r]]++;
            else
                sym_c.Add(s2[r], 1);
            if (r - l + 1 > s1.Length)
            {

                sym_c[s2[l]]--;
                if (sym_c[s2[l]] == 0)
                    sym_c.Remove(s2[l]);
                l++;
            }
            if (r - l + 1 == s1.Length)
            {
                if (s1_dict.All(x => 
                sym_c.TryGetValue(x.Key, out int value) && value == x.Value))
                    return true;
            }
        }
        return false;
    }
}
