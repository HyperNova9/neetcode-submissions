public class Solution {
    public int LadderLength(string beginWord, string endWord, IList<string> wordList) {
        int n = wordList.Count;
        int m = wordList[0].Length;
        var beginBuild = new StringBuilder(beginWord);
        Dictionary<string, HashSet<string>> ShiftWords = new();
        for (int j = 0; j < m; j++) {
            char sym_j = beginBuild[j];
            beginBuild[j] = '*';
            var str_word = beginBuild.ToString();
            if (!ShiftWords.ContainsKey(str_word)) {
                ShiftWords.Add(str_word, new());
            }
            beginBuild[j] = sym_j;
            ShiftWords[str_word].Add(beginWord);
        }
        for (int i = 0; i < n; i++) {
            var word = new StringBuilder(wordList[i]);
            for (int j = 0; j < m; j++) {
                char sym_j = word[j];
                word[j] = '*';
                var str_word = word.ToString();
                if (!ShiftWords.ContainsKey(str_word)) {
                    ShiftWords.Add(str_word, new());
                }
                word[j] = sym_j;
                ShiftWords[str_word].Add(word.ToString());
            }
        }

        Queue<string> BFS = new();

        BFS.Enqueue(beginWord);
        HashSet<string> visited = new();
        visited.Add(beginWord);
        int curr_height = 1;
        int curr_width = BFS.Count;
        while (BFS.Count > 0) {
            var curr = new StringBuilder(BFS.Dequeue());
            curr_width--;
            for (int j = 0; j < m; j++) {
                char sym_j = curr[j];
                curr[j] = '*';
                var str_word = curr.ToString();
                if (!ShiftWords.ContainsKey(str_word)) {
                    curr[j] = sym_j;
                    continue;
                }
                Stack<string> need_delete = new();
                foreach (var word in ShiftWords[str_word]) {
                    if (visited.Contains(word))
                        continue;
                    if (word == endWord)
                        return curr_height + 1;
                    BFS.Enqueue(word);
                    visited.Add(word);
                    need_delete.Push(word);
                }
                while (need_delete.Count > 0) ShiftWords[str_word].Remove(need_delete.Pop());
                if (ShiftWords[str_word].Count == 0)
                    ShiftWords.Remove(str_word);
                curr[j] = sym_j;
            }
            if (curr_width <= 0) {
                curr_width = BFS.Count;
                curr_height++;
            }
        }
        return 0;
    }
}
