using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isPalindrom
{
    class isPalindrom
    {
        static void Main()
        {
            ////Check is Palindrom
            //string num = "333";
            //bool isPalindrom = true;
            //
            //for (int i = 0; i < num.Length; i++)
            //{
            //    if (num[i] != num[num.Length - i - 1])
            //    {
            //        isPalindrom = false;
            //    }
            //}
            //
            //if (isPalindrom)
            //{
            //    isPalindrom = true;
            //}
            //
            //Console.WriteLine(isPalindrom);

            //Generate Palindrom
            int max = 99;
            var numbers = new List<int>{3,5};
            int left = 0;
            
            while (left < numbers.Count / 2)
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
                Console.WriteLine(num);
            }
        }
    }
}
