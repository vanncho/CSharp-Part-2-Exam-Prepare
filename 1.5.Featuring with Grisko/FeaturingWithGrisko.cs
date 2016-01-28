using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._5.Featuring_with_Grisko
{
    class FeaturingWithGrisko
    {
        static void Main()
        {
            string input = Console.ReadLine();
            char[] inputAsCharArray = input.ToCharArray();
            Array.Sort(inputAsCharArray);
            int counter = 0;

            do
            {
                if (IsMatch(inputAsCharArray))
                {
                    counter++;   
                }
            } while (NextPermutation(inputAsCharArray));
            Console.WriteLine(counter);
        }

        /// <summary>
        /// Transform array of chars to next permutation.
        /// Rearranges the elements into the next lexicographically greater permutation.
        /// </summary>
        /// <param name="array">The array of elements to be sorted</param>
        /// <returns>
        /// true if the function could rearrange the object as a lexicographically greater permutation.
        /// Otherwise, the function returns false to indicate that the arrangement is not greater than the previous, but the lowest possible (sorted in ascending order).
        /// </returns>
        static bool NextPermutation(char[] array)
        {
            for (int index = array.Length - 2; index >= 0; index--)
            {
                if (array[index] < array[index + 1])
                {
                    int swapWithIndex = array.Length - 1;
                    while (array[index] >= array[swapWithIndex])
                    {
                        swapWithIndex--;
                    }

                    // Swap i-th and j-th elements
                    var tmp = array[index];
                    array[index] = array[swapWithIndex];
                    array[swapWithIndex] = tmp;

                    Array.Reverse(array, index + 1, array.Length - index - 1);
                    return true;
                }
            }

            // No more permutations
            return false;
        }

        static bool IsMatch(char[] word)
        {
            for (int i = 1; i < word.Length; i++)
            {
                if (word[i] == word[i - 1])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
