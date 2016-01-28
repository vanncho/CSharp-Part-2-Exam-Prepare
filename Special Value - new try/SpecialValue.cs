using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Special_Value___new_try
{
    class SpecialValue
    {
        static void Main()
        {
            int numberOfLines = int.Parse(Console.ReadLine());

            int[][] field = new int[numberOfLines][];

            ReadInputLines(field);

            bool[][] visited = new bool[numberOfLines][];

            for (int i = 0; i < numberOfLines; i++)
            {
                visited[i] = new bool[field[i].Length];
            }


            long max = long.MinValue;

            for (int i = 0; i < field[0].Length; i++)
			{
                long result = FindCurrentSpecialValue(field, i, visited);

                if (max < result)
                {
                    max = result;
                }
			}

            Console.WriteLine(max);
        }

        private static int[][] ReadInputLines(int[][] field)
        {
            for (int i = 0; i < field.GetLength(0); i++)
            {
                string[] currentLine = Console.ReadLine().Split(new char[] {' ', ','},StringSplitOptions.RemoveEmptyEntries);

                field[i] = new int[currentLine.Length];

                for (int l = 0; l < currentLine.Length; l++)
                {
                    field[i][l] = int.Parse(currentLine[l]);
                }
            }

            return field;
        }

        private static long FindCurrentSpecialValue (int[][] field, int column, bool[][] visited)
        {
            int result = 0;
            int currentRow = 0;

            for (int i = 0; i < field.GetLength(0); i++)
            {
                visited[i] = new bool[field[i].Length];
            }

            while (true)
            {
                result++;

                if (visited[currentRow][column])
                {
                    return long.MinValue;   
                }
                if (field[currentRow][column] < 0)
                {
                    result += Math.Abs(field[currentRow][column]);
                    return result;
                }

                int nextColumn = field[currentRow][column];
                visited[currentRow][column] = true;
                column = nextColumn;

                if (currentRow == field.GetLength(0))
                {
                    currentRow = 0;
                }

                currentRow++;
            }
        }
    }
}
