namespace Calculation_Problem
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    class CalculationProblem
    {
        static List<int> resultAsNumber = new List<int>();
        static void Main()
        {
            string input = Console.ReadLine();
            var words = input.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);

            List<List<int>> digits = FillDigitsInArray(words);

            int multiply = 1;
            int result = 0;
            int sum = 0;
            for (int i = 0; i < words.Length; i++)
            {
                foreach (var digit in digits[i])
	            {
		            result += digit * multiply;
                    multiply *= 23;
	            }

                sum += result;
                multiply = 1;
                result = 0;
            }

            resultAsNumber = FinalWordResult(sum);
            StringBuilder word = new StringBuilder();

            foreach (var digit in resultAsNumber)
            {
                char letter = Convert.ToChar(digit + 97);
                word.Append(letter);
            }
         
            Console.WriteLine("{0} = {1}", word, sum);
        }

        private static List<int> FinalWordResult(int sum)
        {
            while (sum > 0)
            {
                int rest = sum % 23;
                sum = sum / 23;
                resultAsNumber.Add(rest);
            }
            resultAsNumber.Reverse();
            return resultAsNumber;
        }

        static List<List<int>> FillDigitsInArray(string[] words)
        {
            List<List<int>> digits = new List<List<int>>();

            for (int i = 0; i < words.Length; i++)
            {
                string currentWord = words[i];
                var tempList = new List<int>();

                foreach (var ch in currentWord)
                {
                    int digit = int.Parse((ch - 97).ToString());
                    tempList.Add(digit); 
                }
                tempList.Reverse();
                digits.Add(tempList);
            }

            return digits;
        }
    }
}
