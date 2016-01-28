using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Two_Girls_One_Path
{
    class TwoGirlsOnePath
    {
        static string won = "";
        static long[] collectedFlowers = new long[2];
        static void Main()
        {
            string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            long[] flowersPath = new long[input.Length];
            
            for (int i = 0; i < input.Length; i++)
            {
                flowersPath[i] = long.Parse(input[i]);
            }

            collectedFlowers = CollectFlowers(flowersPath);

            Console.WriteLine(won);
            Console.WriteLine("{0} {1}", collectedFlowers[0], collectedFlowers[1]);
        }

        static long[] CollectFlowers(long[] input)
        {
            long mollyFlowers = 0;
            long dollyFlowers = 0;

            int mollyCurrentIndex = 0;
            int dollyCurrentIndex = input.Length - 1;

            int mollyNextIndex = 0;
            int dollyNextIndex = 0;

            while (true)
            {
                if (mollyCurrentIndex == dollyCurrentIndex)
                {
                    if (mollyCurrentIndex % 2 == 0)
                    {
                        mollyFlowers += input[mollyCurrentIndex] / 2;
                        dollyFlowers += input[dollyCurrentIndex] / 2;

                        long newIndex = input[dollyCurrentIndex] - ((input[mollyCurrentIndex] / 2) + (input[dollyCurrentIndex] / 2));

                        input[mollyCurrentIndex] = newIndex;
                    }
                    else
                    {
                        mollyFlowers += input[mollyCurrentIndex] / 2;
                        dollyFlowers += input[dollyCurrentIndex] / 2;

                        int newIndex = 1;

                        input[mollyCurrentIndex] = newIndex;
                    }
                }
                else
                {
                    mollyFlowers += input[mollyCurrentIndex];
                    dollyFlowers += input[dollyCurrentIndex];
                }

                mollyNextIndex = mollyCurrentIndex + (int)input[mollyCurrentIndex];
                //mollyNextIndex = (int)(mollyCurrentIndex + mollyFlowers) % input.Length;
                dollyNextIndex = dollyCurrentIndex - (int)input[dollyCurrentIndex];

                if (mollyNextIndex > input.Length)
                {
                    mollyNextIndex = mollyNextIndex - input.Length;
                }
                if (dollyNextIndex < 0)
                {
                    dollyNextIndex = (dollyNextIndex + input.Length - 1) + 1;
                }

                if (input[mollyCurrentIndex] == 0 && input[dollyCurrentIndex] == 0)
                {
                    collectedFlowers[0] = mollyFlowers;
                    collectedFlowers[1] = dollyFlowers;
                    won = "Draw";
                    return collectedFlowers;
                }

                if (input[mollyCurrentIndex] == 0)
                {
                    collectedFlowers[0] = mollyFlowers;
                    collectedFlowers[1] = dollyFlowers;
                    won = "Dolly";
                    return collectedFlowers;
                }

                if (input[dollyCurrentIndex] == 0)
                {
                    collectedFlowers[0] = mollyFlowers;
                    collectedFlowers[1] = dollyFlowers;
                    won = "Molly";
                    return collectedFlowers;
                }

                input[mollyCurrentIndex] = 0;
                input[dollyCurrentIndex] = 0;

                mollyCurrentIndex = mollyNextIndex;
                dollyCurrentIndex = dollyNextIndex;

            }
        }
    }
}
