namespace Bunny_Factory
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;
    using System.Text;

    class BunnyFactory
    {
        static void Main()
        {
            StringBuilder cages = new StringBuilder();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }
                cages.Append(input);
            }

            int cagesToTake = int.Parse((cages[0] - '0').ToString());
            
            int cagesToRemove = 1;

            while (cagesToTake < cages.Length)
            {
                cages.Remove(0, cagesToRemove);
                BigInteger sum = 0;
                BigInteger product = 1;
                
                for (int i = 0; i < cagesToTake; i++)
                {
                    sum += BigInteger.Parse((cages[i] - '0').ToString());
                    product *= BigInteger.Parse((cages[i] - '0').ToString());
                    cages.Insert(0, "*", 1);
                    cages.Remove(0, 1);
                }
                string digitsToAppend = AppendTheSumAndProduct(cages, sum, product);
               
                cages.Remove(0, cagesToTake);
                cages.Insert(0, digitsToAppend); 

                if (cagesToRemove >= cages.Length)
                {
                    break;
                }

                cagesToRemove++;

                int cagesToSum = cagesToRemove;
                cagesToTake = SumOfDigitsToAppend(digitsToAppend, cagesToRemove);
            }

            for (int i = 0; i < cages.Length; i++)
            {
                if (i != cages.Length - 1)
                {
                    Console.Write("{0} ", cages[i]);
                }
                else
                {
                    Console.WriteLine(cages[i]);
                }
                
            }
        }

        private static int SumOfDigitsToAppend(string digitsToAppend, int count)
        {
            int cagesToTake = 0;

            for (int i = 0; i < count; i++)
            {
                cagesToTake += int.Parse(digitsToAppend[i].ToString());
            }

            return cagesToTake;
        }

        static string AppendTheSumAndProduct(StringBuilder cages, BigInteger sum, BigInteger product)
        {
            StringBuilder tempCages = new StringBuilder();

            tempCages.Append(sum.ToString());
            tempCages.Append(product.ToString());

            while (true)
            {
                int zeroIndex = tempCages.ToString().IndexOf('0');

                if (zeroIndex < 0)
                {
                    break;
                }

                tempCages.Remove(zeroIndex, 1);
            }

            while (true)
            {
                int oneIndex = tempCages.ToString().IndexOf('1');

                if (oneIndex < 0)
                {
                    break;
                }

                tempCages.Remove(oneIndex, 1);
            }

            string cagesToAdd = tempCages.ToString();
            return cagesToAdd;
        }
    }
}
