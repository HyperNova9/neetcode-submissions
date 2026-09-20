public class Solution {
    public int LastStoneWeight(int[] stones) {
        // создаем кучу и через компаратор преобразовываем
        // min-heap => max-heap
        PriorityQueue<int, int> heap = new(Comparer<int>.Create((x, y) => y.CompareTo(x)));
        // Добавим все камни в кучу с приоритетом от максимума к минимуму
        foreach (var stone in stones) {
            heap.Enqueue(stone, stone);
        }
        // Бьем камни до тех пор, пока не останется 1
        while (heap.Count > 1) {
            int y = heap.Peek();
            heap.Dequeue();
            int x = heap.Peek();
            heap.Dequeue();

            if (y > x)
                heap.Enqueue(y - x, y - x);
        }

        return heap.Count > 0 ? heap.Peek() : 0;
    }
}
