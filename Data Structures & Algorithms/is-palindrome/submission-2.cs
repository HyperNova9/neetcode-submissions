public class Solution {
    public bool IsPalindrome(string s) 
    {
        var new_s = new string (s.Where(x => char.IsLetter(x) || char.IsDigit(x)).ToArray());
        var s_flipped = new string(new_s.Reverse().ToArray());
        return new_s.ToLower() == s_flipped.ToLower();
    }
}
