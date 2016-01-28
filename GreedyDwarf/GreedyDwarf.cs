using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreedyDwarf
{
    class GreedyDwarf
    {
        static void Main()
        {
            string valleyInput = Console.ReadLine();
            int[] valley = (valleyInput.Split(new char[] {',', ' '},StringSplitOptions.RemoveEmptyEntries)).Select(int.Parse).ToArray();


            int numberOfPatterns = int.Parse(Console.ReadLine());
            long bestResult = long.MinValue;

            for (int i = 0; i < numberOfPatterns; i++)
            {
                long tempResult = GetThePattern(valley);

                if (tempResult > bestResult)
                {
                    bestResult = tempResult;
                }
            }

            Console.WriteLine(bestResult);
        }

        public static long GetThePattern(int[] valley)
        {
            string patternInput = Console.ReadLine();
            int[] patternToArray = (patternInput.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)).Select(int.Parse).ToArray();

            bool[] visitedValleyArea = new bool[valley.Length];
            long coins = 0;
            coins += valley[0];
            visitedValleyArea[0] = true;
            //int patternIndex = 0;
            //int valleyIndex = 0;
            int counter = 0;

            //while (valley[valleyIndex] > 0 || valley[valleyIndex] < valley.Length)
            //{
            //    patternIndex = counter % patternToArray.Length;
            //
            //    valleyIndex += 0 + patternToArray[patternIndex];
            //
            //    if (visitedValleyArea[valleyIndex] == false)
            //    {
            //        coins += valley[valleyIndex];
            //        visitedValleyArea[valleyIndex] = true;
            //    }
            //    else
            //    {
            //        return coins;
            //    }
            //
            //    patternIndex++;
            //    visitedValleyArea[valleyIndex] = true;
            //    counter++;
            //}
            //return 0;



            while (true)
            { 
                for (int i = 0; i < patternToArray.Length; i++)
                {
                    int nextMove = counter + patternToArray[i];

                    if (nextMove >= 0 && nextMove < valley.Length && !visitedValleyArea[nextMove])
                    {
                        coins += valley[nextMove];
                        visitedValleyArea[nextMove] = true;
                        counter = nextMove;
                    }
                    else
                    {
                        return coins;
                    }
                }
            }
        }
    }
}
