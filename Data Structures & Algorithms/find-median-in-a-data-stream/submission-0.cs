public class MedianFinder {
    PriorityQueue<int, int> l;
    PriorityQueue<int, int> r;
    bool isFirstMedian;
    double median = 0;
    public MedianFinder() {
        l = new(Comparer<int>.Create((x, y) => y.CompareTo(x)));
        r = new();
        isFirstMedian = false;
    }

    public void AddNum(int num) {
        if (!isFirstMedian) {
            r.Enqueue(num, num);
            median = r.Peek();
            isFirstMedian = true;
            return;
        }
        if (num >= median)
            r.Enqueue(num, num);
        else
            l.Enqueue(num, num);

        if (r.Count - l.Count == 2) {
            l.Enqueue(r.Peek(), r.Peek());
            r.Dequeue();
        } else if (l.Count - r.Count == 2) {
            r.Enqueue(l.Peek(), l.Peek());
            l.Dequeue();
        }
        median = r.Count == l.Count  ? (double)(r.Peek() + l.Peek()) / 2
                 : r.Count > l.Count ? r.Peek()
                                     : l.Peek();
    }

    public double FindMedian() {
        return median;
    }
}
