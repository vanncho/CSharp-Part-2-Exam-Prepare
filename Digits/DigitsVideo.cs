namespace Digits
{
    using System;
using System.Collections.Generic;

    class DigitsVideo
    {
        static int[,] digits;
        
        static List<bool[,]> InitializeListOfPatterns()
        {
            var list = new List<bool[,]>();

            list.Add(new bool[,]
                {
                    //faking zero
                });

            // one
            list.Add(new bool[,]
            {
                {false, false, true},
                {false, true, true},
                {true, false, true},
                {false, false, true},
                {false, false, true}
            });

            // two
            list.Add(new bool[,]
            {
                {false, true, false},
                {true, false, true},
                {false, false, true},
                {false, true, false},
                {true, true, true}
            });

            // three
            list.Add(new bool[,]
            {
                {true, true, true},
                {false, false, true},
                {false, true, true},
                {false, false, true},
                {true, true, true}
            });
            
            //four
            list.Add(new bool[,]
            {
                {true, false, true},
                {true, false, true},
                {true, true, true},
                {false, false, true},
                {false, false, true}
            });

            //five
            list.Add(new bool[,]
            {
                {true, true, true},
                {true, false, false},
                {true, true, true},
                {false, false, true},
                {true, true, true}
            });

            //six
            list.Add(new bool[,]
            {
                {true, true, true},
                {true, false, false},
                {true, true, true},
                {true, false, true},
                {true, true, true}
            });

            // seven
            list.Add(new bool[,]
            {
                {true, true, true},
                {false, false, true},
                {false, true, false},
                {false, true, false},
                {false, true, false}
            });

            //eight
            list.Add(new bool[,]
            {
                {true, true, true},
                {true, false, true},
                {false, true, false},
                {true, false, true},
                {true, true, true}
            });

            // nine
            list.Add(new bool[,]
            {
                {true, true, true},
                {true, false, true},
                {false, true, true},
                {false, false, true},
                {true, true, true}
            });

            return list;
        }

        static bool CheckPattern(bool[,] pattern, int digit, int row, int col)
        {
            for (int i = 0; i < pattern.GetLength(0); i++)
            {
                for (int j = 0; j < pattern.GetLength(1); j++)
                {
                    if (pattern[i, j])
                    {
                        if (digits[row + i, col + j] != digit)
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var patterns = InitializeListOfPatterns();

            digits = new int[n, n];

            for (int row = 0; row < n; row++)
            {
                string[] currentLine = Console.ReadLine().Split(' ');

                for (int col = 0; col < currentLine.Length; col++)
                {
                    digits[row, col] = int.Parse(currentLine[col]);
                }
            }

            int sum = 0;

            for (int row = 0; row <= n - 5; row++)
            {
                for (int col = 0; col <= n - 3; col++)
                {
                    if (digits[row + 2, col] == 1) 
                    {
                        if (CheckPattern(patterns[1], 1, row, col))
                        {
                            sum += 1;
                            continue;
                        } 
                    }

                    if (digits[row + 1, col] == 2)
                    {
                        if (CheckPattern(patterns[2], 2, row, col))
                        {
                            sum += 2;
                            continue;
                        }   
                    }

                    int currentDigit = digits[row, col];

                    if (CheckPattern(patterns[currentDigit], currentDigit, row, col))
                    {
                        sum += currentDigit;
                    }
                }
            }
            Console.WriteLine(sum);
        }
    }
}
