using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codestars_05
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            for (long i = 0; i < 1000000; i++)
            {
                var str = i.ToString();
                while (str.Length < 6) str = "0" + str;
                if (str[0] + str[1] + str[2] == str[3] + str[4] + str[5]) count++;
            }
            Console.WriteLine(count.ToString());
        }
    }
}
