public class Solution {
    public string foreignDictionary(string[] words) {
        StringBuilder alienDict = new();
        if (words.Length == 1) {
            var word = words[0];
            var len = word.Length;
            HashSet<char> unique = new();
            for (int m = 0; m < len; m++) {
                var letter = word[m];

                if (!unique.Contains(letter)) {
                    unique.Add(letter);
                    alienDict.Append(letter);
                }
            }
            return alienDict.ToString();
        }
        Dictionary<char, int> addictions = new();
        Dictionary<char, List<char>> Graph = new();
        for (int i = 0; i < words.Length - 1; i++) {
            var word_l = words[i];
            var word_r = words[i + 1];

            var len_l = word_l.Length;
            var len_r = word_r.Length;
            bool isDiff = false;
            for (int m = 0; m < Math.Min(len_l, len_r); m++) {
                var letter_l = word_l[m];
                if (!Graph.ContainsKey(letter_l)) {
                    Graph.Add(letter_l, new());
                    addictions.Add(letter_l, 0);
                }
                var letter_r = word_r[m];
                if (!Graph.ContainsKey(letter_r)) {
                    Graph.Add(letter_r, new());
                    addictions.Add(letter_r, 0);
                }
                if (letter_l == letter_r || isDiff)
                    continue;
                Graph[letter_l].Add(letter_r);
                addictions[letter_r]++;
                isDiff = true;
            }
            if (len_l > len_r && !isDiff)
                return "";
            int point = len_l;
            while (point < len_r) {
                var letter_r = word_r[point];
                if (!Graph.ContainsKey(letter_r)) {
                    Graph.Add(letter_r, new());
                    addictions.Add(letter_r, 0);
                }
                point++;
            }
        }
        Stack<char> DFS = new();
        HashSet<char> visited = new();
        foreach ((char letter, int parents) in addictions) {
            if (addictions[letter] == 0) {
                DFS.Push(letter);
            }
        }
        while (DFS.Count > 0) {
            var letter = DFS.Pop();
            visited.Add(letter);
            alienDict.Append(letter);
            foreach (var neighbour in Graph[letter]) {
                if (visited.Contains(neighbour))
                    continue;
                addictions[neighbour]--;
                if (addictions[neighbour] == 0)
                    DFS.Push(neighbour);
            }
        }
        foreach ((char letter, int parents) in addictions) {
            if (addictions[letter] != 0) {
                return "";
            }
        }
        return alienDict.ToString();
    }
}
