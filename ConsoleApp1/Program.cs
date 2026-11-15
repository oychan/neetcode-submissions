using System.Collections.Immutable;
using System.ComponentModel;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp1;

class Program
{
    static void Main(string[] args)
    {
        int[] nums = new int[6] { 3, 1, 2, 2, 3, 3 };
        int k = 2;

        HashSet<int> arrHashSet = new HashSet<int>();
        List<int> arrList = new List<int>();

        nums.Sort();
        arrHashSet = nums.ToHashSet();
        arrList = arrHashSet.ToList();

        int[] countArr = new int[arrList.Count()];
        int cnt = 0;

        for (int i = 0; i < arrList.Count(); i++)
        {
            for(int j=0; j<nums.Count(); j++)
            {
                if (arrList[i] == nums[j])
                    cnt++;
            }

            countArr[i] = cnt;
            cnt = 0;
        }

        int temp = 0;
        int index = 0;
        int iterationCount = 0;
        int[] returnArr = new int[k];

        for (int i = 0; i < k; i++)
        {
            foreach (int j in countArr)
            {
                if (j > temp)
                {
                    temp = j;
                    index = iterationCount;
                }
                iterationCount++;
            }
            Console.WriteLine(temp);
            Console.WriteLine(index);
            Console.WriteLine();

            returnArr[i] = arrList[index];

            countArr[index] = 0;
            temp = 0;
            iterationCount = 0;
        }

        foreach(int i in returnArr)
        {
            Console.WriteLine(i);
        }
    }
}