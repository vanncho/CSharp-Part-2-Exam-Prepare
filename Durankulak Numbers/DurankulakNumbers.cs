using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Durankulak_Numbers
{
    class DurankulakNumbers
    {
        static void Main()
        {
            List<string> durankulakNumbers = GenerateDurankulakNumbers();

            string input = Console.ReadLine();

            List<uint> decimalRepresentations = CalculateDurankulakNumber(durankulakNumbers,input);

            ulong decimalNumber = CalculateDurankulakNumber(decimalRepresentations);

            Console.WriteLine(decimalNumber);
        }

        private static ulong CalculateDurankulakNumber(List<uint> decimalRepresentations)
        {
            ulong result = 0;

            for (int i = 0; i < decimalRepresentations.Count; i++)
            {
                result += decimalRepresentations[decimalRepresentations.Count - i - 1] * (ulong)(Math.Pow(168, i));
            }

            return result;
        }

        private static List<uint> CalculateDurankulakNumber(List<string> durankulakNumbers, string input)
        {
            List<uint> decimalRepesentations = new List<uint>();
            char buffer = new char();

            foreach (char symbol in input)
            {
                if (symbol >= 'A' && symbol <= 'Z')
                {
                    string durankulakDigit = string.Empty;
                    uint decimalRepresentation = 0;
                    if (buffer != default(char))
                    {
                        //string durankulakDigit = string.Format("{0}{1}", buffer, symbol); //е същото
                        durankulakDigit = buffer + symbol.ToString();
                        buffer = default(char);
                    }
                    else
                    {
                        durankulakDigit = symbol.ToString();
                    } 

                    decimalRepresentation = (uint)durankulakNumbers.IndexOf(durankulakDigit);
                    decimalRepesentations.Add(decimalRepresentation);
                }
                else
                {
                    buffer = symbol;
                }
            }

            return decimalRepesentations;
        }

        private static List<string> GenerateDurankulakNumbers()
        {
            List<string> digits = new List<string>();

            for (char i = 'A'; i <= 'Z'; i++)
            {
                digits.Add(i.ToString());
            }

            for (char i = 'a'; i <= 'f'; i++)
            {
                for (char j = 'A'; j <= 'Z'; j++)
                {
                    digits.Add(i + j.ToString());
                }
            }

            return digits;
        }
    }
}
