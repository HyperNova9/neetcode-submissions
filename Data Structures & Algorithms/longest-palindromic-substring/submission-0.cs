public class Solution {
    public string LongestPalindrome(string s) {
        int n = s.Length;
        bool[][] DP = new bool [n][];
        for (int i = 0; i < n; i++) DP[i] = new bool[n];
        int max_length = 0;
        int start = 0;
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                if (j + i >= n)
                    break;
                // Console.WriteLine($"{j} | {j + i}");
                if (i == 0) {
                    DP[j][j] = true;
                    max_length = 1;
                } else if (i == 1) {
                    DP[j][j + i] = s[j] == s[j + i];
                } else {
                    DP[j][j + i] = s[j] == s[j + i] && DP[j + 1][j + i - 1];
                }
                if (DP[j][j + i]) {
                    if (max_length < i + 1) {
                        max_length = i + 1;
                        start = j;
                    }
                }
            }
        }

        return s.Substring(start, max_length);
    }
}
