using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _9Gag_Numbers
{
    class Program
    {
        static void Main()
        {
            string[] gagNumbers = { "-!", "**", "!!!", "&&", "&-", "!-", "*!!!", "&*!", "!!**!-" };

            string input = Console.ReadLine();
            BigInteger decimalNumber = ConvertToDecimalRepresentation(ProcessTheInput(input, gagNumbers));
            Console.WriteLine(decimalNumber);
        }
        private static BigInteger ConvertToDecimalRepresentation(List<int> list)
        {
            BigInteger result = 0;
            BigInteger multiply = 1;

            for (int i = 0; i < list.Count; i++)
            {
                result += list[i] * multiply;
                multiply *= 9;
            }

            return result;
        }

        static List<int> ProcessTheInput(string input, string[] gagNumbers)
        {
            StringBuilder tempDigit = new StringBuilder();
            List<int> tempDigitsList = new List<int>();

            for (int i = 0; i < input.Length; i++)
            {
                tempDigit.Append(input[i]);

                if (Array.IndexOf(gagNumbers, tempDigit.ToString()) >= 0)
                {
                    int index = Array.IndexOf(gagNumbers, tempDigit.ToString());
                    tempDigitsList.Add(index);
                    tempDigit.Clear();
                }
            }

            tempDigitsList.Reverse();

            return tempDigitsList;
        }
    }
}
