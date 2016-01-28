namespace Konspiration
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    class Konspiration
    {
        static List<string> calling = new List<string>();
        static List<int> numberOfCallingsPerMethod = new List<int>();
        static List<string> methods = new List<string>();
        static int callingsCount = 0;

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            bool foundMethod = false;
            int opendBrackets = 0;

            for (int i = 0; i < n; i++)
            {
                string currentLine = Console.ReadLine().Trim();
                string[] splitForMethods = currentLine.Split(new char[] { ' ', '(', ')', '.' }, StringSplitOptions.RemoveEmptyEntries);
                string[] splitForInvokes = currentLine.Split(new char[] { ' ', ')', '.', ',', ';', '=', '+', '-', '%', '/', '*', '[', ']' }, StringSplitOptions.RemoveEmptyEntries);
                string method = "";

                if (currentLine != "")
                {
                    if (foundMethod)
                    {
                        if (currentLine.IndexOf('{') >= 0)
                        {
                            opendBrackets++;
                        }
                    }

                    if (splitForMethods[0] == "static")
                    {
                        methods.Add(splitForMethods[2]);
                        foundMethod = true;
                    }

                    if (methods.Count > 0 && foundMethod)
                    {
                        if (currentLine.Length > 1)
                        {
                            if (splitForMethods[0] != "static")
                            {
                                if (currentLine.IndexOf('(') > 0)
                                {
                                    string tempMethod = AddCallingForMethod(methods, splitForInvokes);
                                    if (tempMethod != "" && tempMethod != method)
                                    {
                                        calling.Add(tempMethod);
                                        callingsCount++;
                                    }
                                }
                            }
                        }
                    }

                    if (currentLine.IndexOf('}') >= 0 && foundMethod)
                    {
                        opendBrackets--;
                        if (opendBrackets == 0)
                        {
                            foundMethod = false;
                            numberOfCallingsPerMethod.Add(callingsCount);
                            callingsCount = 0;
                        }
                    }
                }
            }
            int count = 0;

            // Print Result
            for (int i = 0; i < methods.Count; i++)
            {
                if (numberOfCallingsPerMethod[i] == 0)
                {
                    Console.Write("{0} -> None", methods[i]);
                }
                else
                {
                    Console.Write("{0} -> {1} -> ", methods[i], numberOfCallingsPerMethod[i]);
                    for (int j = 0; j < numberOfCallingsPerMethod[i]; j++)
                    {
                        if (j < numberOfCallingsPerMethod[i] - 1)
                        {
                            Console.Write("{0}, ", calling[count]);
                        }
                        else
                        {
                            Console.Write("{0}", calling[count]);
                        }
                        count++;
                    }
                }
                Console.WriteLine();
            }
        }

        static void ProcessTheCurrentLine(string[] splittedCurrentLine)
        {
            int bracketIndex = 0;

            for (int i = 0; i < splittedCurrentLine.Length; i++)
            {
                string[] split = splittedCurrentLine[i].ToString().Split('.');
                for (int j = 0; j < split.Length; j++)
                {
                    if (split[j].IndexOf('(') > 0)
                    {
                        bracketIndex = split[j].IndexOf('(');
                        calling.Add(split[j].Substring(0, bracketIndex));
                        callingsCount++;
                    }
                }
            }
        }

        static string AddCallingForMethod(List<string> methods, string[] splitForInvokes)
        {
            string methodName = "";
            int bracketIndex = 0;
            StringBuilder processTheMethods = new StringBuilder();

            if (splitForInvokes.Length > 1)
            {
                for (int i = 1; i < splitForInvokes.Length; i++)
                {
                    if (splitForInvokes[i].IndexOf('(') > 0 && splitForInvokes.Length > 1)
                    {
                        if (splitForInvokes[i - 1] == "new")
                        {
                            bracketIndex = splitForInvokes[i].IndexOf('(');

                            string tempMethodName = splitForInvokes[i].Substring(0, bracketIndex);
                            if (tempMethodName.Length < 8)
                            {
                                continue;
                            }
                            if (tempMethodName.Substring(0, 8) != "Argument")
                            {
                                continue;
                            }
                            else
                            {
                                calling.Add(tempMethodName);
                                callingsCount++;
                            }

                        }
                        else
                        {
                            bracketIndex = AppendCallingMethodNames(splitForInvokes, bracketIndex, processTheMethods, i);
                        }
                    }

                    if (splitForInvokes[i].IndexOf('(') == 0 && splitForInvokes.Length > 1)
                    {
                        bracketIndex = AppendCallingMethodNames(splitForInvokes, bracketIndex, processTheMethods, i);
                    }
                }
            }
            else
            {
                bracketIndex = AppendCallingMethodNames(splitForInvokes, bracketIndex, processTheMethods, 0);
            }

            return methodName;
        }

        private static int AppendCallingMethodNames(string[] splitForInvokes, int bracketIndex, StringBuilder processTheMethods, int i)
        {
            string tempMethodName = "";
            processTheMethods.Append(splitForInvokes[i]);

            if (splitForInvokes[i].Length > 2)
            {
                while (processTheMethods.ToString().IndexOf('(') >= 0)
                {
                    bracketIndex = processTheMethods.ToString().IndexOf('(');

                    tempMethodName = processTheMethods.ToString().Substring(0, bracketIndex);
                    if (tempMethodName != "" && tempMethodName.Length > 1)
                    {
                        calling.Add(tempMethodName);
                        callingsCount++;
                    }

                    processTheMethods.Remove(0, bracketIndex + 1);

                }
                processTheMethods.Clear();
            }
            return bracketIndex;
        }
    }
}
