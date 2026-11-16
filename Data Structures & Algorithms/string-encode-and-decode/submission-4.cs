public class Solution {

    public string Encode(IList<string> strs) {
        string? str = null;

        foreach(string s in strs)
        {
            str += s;
            str += "\u25b6";
        }

        if(str != null && str.Length >= 1)
        {
            str = str.Remove(str.Length - 1);
        }

        return str;
    }

    public List<string> Decode(string s) {
        List<string> strList = new List<string>();
        int cnt = 0;

        if(s == null)
            return strList;

        foreach (char c in s)
        {
            if (c == '\u25b6')
            {
                cnt++;
            }
        }

        string[] strArr = new string[++cnt];
        
        strArr = s.Split('\u25b6');
        foreach(string str in strArr)
        {
            strList.Add(str);
        }

        return strList;
   }
}
