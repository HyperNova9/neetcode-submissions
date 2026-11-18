public class Solution {
    public int NumDecodings(string s) {
        int len = s.Length;
        if (len == 0)
            return 0;
        Dictionary<string, char> ABC = new();
        for (int k = 1; k <= 26; k++) {
            ABC.Add(k.ToString(), (char)('A' + k - 1));
        }

        var DP = new int[len];
        Array.Fill(DP, 0);

        if (isABC(ABC, s[0].ToString()))
            DP[0] = 1;
        else
            DP[0] = 0;

        if (len == 1)
            return DP[0];

        if (isABC(ABC, s[1].ToString()))
            DP[1] += DP[0];

        if (isABC(ABC, s.Substring(0, 2)))
            DP[1] += 1;

        if (len == 2)
            return DP[1];

        int i = 2;
        while (i < len) {
            if (isABC(ABC, s[i].ToString())) {
                DP[i] += DP[i - 1];
            }
            if (isABC(ABC, s.Substring(i - 1, 2))) {
                DP[i] += DP[i - 2];
            }
            i++;
        }

        return DP[len - 1];
    }
    public static bool isABC(
        Dictionary<string, char> ABC,
        string num
    )
    {
        return ABC.ContainsKey(num);
    }
}
