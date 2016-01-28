using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moving_Letters
{
    class MovingLetters
    {
        static StringBuilder GetStrangeWordCombination(string[] words)
        {
            StringBuilder strangeWordCombination = new StringBuilder();
            int longestWord = 0;

            //find the longest word
            for (int i = 0; i < words.Length; i++)
            {
                if (longestWord < words[i].Length)
                {
                    longestWord = words[i].Length;
                }
            }

            //reorder the letters
            for (int i = 0; i < longestWord; i++)
            {
                for (int j = 0; j < words.Length; j++)
                {
                    string currWord = words[j];

                    if (i < currWord.Length)
                    {
                        char lastLetter = currWord[currWord.Length - 1 - i];
                        strangeWordCombination.Append(lastLetter);
                    }
                }
            }

            return strangeWordCombination;
        }
        static void Main()
        {
            string[] words = Console.ReadLine().Split(new char[] {' '},StringSplitOptions.RemoveEmptyEntries);

            StringBuilder strangeWord = GetStrangeWordCombination(words);

            string result = MoveTheLetters(strangeWord);

            Console.WriteLine(result);
        }

        private static string MoveTheLetters(StringBuilder strangeWord)
        {
            for (int i = 0; i < strangeWord.Length; i++)
            {
                char currSymbol = strangeWord[i];
                int moveIndex = char.ToLower(currSymbol) - 'a' + 1;

                strangeWord.Remove(i, 1);
                int nextPosition = (i + moveIndex) % (strangeWord.Length + 1);

                strangeWord.Insert(nextPosition, currSymbol);
            }
            return strangeWord.ToString();
        }   
    }
}
