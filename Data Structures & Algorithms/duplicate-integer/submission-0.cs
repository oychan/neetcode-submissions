public class Solution {
    public bool hasDuplicate(int[] nums) {
        for(int i=0; i<nums.Length-1; i++)
        {
            int temp = nums[i];
            for(int j=i+1; j<nums.Length; j++)
            {
                if(temp == nums[j])
                    return true;
            }
        }

        return false;
    }
}