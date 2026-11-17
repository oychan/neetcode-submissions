using System.Collections.Immutable;
using System.ComponentModel;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp1;

class Program
{
    static void Main(string[] args)
    {
        int[] nums = new int[] { -10, -1, 0, 0, 1, 2, 3, 4, 5 };
        int[] outNums = new int[nums.Length];
        int baseNum = 1;
        int zeroNum = 1;

        for(int i=0; i<nums.Length; i++)
        {
            baseNum *= nums[i];
            if (nums[i] != 0)
                zeroNum *= nums[i];
        }

        for(int i=0; i<nums.Length; i++)
        {
            if (nums[i] == 0)
                outNums[i] = zeroNum;
            else
                outNums[i] = baseNum / nums[i];
        }

        Console.Write("nums: ");
        foreach(int n in nums)
        {
            Console.Write(n);
            Console.Write(' ');
        }
        Console.WriteLine();

        Console.Write("out nums: ");
        foreach(int n in outNums)
        {
            Console.Write(n);
            Console.Write(' ');
        }
    }
}