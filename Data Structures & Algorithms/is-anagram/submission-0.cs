public class Solution {
    public bool IsAnagram(string s, string t) {
        int[] chars = new int[26];
        int[] chart = new int[26];

        foreach(char c in s)
        {
            chars[(int)c - 97]++;
        }

        foreach(char c in t)
        {
            chart[(int)c - 97]++;
        }

        for(int i=0; i<26; i++)
        {
            if(chars[i] != chart[i])
                return false;
        }

        return true;
    }
}
