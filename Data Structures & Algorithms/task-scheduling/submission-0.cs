public class Solution {
    public int LeastInterval(char[] tasks, int n) {
        PriorityQueue<char, int> heap = new(Comparer<int>.Create((x, y) => y.CompareTo(x)));
        Dictionary<char, int> freq = new();
        List<char> unique = new();
        Queue<(char sym, int time)> queue = new();
        int t = 0;
        foreach (var sym in tasks) {
            if (freq.ContainsKey(sym)) {
                freq[sym]++;
                continue;
            }
            unique.Add(sym);
            freq.Add(sym, 1);
        }
        foreach (var uniq in unique) heap.Enqueue(uniq, freq[uniq]);

        while (heap.Count > 0 || queue.Count > 0) {
            if (queue.Count > 0 && queue.Peek().time == t) {
                var q_peek = queue.Peek();
                if (freq[q_peek.sym] > 0)
                    heap.Enqueue(q_peek.sym, freq[q_peek.sym]);
                queue.Dequeue();
            }
            if (heap.Count == 0) {
                t++;
                continue;
            }
            var sym = heap.Peek();
            freq[sym]--;
            heap.Dequeue();
            if (freq[sym] > 0)
                queue.Enqueue((sym, t + n + 1));
            t++;
        }
        return t;
    }
}
