public class Solution {
    public int CountSubstrings(string s) {
        int n = s.Length;
        bool[][] DP = new bool [n][];
        for (int i = 0; i < n; i++) DP[i] = new bool[n];
        int count = 0;
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                if (j + i >= n)
                    break;
                // Console.WriteLine($"{j} | {j + i}");
                if (i == 0) {
                    DP[j][j + i] = true;
                } else if (i == 1) {
                    DP[j][j + i] = s[j] == s[j + i];
                } else {
                    DP[j][j + i] = s[j] == s[j + i] && DP[j + 1][j + i - 1];
                }
                if (DP[j][j + i])
                    count++;
            }
        }
        return count;
    }
}
