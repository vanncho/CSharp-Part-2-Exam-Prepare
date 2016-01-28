using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Two_Is_Better_Than_One
{
    class TwoIsBetterThanOne
    {
        static bool IsPalindrom(long number)
        {
            string num = number.ToString();

            for (int i = 0; i < num.Length; i++)
            {
                if (num[i] != num[num.Length - i - 1])
                {
                    return false;
                }
            }

            return true;
        }

        private static int FindLuckyNumbers(long lowerBound, long upperBound)
        {
            long max = upperBound;
            int left = 0;
            var numbers = new List<long>{3,5};

            int count = 0;
            while (left < numbers.Count)
	        {
	            int right = numbers.Count;
                for (int i = left; i < right; i++)  
			    {
                    if (numbers[i] < max)
                    {
                        numbers.Add((numbers[i] * 10) + 3);
                        numbers.Add((numbers[i] * 10) + 5);
                    }
			    }

                left = right;
	        }

            foreach (var num in numbers)
            {
                if (num >= lowerBound && num <= upperBound && IsPalindrom(num))
                {
                    count++;
                }
            }

            return count;
        }
        static void Main()
        {
            string input = Console.ReadLine();
            string[] firstSplit = input.Split(' ');
            long lowerBound = long.Parse(firstSplit[0]);
            long upperBound = long.Parse(firstSplit[1]);

            int count = FindLuckyNumbers(lowerBound, upperBound);
            Console.WriteLine(count);

            //second task
            string inputList = Console.ReadLine();
            string[] split = inputList.Split(',');
            List<int> numbers = new List<int>();

            for (int i = 0; i < split.Length; i++)
            {
                numbers.Add(int.Parse(split[i]));
            }
            int percent = int.Parse(Console.ReadLine());

            int result = FindPercentResult(numbers, percent);

            Console.WriteLine(result);
        }

        private static int FindPercentResult(List<int> numbers, int percent)
        {
            numbers.Sort();

            for (int i = 0; i < numbers.Count; i++)
            {
                int count = 0;
                for (int j = 0; j < numbers.Count; j++)
                {
                    if (numbers[i] >= numbers[j])
                    {
                        count++;
                    }
                }

                if (count >= (numbers.Count) * (percent / 100.0))
                {
                    return numbers[i];
                }
            }

            return numbers[numbers.Count - 1];
        }
    }
}
