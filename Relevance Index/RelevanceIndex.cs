namespace Relevance_Index
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;

    class RelevanceIndex
    {
        static void Main()
        {
            string searchWord = Console.ReadLine();
            int textLines = int.Parse(Console.ReadLine());

            string[] text = new string[textLines];
            StringBuilder processCurrentLine = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                processCurrentLine.Append(Console.ReadLine());
                text[i] = RemovePunctuations(processCurrentLine);
                processCurrentLine.Clear();
            }

            string nullValue = "-123";
            List<string> newText = new List<string>();

            for (int i = 0; i < textLines; i++)
            {
                newText.Add(nullValue);
            }

            for (int i = 0; i < textLines; i++)
            {
                int count = 0;
                int previouseCount = 0;
                int index = -1;
                processCurrentLine.Append(text[i]);
                

                for (int j = 0; j <= textLines; j++)
                {
                    index = text[i].IndexOf(searchWord, index + 1);
                    if (index >= 0)
                    {
                        count++;
                        processCurrentLine.Replace(searchWord, searchWord.ToUpper(), index, searchWord.Length);
                        previouseCount = count;
                    }
                    else
                    {
                        //newText[previouseCount - 1] = processCurrentLine.ToString();
                        newText.Insert(previouseCount, processCurrentLine.ToString());

                        processCurrentLine.Clear();
                        newText.Remove(nullValue);
                        break;
                    }
                }
            }


            for (int i = newText.Count - 1; i >= 0; i--)
            {
                Console.WriteLine(newText[i]);
            }
        }

        static string RemovePunctuations(StringBuilder currentLine)
        {
            StringBuilder processLine = new StringBuilder();
            processLine.Append(currentLine);
            string[] punctuations = new string[] {",", ".", "(", ")", ";", "-", "!", "?" };
            int index = 0;

            while (index != -1)
            {
                index = -1;
                foreach (var item in punctuations)
                {
                    index = (processLine).ToString().IndexOf(item, index + 1);

                    if (index != -1)
                    {
                        processLine.Remove(index, 1);
                        index = 0;
                        break;
                    }
                }
            }


            ////TIME LIMIT s TOZI VANSHEN While CIKAL
            //while (index != -1)
            //{
            //    
            //    for (int i = 0; i < punctuations.Length; i++)
            //    {
            //
            //        index = (processLine).ToString().IndexOf(punctuations[i], index + 1);
            //        while (index != -1)
            //        {
            //            processLine.Remove(index, 1);
            //            index = 0;
            //            break;
            //        }
            //    }
            //    index = 0;
            //}

            return processLine.ToString();
        }
    }
}
