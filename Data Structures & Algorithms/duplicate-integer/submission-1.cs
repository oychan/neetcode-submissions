public class Solution {
    public bool hasDuplicate(int[] nums) {
        HashSet<int> hashSet = new HashSet<int>();

        foreach(int n in nums)
        {
            if(hashSet.Contains(n)){
                return true;
            }
            hashSet.Add(n);
        }

        return false;
    }
}