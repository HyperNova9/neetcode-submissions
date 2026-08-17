public class Solution {
    public List<List<string>> GroupAnagrams(string[] strs) {
     int n = strs.Length;
     var group_anagrams = new Dictionary<string, List<string>>();
         for (int i = 0; i < n; i++)
             {
                   var key = new string(strs[i].OrderBy(x => x).ToArray());
                         if (!group_anagrams.ContainsKey(key))
                                 group_anagrams.Add(key, new());
                                       group_anagrams[key].Add(strs[i]);
                                           }
                                               return group_anagrams.Values.ToList<List<string>>();  
    }
}
