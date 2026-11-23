public class Solution {
    public int MaxProduct(int[] nums) {
        int len = nums.Length;
        int minProd = nums[0];
        int maxProd = nums[0];

        int globalMax = nums[0];

        int i = 1;
        while (i < len) {
            int num = nums[i];
            var newMin = Math.Min(num, Math.Min(minProd * num, maxProd * num));

            var newMax = Math.Max(num, Math.Max(minProd * num, maxProd * num));
            minProd = newMin;
            maxProd = newMax;
            if (globalMax < maxProd)
                globalMax = maxProd;

            i++;
        }

        return globalMax;
    }
}
