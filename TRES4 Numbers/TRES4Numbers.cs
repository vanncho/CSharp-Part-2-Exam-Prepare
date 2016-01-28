namespace TRES4_Numbers
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;
    using System.Text;

    class TRES4Numbers
    {
        static void Main()
        {
            string[] tresDigits = new string[] {"LON+","VK-","*ACAD","^MIM","ERIK|","SEY&","EMY>>","/TEL","<<DON"};

            BigInteger n = BigInteger.Parse(Console.ReadLine());
            StringBuilder text = new StringBuilder();
            List<int> tempDigits = new List<int>();

            BigInteger number = n;

            if (n == 0)
            {
                Console.WriteLine(tresDigits[0]);
            }
            else
            {
                while (number > 0)
                {
                    BigInteger rest = number % 9;
                    number = number / 9;
                    tempDigits.Add((int)rest);
                }

                tempDigits.Reverse();

                for (int i = 0; i < tempDigits.Count; i++)
                {
                    text.Append(tresDigits[tempDigits[i]]);
                }

                Console.WriteLine(text.ToString());
            }    
        }
    }
}
