public class Solution {
    static double DistanceToCenter(int[] point) {
        var res = point[0] * point[0] + point[1] * point[1];
        return Math.Sqrt(res);
    }
    public int[][] KClosest(int[][] points, int k) {
        PriorityQueue<int[], double> heap = new(Comparer<double>.Create((x, y) => y.CompareTo(x)));
        int[][] k_points = new int [k][];
        foreach (var point in points) {
            var dist = DistanceToCenter(point);
            if (heap.Count < k) {
                heap.Enqueue(point, dist);
            } else if (heap.Count > 0 && dist < DistanceToCenter(heap.Peek())) {
                heap.Enqueue(point, dist);
                heap.Dequeue();
            }
        }

        while (heap.Count > 0) {
            k_points[k - heap.Count] = heap.Peek();
            heap.Dequeue();
        }

        return k_points;
    }
}
