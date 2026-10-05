public class Solution {
    static void DFS_Partition(List<List<string>> partition, List<StringBuilder> part_list, string s,
                              int deep) {
        if (part_list.Count > 0) {
            var last_str = part_list[part_list.Count - 1];
            int l = 0, r = last_str.Length - 1;
            while (l < r) {
                if (last_str[l] != last_str[r])
                    return;
                l++;
                r--;
            }
        }
        if (deep == s.Length) {
            var candidate = part_list.Select(x => x.ToString()).ToList();
            partition.Add(new List<string>(candidate));
            return;
        }

        part_list.Add(new());
        var last = part_list[part_list.Count - 1];
        for (int i = deep; i < s.Length; i++) {
            last.Append(s[i]);
            DFS_Partition(partition, part_list, s, i + 1);
            //  part_list.RemoveAt(part_list.Count - 1)
        }
        part_list.RemoveAt(part_list.Count - 1);
    }
    public List<List<string>> Partition(string s) {
        List<List<string>> partition = new();
        DFS_Partition(partition, new(), s, 0);
        return partition;
    }
}
