using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Three_in_One
{
    class ThreeInOne
    {
        static void Main(string[] args)
        {
            #region First Task
            string inputFirstTask = Console.ReadLine();
            string[] numbersAsStrings = inputFirstTask.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            //int[] numbers = new int[numbersAsStrings.Length];
            
            //int index = int.MinValue;
            //int fewerCounter = 0;
            //int twentyOneCounter = 0;
            //
            //for (int i = 0; i < numbers.Length; i++)
            //{
            //    numbers[i] = int.Parse(numbersAsStrings[i]);
            //
            //    if (numbers[i] > 21)
            //    {
            //        continue;
            //
            //    }
            //    else if (numbers[i] == 21)
            //    {
            //        index = i;
            //        twentyOneCounter++;
            //    }
            //    else if (numbers[i] < 21)
            //    {
            //        fewerCounter++;
            //    }
            //}
            //
            //if (fewerCounter == numbers.Length || twentyOneCounter > 1 || index == int.MinValue)
            //{
            //    Console.WriteLine(-1);
            //}
            //else if (index > int.MinValue)
            //{
            //    Console.WriteLine(index);
            //}

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
                    }
                }
                Console.WriteLine(winner.Value);
            }

            #endregion

            #region Second Task
            string inputSecondTask = Console.ReadLine();
            int f = int.Parse(Console.ReadLine());
            string[] numbersInStringArr = inputSecondTask.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int[] cakes = new int[numbersInStringArr.Length];
            
            for (int i = 0; i < cakes.Length; i++)
            {
                cakes[i] = int.Parse(numbersInStringArr[i]);
            }
            
            Array.Sort(cakes);
            
            int myBites = 0;
            
            for (int i = cakes.Length - 1; i > 0; i-=f)
            {
                myBites += cakes[i];
            }
            
            Console.WriteLine(myBites);
            #endregion

            #region Third Task
            string inputThirdTask = Console.ReadLine();
            string[] numbersTaskThree = inputThirdTask.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            //int[] number = new int[numbersTaskThree.Length];
            //
            //for (int i = 0; i < number.Length; i++)
            //{
            //    number[i] = int.Parse(numbersTaskThree[i]);
            //}
            //
            //int[] current = number.Take(3).ToArray();
            //int[] target = number.Skip(3).Take(3).ToArray();
            //
            //const int GOLD = 0;
            //const int SILVER = 1;
            //const int BRONZE = 2;
            //
            //int operations = 0;
            //
            //while (true)
            //{
            //    if (current[GOLD] >= target[GOLD] &&
            //        current[SILVER] >= target[SILVER] &&
            //        current[BRONZE] >= target[BRONZE])
            //    {
            //        Console.WriteLine(operations);
            //        break;
            //    }
            //    while (current[SILVER] > target[SILVER])
            //    {
            //        if (current[GOLD] < target[GOLD])
            //        {
            //            if (current[SILVER] - target[SILVER] >= 11)
            //            {
            //                current[SILVER] -= 11;
            //                current[GOLD] += 1;
            //                operations++;
            //            }
            //            else if (current[BRONZE] - target[BRONZE] >= 11 )
            //            {
            //                current[BRONZE] -= 11;
            //                current[SILVER] += 1;
            //                operations++;
            //            }
            //            else
            //            {
            //                Console.WriteLine(-1);
            //                break;
            //            }
            //        }
            //        else if (current[BRONZE] < target[BRONZE])
            //        {
            //            current[SILVER] -= 1;
            //            current[GOLD] += 9;
            //            operations++;
            //        }
            //        else
            //        {
            //            Console.WriteLine(operations);
            //            break;
            //        }
            //    }
            //
            //    while (current[SILVER] < target[SILVER])
            //    {
            //        if (current[GOLD] > target[GOLD])
            //        {
            //            current[GOLD] -= 1;
            //            current[SILVER] += 9;
            //            operations++;
            //        }
            //        else if (current[BRONZE] - target[BRONZE] >= 11)
            //        {
            //            current[SILVER] -= 1;
            //            current[BRONZE ] -= 11;
            //            operations++;
            //        }
            //        else
            //        {
            //            Console.WriteLine(-1);
            //            break;
            //        }
            //    }
            //
            //    if (current[GOLD] < target[GOLD])
            //    {
            //        if (current[BRONZE] - target[BRONZE] >= 11)
            //        {
            //            current[SILVER] += 1;
            //            current[GOLD] -= 11;
            //            operations++;
            //        }
            //        else
            //        {
            //            Console.WriteLine(-1);
            //            break;
            //        }
            //    }
            //
            //    if (current[BRONZE] < target[BRONZE])
            //    {
            //        if (current[GOLD] > target[GOLD])
            //        {
            //            current[SILVER] += 9;
            //            current[GOLD] -= 1;
            //            operations++;
            //        }
            //        else
            //        {
            //            Console.WriteLine(-1);
            //            break;
            //        }
            //    }
            //}

            Console.WriteLine(-1);
            #endregion
        }
    }
}
