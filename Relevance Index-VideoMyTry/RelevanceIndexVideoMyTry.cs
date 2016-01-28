namespace Relevance_Index_VideoMyTry
{
    using System;
    using System.Collections.Generic;
    class RelevanceIndexVideoMyTry
    {
        static string[] symbols = new string[] {" ", ",", ".", "(", ")", ";", "-", "!", "?" };
        static void Main()
        {
            string searchWord = Console.ReadLine();
            int numberOfParagraphs = int.Parse(Console.ReadLine());
            List<string> paragraphs = new List<string>();
            List<int> indexes = new List<int>();

            for (int i = 0; i < numberOfParagraphs; i++)
            {
                string[] currentLineWord = Console.ReadLine().Split(symbols, StringSplitOptions.RemoveEmptyEntries);
                int relevanceIndex = 0;

                for (int j = 0; j < currentLineWord.Length; j++)
                {
                    if (currentLineWord[j].ToLower() == searchWord.ToLower())
                    {
                        relevanceIndex++;
                        currentLineWord[j] = currentLineWord[j].ToUpper();
                    }
                }

                paragraphs.Add(string.Join(" ", currentLineWord));
                indexes.Add(relevanceIndex);
            }

            List<string> sortedParagraphs = new List<string>();

            while (sortedParagraphs.Count < paragraphs.Count)
            {
                int maxIndex = 0;
                int maxRelevanceIndex = 0;

                for (int i = 0; i < indexes.Count; i++)
                {
                    if (maxIndex < indexes[i])
                    {
                        maxIndex = indexes[i];
                        maxRelevanceIndex = i;
                    }
                }

                sortedParagraphs.Add(paragraphs[maxRelevanceIndex]);
                indexes[maxRelevanceIndex] = -1;
            }

            Console.WriteLine(string.Join(Environment.NewLine, sortedParagraphs));
        }
    }
}
