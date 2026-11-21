public class Solution {
    public bool IsPalindrome(string s) {
        s = s.ToLower();

        for (int i = 0; i < s.Length; i++)
        {
            if (!char.IsAsciiDigit(s[i]) && !char.IsAsciiLetter(s[i]))
            {
                s = s.Remove(i, 1);
                i -= 1;
            }
        }
        
        char[] reverse = s.ToArray();

        Array.Reverse(reverse);

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] != reverse[i])
            {
                return false;
            }
        }

        return true;
    }
}
