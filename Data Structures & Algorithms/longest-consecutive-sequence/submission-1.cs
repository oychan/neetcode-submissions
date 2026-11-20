public class Solution {
    public int LongestConsecutive(int[] nums) {
        SortedSet<int> sortedSetNums = new SortedSet<int>(nums);
        int consecutive = 1;
        int max = 1;

        nums = sortedSetNums.ToArray();

        if (nums.Length == 0)
            return 0;

        for (int i = 0; i < nums.Length - 1; i++)
        {
            if (nums[i + 1] - nums[i] == 1)
            {
                consecutive++;
                if (consecutive > max)
                    max = consecutive;
            }
            else
            {
                consecutive = 1;
            }
        }

        return max;
    }
}
