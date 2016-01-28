using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoroTheRabbit
{
    class JoroTheRabbit
    {
        static void Main()
        {
            string input = Console.ReadLine();
            string[] inputAsArray = input.Split(new char[] {',', ' '},StringSplitOptions.RemoveEmptyEntries);

            int[] numbers = new int[inputAsArray.Length];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = int.Parse(inputAsArray[i]);
            }

            int bestPath = 0;

            for (int startPath = 0; startPath < numbers.Length; startPath++)
            {
                for (int jump = 1; jump < numbers.Length; jump++)
                {
                    int tempStart = startPath;
                    int currPath = 1;
                    int nextJump = (tempStart + jump) % numbers.Length;

                    while (numbers[tempStart] < numbers[nextJump])
                    {
                        currPath++;
                        tempStart = nextJump;
                        nextJump = (tempStart + jump) % numbers.Length;
                    }

                    if (bestPath < currPath)
                    {
                        bestPath = currPath;
                    }
                }
            }

            Console.WriteLine(bestPath);
        }
    }
}
