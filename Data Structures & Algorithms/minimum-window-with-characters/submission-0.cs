public class Solution 
{
    public string MinWindow(string s, string t) 
    {
        int l = 0, r = 0, n = s.Length;
        Dictionary<char, int> dict_t = t.GroupBy(t => t).ToDictionary(t => t.Key, s => s.Count());
        var tmp_dt = new Dictionary<char, int>();
        var min_tmp_dt = new Dictionary<char,int>(dict_t);
        var min_window = s;
        bool isSubT = false;
        //Main process
        while (r <= n)
        {
            if (min_tmp_dt.Count > 0)
            {
                if (r == n) break;
                if (min_tmp_dt.ContainsKey(s[r]))
                {
                    min_tmp_dt[s[r]]--;
                    if (min_tmp_dt[s[r]] <= 0)
                        min_tmp_dt.Remove(s[r]);
                }
                if (dict_t.ContainsKey(s[r]))
                    if (tmp_dt.ContainsKey(s[r]))
                        tmp_dt[s[r]]++;
                    else
                        tmp_dt.Add(s[r], 1);
                r++;
            }
            else
            {
                isSubT = true;
                if (dict_t.ContainsKey(s[l]))
                {
                    tmp_dt[s[l]]--;
                    if (tmp_dt[s[l]] < dict_t[s[l]])
                    {
                        var sub = s.Substring(l, r-l);
                        min_window = min_window.Length > sub.Length ? sub : min_window;
                        min_tmp_dt.Add(s[l], 1);
                        
                    }
                    if (tmp_dt[s[l]] == 0)
                        tmp_dt.Remove(s[l]);
                }
                l++;
            }

        }
        return isSubT ? min_window : "";
    }
}
