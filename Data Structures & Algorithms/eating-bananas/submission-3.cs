public class Solution {
    public int MinEatingSpeed(int[] piles, int h) {
        double t = 0;
        int l = 0, r = piles.Max();
        var n = piles.Length;
        int k = 0;
        Console.Write($"[{l}] -> [{r}]\n");

        while (l <= r) {
            k = (int)(l + r) / 2;
            t = 0;
            Console.Write($"k = {k} | ");
            for (int i = 0; i < n; i++) t += Math.Ceiling((double)piles[i] / k);
            Console.WriteLine($"t = {t}");
            if (t > h) {
                l = k + 1;
            } else {
                r = k - 1;
            }
        }
        return l;
    }
}
