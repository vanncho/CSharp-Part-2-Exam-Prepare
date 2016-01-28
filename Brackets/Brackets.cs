using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brackets
{
    class Brackets
    {
        static int tabsNumber = 0;
        static string tabs = "";
        static StringBuilder sb = new StringBuilder();
        static bool shouldPrintNewLine = false;
        static bool isFitstSymbol = true;
        static void Main()
        {
            int numberOfLines = int.Parse(Console.ReadLine());
            tabs = Console.ReadLine();

            for (int i = 0; i < numberOfLines; i++)
            {
                string codeLine = Console.ReadLine().Trim();

                HandleTheCodeLine(codeLine);
            }
            Console.WriteLine();
            Console.WriteLine(sb);
        }

        private static void HandleTheCodeLine(string codeLine)
        {
            //  {a{   {
            //  }     >>a
            //  }     >>{
            //        >>}
            //        }
            for (int i = 0; i < codeLine.Length; i++)
            {
                char currentCharacter = codeLine[i];

                if (shouldPrintNewLine)
                {
                    sb.AppendLine();
                    shouldPrintNewLine = false;
                    isFitstSymbol = true;
                }

                if (codeLine[i] == '{')
                {
                    if (!isFitstSymbol)
                    {
                        sb.AppendLine();
                    }
                    AppendTabs();
                    sb.Append(currentCharacter);
                    tabsNumber++;
                    shouldPrintNewLine = true;
                    
                }
                else if (codeLine[i] == '}')
                {
                    if (!isFitstSymbol)
                    {
                        sb.AppendLine();
                    }
                    tabsNumber--;
                    AppendTabs();
                    sb.Append(currentCharacter);
                    shouldPrintNewLine = true;
                }
                else
                {
                    if (char.IsWhiteSpace(currentCharacter) && char.IsWhiteSpace(codeLine[i + 1]))
                    {
                        continue;
                    }
                    if (char.IsWhiteSpace(currentCharacter) && !char.IsWhiteSpace(codeLine[i - 1]))
                    {
                        if (isFitstSymbol)
                        {
                            continue;
                        }
                        
                    }
                    if (isFitstSymbol)
                    {
                        AppendTabs();
                    }
                    if (shouldPrintNewLine)
                    {
                        sb.AppendLine();
                    }
                    sb.Append(currentCharacter);
                    isFitstSymbol = false;
                    
                }
                //Console.WriteLine(sb);
            }

            shouldPrintNewLine = true;
            isFitstSymbol = true;  
        }

        private static void AppendTabs()
        {
            for (int i = 0; i < tabsNumber; i++)
            {
                sb.Append(tabs);
            }
        }
    }
}


//РЕШЕНИЕ ОТ ВИДЕО ЛЕКЦИЯТА
/*
 * using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brackets
{
    class Brackets
    {

        //DA SE PROBVAM DA IA RESHA SAM!



        static StringBuilder sb = new StringBuilder();
        static string tabs;
        static int tabsCount = 0;
        static bool shouldPrintNewLine = false;
        static bool isFirstSymbol = true;
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            tabs = Console.ReadLine();

            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine().Trim();

                HandleLine(line);
            }

            Console.WriteLine(sb);
        }

        private static void HandleLine(string line)
        {
            for (int i = 0; i < line.Length; i++)
            {
                char currentCharacter = line[i];
                if (shouldPrintNewLine && char.IsWhiteSpace(currentCharacter))
                {
                    continue;
                }

                if (shouldPrintNewLine)
                {
                    sb.AppendLine();
                    shouldPrintNewLine = false;
                    isFirstSymbol = true;
                }
                

                if (currentCharacter == '{')
                {
                    if (!shouldPrintNewLine)
                    {
                        if (!isFirstSymbol)
                        {
                            if (sb.Length > 0 && char.IsWhiteSpace(sb[sb.Length - 1]))
                            {
                                sb.Remove(sb.Length - 1, 1);
                            }
                            sb.AppendLine();
                        }
                    }

                    AppendTabs(); 
                    sb.Append(currentCharacter);
                    tabsCount++;
                    shouldPrintNewLine = true;
                }
                else if (currentCharacter == '}')
                {
                    tabsCount--;
                    if (!shouldPrintNewLine)
                    {
                        if (!isFirstSymbol)
                        {
                            if (sb.Length > 0 && char.IsWhiteSpace(sb[sb.Length - 1]))
                            {
                                sb.Remove(sb.Length - 1, 1);
                            }
                            sb.AppendLine();
                        }
                    }
                    AppendTabs();
                    sb.Append(currentCharacter);
                    shouldPrintNewLine = true;
                }
                else
                {
                    if (isFirstSymbol)
                    {
                        AppendTabs();
                    }

                    if (!(isFirstSymbol && char.IsWhiteSpace(currentCharacter)))
                    {
                        if (!(i < line.Length - 1 
                            && char.IsWhiteSpace(line[i]) 
                            && char.IsWhiteSpace(line[i + 1])))
                        {
                            sb.Append(currentCharacter);
                        }
                    }
                    isFirstSymbol = false;
                }
            }
            shouldPrintNewLine = true;
            isFirstSymbol = true;
        }

        private static void AppendTabs()
        {
            for (int i = 0; i < tabsCount; i++)
			{
			    sb.Append(tabs);
			}
        }
    }
}

 */
