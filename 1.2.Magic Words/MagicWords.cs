using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._2.Magic_Words
{
    class MagicWords
    {
        static void Main()
        {

            int n = int.Parse(Console.ReadLine());
            List<string> listOfWords = new List<string>();
            
            for (int i = 0; i < n; i++)
            {
                listOfWords.Add(Console.ReadLine());
            }

            for (int i = 0; i < n; i++)
            {

                int position = (listOfWords[i].Length) % (n + 1);

                //ВАРИАНТ 1:
                string tempWord = listOfWords[i];
                listOfWords[i] = null;
                listOfWords.Insert(position, tempWord);
                listOfWords.Remove(null);

                ////ВАРИАНТ 2:
                //listOfWords.Insert(position, listOfWords[i]);
                //if (position < i)
                //{
                //    listOfWords.RemoveAt(i + 1);
                //}
                //else
                //{
                //    listOfWords.RemoveAt(i);
                //}
            }

            StringBuilder text = new StringBuilder();
            int maxLength = 0;

            foreach (var word in listOfWords)
            {
                maxLength = Math.Max(maxLength, word.Length);
            }

            for (int i = 0; i < maxLength; i++)
            {
                foreach (var word in listOfWords)
                {
                    if (word.Length > i)
                    {
                        text.Append(word[i]);
                    }
                }
            }

            Console.WriteLine(text);
        }
    }
}
