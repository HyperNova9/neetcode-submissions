public class KthLargest {
    PriorityQueue<int, int> heap;
    int k;

    public KthLargest(int k, int[] nums) {
        int len = nums.Length;
        this.k = k;
        heap = new();
        for (int i = 0; i < len; i++) {
            var num = nums[i];
            if (heap.Count < k) {
                heap.Enqueue(num, num);
            } else {
                if (heap.Peek() < num) {
                    heap.Enqueue(num, num);
                    heap.Dequeue();
                }
            }
        }
    }

    public int Add(int val) {
        if (heap.Count == k) {
            if (heap.Peek() < val) {
                heap.Enqueue(val, val);
                heap.Dequeue();
            }
        } else
            heap.Enqueue(val, val);

        return heap.Peek();
    }
}
