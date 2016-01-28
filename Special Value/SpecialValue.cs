using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Special_Value
{
    class SpecialValue
    {
        static int[][] ReadData(int[][] field)
        {
            for (int i = 0; i < field.GetLength(0); i++)
            {
                string[] currentLine = Console.ReadLine().Split(new char[] { ' ', ',' },StringSplitOptions.RemoveEmptyEntries);

                field[i] = new int[currentLine.Length];

                for (int l = 0; l < currentLine.Length; l++)
                {
                    field[i][l] = int.Parse(currentLine[l]);
                }
            }

            return field;
        }

        static long FindCurrentSpecialValue(int[][] field, int column, bool[][] used)
        {
            long result = 0;
            int currentRow = 0;

            for (int i = 0; i < field.GetLength(0); i++)
            {
                used[i] = new bool[field[i].Length];
            }

            while (true)
            {
                result++;

                if (used[currentRow][column])
                {
                    return long.MinValue;
                }

                if (field[currentRow][column] < 0)
                {
                    result -= field[currentRow][column];
                    return result;
                }

                int nextColumn = field[currentRow][column];
                used[currentRow][column] = true;
                column = nextColumn;

                currentRow++;

                if (currentRow == field.GetLength(0))
                {
                    currentRow = 0;
                }
            }
        }
        static void Main()
        {
            int N = int.Parse(Console.ReadLine());

            int[][] field = new int[N][];

            ReadData(field);

            bool[][] used = new bool[N][];

            for (int i = 0; i < N; i++)
            {
                used[i] = new bool[field[i].Length];
            }

            long max = long.MinValue;

            for (int i = 0; i < field[0].Length; i++)
            {
                long specialValue = FindCurrentSpecialValue(field, i, used);

                if (max < specialValue)
                {
                    max = specialValue;
                }
            }

            Console.WriteLine(max);
        }
    }
}
