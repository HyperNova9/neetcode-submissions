public class Solution {
    public int CoinChange(int[] coins, int amount) {
        int len = coins.Length;
        var DP = new int[amount + 1];
        Array.Fill(DP, -1);
        if (amount == 0)
            return 0;
        foreach (var coin in coins) {
            if (coin < amount) {
                DP[coin] = 1;
            } else if (coin == amount) {
                return 1;
            }
        }

        int i = 1;
        while (i <= amount) {
            foreach (var coin in coins) {
                if (i - coin > 0) {
                    DP[i] = (DP[i] == -1 || DP[i] > DP[i - coin] + 1) && DP[i - coin] > 0
                                ? DP[i - coin] + 1
                                : DP[i];
                }
            }
            // Console.WriteLine($"DP[{i}] = {DP[i]}");
            i++;
        }
        // Console.WriteLine(DP[amount]);
        return DP[amount];
    }
}
