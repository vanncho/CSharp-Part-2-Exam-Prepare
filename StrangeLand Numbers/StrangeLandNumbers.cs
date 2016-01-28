namespace StrangeLand_Numbers
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    class StrangeLandNumbers
    {
        static void Main()
        {
            string[] strangeDigits = { "f", "bIN", "oBJEC", "mNTRAVL", "lPVKNQ", "pNWE", "hT" };
            //pNWE  oBJEC  bIN  f
            // 
            string input = Console.ReadLine();

            List<int> tempNumber = ExtractDigitsFromTheInput(input, strangeDigits);

            long decimalNumber = CalculateDecimalNumber(tempNumber);

            Console.WriteLine(decimalNumber);
        }

        static long CalculateDecimalNumber(List<int> tempNumber)
        {
            long result = 0;
            long multiply = 1;

            for (int i = 0; i < tempNumber.Count; i++)
            {
                result += tempNumber[i] * multiply;
                multiply *= 7;
            }

            return result;
        }

        static List<int> ExtractDigitsFromTheInput(string input, string[] strangeDigits)
        {
            StringBuilder digits = new StringBuilder();
            List<int> finalNumber = new List<int>();
            

            for (int i = 0; i < input.Length; i++)
            {
                digits.Append(input[i]);

                if (Array.IndexOf(strangeDigits, digits.ToString()) >= 0)
                {
                    int index = Array.IndexOf(strangeDigits, digits.ToString());
                    finalNumber.Add(index);
                    digits.Clear();
                }    
            }
            finalNumber.Reverse();

            return finalNumber;
        }
    }
}
