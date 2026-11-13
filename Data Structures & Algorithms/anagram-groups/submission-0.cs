public class Solution {
    public List<List<string>> GroupAnagrams(string[] strs) {
        List<List<string>> strListList = new List<List<string>>();
        List<string> strList = new List<string>();
        List<int> duplicationList = new List<int>();
        int[] alphabet = new int[26];
        int[] cmpAlphabet = new int[26];
        bool isSame = true;        

        for(int i=0; i<strs.Length; i++)
        {
            if(duplicationList.Contains(i))
            {
                continue;
            }

            strList.Add(strs[i]);

            foreach(char ch in strs[i])
            {
                alphabet[ch - 'a']++;
            }

            for(int j=i+1; j<strs.Length; j++)
            {
                foreach(char ch in strs[j])
                {
                    cmpAlphabet[ch - 'a']++;
                }

                for(int k=0; k<26; k++)
                {
                    if(alphabet[k] != cmpAlphabet[k])
                    {
                        isSame = false;
                        break;
                    }
                }

                if(isSame)
                {
                    duplicationList.Add(j);
                    strList.Add(strs[j]);
                }

                isSame = true;
                for(int l=0; l<26; l++)
                {
                    cmpAlphabet[l] = 0;
                }
            }

            for(int o=0; o<26; o++)
            {
                alphabet[o] = 0;
            }

            List<string> strList2 = new List<string>();
            foreach(string s in strList)
            {
                strList2.Add(s);
            }

            strListList.Add(strList2);
            strList.Clear();
        }

        return strListList;
    }
}
