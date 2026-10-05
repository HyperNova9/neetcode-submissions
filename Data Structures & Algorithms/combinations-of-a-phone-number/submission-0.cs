public class Solution {
    public static void DFS_LetterComb(List<string> letterComb, StringBuilder tracking,
                                      Dictionary<char, List<char>> digitLetters, string digits,
                                      int deep) {
        if (tracking.Length == digits.Length) {
            letterComb.Add(new(tracking.ToString()));
            return;
        }
        int letter_i = 0;
        while (letter_i < digitLetters[digits[deep]].Count) {
            tracking.Append(digitLetters[digits[deep]][letter_i]);
            DFS_LetterComb(letterComb, tracking, digitLetters, digits, deep + 1);
            tracking.Remove(tracking.Length - 1, 1);
            letter_i++;
        }
    }

    public List<string> LetterCombinations(string digits) {
        Dictionary<char, List<char>> digitLetters =
            new() { { '2', new List<char>() { 'a', 'b', 'c' } },
                    { '3', new List<char>() { 'd', 'e', 'f' } },
                    { '4', new List<char>() { 'g', 'h', 'i' } },
                    { '5', new List<char>() { 'j', 'k', 'l' } },
                    { '6', new List<char>() { 'm', 'n', 'o' } },
                    { '7', new List<char>() { 'p', 'q', 'r', 's' } },
                    { '8', new List<char>() { 't', 'u', 'v' } },
                    { '9', new List<char>() { 'w', 'x', 'y', 'z' } } };
        List<string> res = new();
        if (digits.Length == 0)
            return res;
        DFS_LetterComb(res, new(), digitLetters, digits, 0);
        return res;
    }
}
