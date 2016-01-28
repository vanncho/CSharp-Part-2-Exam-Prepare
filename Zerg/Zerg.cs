using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zerg
{
    class Zerg
    {
        static void Main()
        {
            string[] zergNumerals = { "Rawr", "Rrrr", "Hsst", "Ssst", "Grrr", "Rarr", "Mrrr", "Psst", "Uaah", "Uaha", "Zzzz", "Bauu", "Djav", "Myau", "Gruh" };
            List<int> tempDecode = new List<int>();
            StringBuilder sb = new StringBuilder();

            string input = Console.ReadLine();
            int count = 0;

            for (int i = 0; i < input.Length; i++)
            {
                sb.Append(input[i]);
                count++;

                if (count == 4)
                {
                    tempDecode.Add(Array.IndexOf(zergNumerals, sb.ToString()));
                    count = 0;
                    sb.Clear();
                }
            }

            tempDecode.Reverse();
            long multiply = 1;
            long result = 0;

            for (int i = 0; i < tempDecode.Count; i++)
            {
                result += tempDecode[i] * multiply;
                multiply *= 15;
            }

            Console.WriteLine(result);
        }
    }
}
