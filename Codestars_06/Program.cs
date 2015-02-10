using System;

namespace Codestars_06
{
    class Program
    {
        static bool isHappy(int[] number)
        {
            for (int i = 0; i < number.Length - 1; i++)
            {
                int sum1 = 0, sum2 = 0;
                for (int j = 0; j < i + 1; j++) sum1 += number[j];
                for (int j = i + 1; j < number.Length; j++) sum2 += number[j];
                if (sum1 == sum2) return true;
            }
            return false;
        }

        static void Main(string[] args)
        {
            int count = 0;
            int[] number = { 0, 0, 0, 0, 0, 0, 0, 0 };
            while (number[0] < 5)
            {
                if (isHappy(number)) count++;
                number[number.Length - 1]++;
                for (int i = number.Length - 1; i > 0; i--)
                    if (number[i] == 5) { number[i - 1]++; number[i] = 0; };
            }
            Console.WriteLine(count.ToString());
        }
    }
}