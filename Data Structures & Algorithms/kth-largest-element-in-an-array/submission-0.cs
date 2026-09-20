public class Solution {
    public int FindKthLargest(int[] nums, int k) {
        PriorityQueue<int, int> heap = new();

        foreach (var num in nums) {
            if (heap.Count < k) {
                heap.Enqueue(num, num);
            } else if (heap.Peek() < num) {
                heap.Enqueue(num, num);
                heap.Dequeue();
            }
        }

        return heap.Peek();
    }
}
