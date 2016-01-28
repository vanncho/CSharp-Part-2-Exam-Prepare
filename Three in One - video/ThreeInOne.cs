using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Three_in_One___video
{
    class ThreeInOne
    {
        static void Main(string[] args)
        {
            Problem1();
            Problem2();
        }

        private static void Problem2()
        {
            
        }

        private static void Problem1()
        {
            string inputFirstTask = Console.ReadLine();
            string[] numbersAsStrings = inputFirstTask.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int[] scores = new int[numbersAsStrings.Length];

            for (int i = 0; i < scores.Length; i++)
            {
                scores[i] = int.Parse(numbersAsStrings[i]);
            }

            int? winner = null;

            for (int i = 0; i < scores.Length; i++)
            {
                int currentScore = scores[i];
                if (currentScore <= 21)
                {
                    if (winner == null || currentScore > scores[winner.Value])
                    {
                        winner = i;
                    }
                }
            }

            if (winner == null)
            {
                Console.WriteLine(-1);
            }
            else
            {
                for (int i = 0; i < scores.Length; i++)
                {
                    if (scores[i] == scores[winner.Value] && i != winner.Value)
                    {
                        Console.WriteLine(-1);
                        return;
                    }
                }
                Console.WriteLine(winner.Value);
            }
        }
    }
}
