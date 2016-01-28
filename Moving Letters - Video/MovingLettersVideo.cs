using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moving_Letters___Video
{
    class MovingLettersVideo
    {

        static StringBuilder ExtractLetters(string[] words)
        {
            StringBuilder result = new StringBuilder();
            int maxWordLength = 0;
            
            //find longest word
            for (int i = 0; i < words.Length; i++)
            {
                if (maxWordLength < words[i].Length)
                {
                    maxWordLength = words[i].Length;
                }
            }

            for (int i = 0; i < maxWordLength; i++)
            {
                for (int j = 0; j < words.Length; j++)
                {
                    string currentWord = words[j];

                    if (i < currentWord.Length)
                    {
                        int lastLetter = currentWord.Length - 1 - i;
                        result.Append(currentWord[lastLetter]);
                    }
                }
            }

            return result;
        }

        static string MoveLetters(StringBuilder strangePieceOfWords)
        {
            for (int i = 0; i < strangePieceOfWords.Length; i++)
            {
                char currentSymbol = strangePieceOfWords[i];
                int transition = char.ToLower(currentSymbol) - 'a' + 1;

                strangePieceOfWords.Remove(i, 1);
                int nextPosition = (i + transition) % (strangePieceOfWords.Length + 1);
                strangePieceOfWords.Insert(nextPosition, currentSymbol);
            }

            return strangePieceOfWords.ToString();
        }
        static void Main()
        {
            string[] words = Console.ReadLine().Split(new char[] {' '},StringSplitOptions.RemoveEmptyEntries);

            StringBuilder strangeCombinationOfLetters = ExtractLetters(words);

            string finalResult = MoveLetters(strangeCombinationOfLetters);

            Console.WriteLine(finalResult);

        }
    }
}
