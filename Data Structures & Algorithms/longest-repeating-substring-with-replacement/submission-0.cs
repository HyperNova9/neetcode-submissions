public class Solution 
{
    public int CharacterReplacement(string s, int k) 
    {
        int n = s.Length;
        if (n == 0) return 0;
        var set = s.ToHashSet();
        int max = 0;
        foreach (var c in set)
        {
            int l = 0, count = 0;
            for (int r = 0; r < n; r++)
            {
                if (s[r] == c)
                    count++;
                while (r - l + 1 > count + k)
                {
                    if (s[l] == c)
                        count--;
                    l++;
                }
                max = Math.Max(max, r - l + 1);
            }
        }
        return max;
    }
}
