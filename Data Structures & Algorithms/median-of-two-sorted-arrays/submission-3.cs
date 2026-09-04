public class Solution {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        int m = nums1.Length;
        int n = nums2.Length;
        if ((m + n) == 0)
            return 0;
        var small = n <= m ? ref nums2 : ref nums1;
        var big = n > m ? ref nums2 : ref nums1;
        int max = 0, min = 0;

        if (m > n) {
            var swap = m;
            m = n;
            n = swap;
        }
        int left = (m + n) / 2;
        int l = 0, r = m + 1;
        double res = big[0];
        if ((m + n) == 1)
            return res;
        int r_big = 0, mid = 0;
        if (m == 0) {
            var i = (int)n / 2;
            min = big[i];
            if ((m + n) % 2 == 0) {
                max = big[i];
                min = big[i - 1];
                res = (double)(min + max) / 2;
            } else {
                min = big[i];
                res = (double)min;
            }
            return res;
        }
        while (l < r) {
            mid = (l + r) / 2;
            r_big = left - mid;
            // Console.WriteLine($"r_big = {r_big} | r_small = {mid}");
            //  Console.WriteLine($"l = {l} | r = {r}");

            if (mid > 0 && small[mid - 1] > big[r_big]) {
                r = mid - 1;
            } else if (r_big > 0 && mid < m && big[r_big - 1] > small[mid]) {
                l = mid + 1;
            } else {
                break;
            }
            //  Console.WriteLine("(CYCLE)");
        }
        // Console.WriteLine("END CYCLE");
        mid = (l + r) / 2;
        r_big = left - mid;
        if (mid == 0) {
            min = r_big == n ? small[mid] : Math.Min(big[r_big], small[mid]);
            max = big[r_big - 1];
        } else if (r_big == 0) {
            min = mid == m ? big[r_big] : Math.Min(small[mid], big[r_big]);
            max = small[mid - 1];
        } else if (mid == m) {
            min = big[r_big];
            max = Math.Max(small[mid - 1], big[r_big - 1]);
        } else {
            min = Math.Min(big[r_big], small[mid]);
            max = Math.Max(small[mid - 1], big[r_big - 1]);
        }
        // Console.WriteLine($"r_big = {r_big} | r_small = {mid}");
        // Console.WriteLine($"l = {l} | r = {r}");

        if ((m + n) % 2 == 0)
            res = (double)(min + max) / 2;
        else
            res = (double)min;
        return res;
    }
}
