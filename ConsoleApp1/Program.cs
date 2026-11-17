using System.Collections.Immutable;
using System.ComponentModel;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp1;

class Program
{
    static void Main(string[] args)
    {
        int[] nums = new int[] { -10, -1, 0, 1, 2, 3, 4, 5 };
        int[] outNums = new int[nums.Length];
        int baseNum = 1;

        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = 0; j < nums.Length; j++)
            {
                if (i == j)
                    continue;

                baseNum *= nums[j];
            }

            outNums[i] = baseNum;
            baseNum = 1;
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