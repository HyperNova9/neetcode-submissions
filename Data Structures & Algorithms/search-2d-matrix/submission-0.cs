public class Solution {
    public bool SearchMatrix(int[][] matrix, int target) {
        int m = matrix.Length, n = matrix[0].Length;
        int l = 0, r = m * n - 1;
        while (l <= r) {
            var mid = (int)(r + l) / 2;
            var mid_m = (int)mid / n;
            var mid_n = (int)mid % n;
            Console.WriteLine($"[{mid_m}][{mid_n}]");
            if (matrix[mid_m][mid_n] == target)
                return true;
            else if (matrix[mid_m][mid_n] > target)
                r = mid - 1;
            else
                l = mid + 1;
        }
        return false;
    }
}
