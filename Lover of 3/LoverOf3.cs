namespace Lover_of_3
{
    using System;

    class LoverOf3
    {
        static void Main()
        {
            string[] fieldDimensions = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int fieldRow = int.Parse(fieldDimensions[0]);
            int fieldCol = int.Parse(fieldDimensions[1]);
            int[,] field = new int[fieldRow, fieldCol];

            int numberOfDirections = int.Parse(Console.ReadLine());

            string[] directions = new string[numberOfDirections];
            int[] movesByDirection = new int[numberOfDirections];

            for (int i = 0; i < numberOfDirections; i++)
            {
                string[] line = Console.ReadLine().Split(' ');
                directions[i] = line[0];
                movesByDirection[i] = int.Parse(line[1]);
            }

            field = FillTheField(field);
            bool[,] visited = new bool[fieldRow, fieldCol];

            int row = field.GetLength(0) - 1;
            int col = 0;
            int sum = field[row, col];
            visited[row, col] = true;
            for (int i = 0; i < movesByDirection.Length; i++)
            {
                for (int j = 0; j < movesByDirection[i] - 1; j++)
                {
                    int previousRow = row;
                    int previousCol = col;

                    switch (directions[i])
                    {
                        case "UR":
                            row--;
                            col++;
                            break;
                        case "RU":
                            row--;
                            col++;
                            break;
                        case "UL":
                            row--;
                            col--;
                            break;
                        case "LU":
                            row--;
                            col--;
                            break;
                        case "DL":
                            row++;
                            col--;
                            break;
                        case "LD":
                            row++;
                            col--;
                            break;
                        case "RD":
                            row++;
                            col++;
                            break;
                        case "DR":
                            row++;
                            col++;
                            break;
                    }

                    if (row < 0)
                    {
                        row = previousRow;
                        col = previousCol;
                    }
                    if (row >= field.GetLength(0))
                    {
                        row = previousRow;
                        col = previousCol;
                    }
                    if (col < 0)
                    {
                        row = previousRow;
                        col = previousCol;
                    }
                    if (col >= field.GetLength(1))
                    {
                        row = previousRow;
                        col = previousCol;
                    }

                    if (!visited[row, col])
                    {
                        sum += field[row, col];
                    }

                    visited[row, col] = true;
                }
            }

            Console.WriteLine(sum);
        }

        static int[,] FillTheField(int[,] field)
        {
            int increase = 0;
            int changeCol = 0;

            for (int col = 0; col < field.GetLength(1); col++)
            {
                for (int row = field.GetLength(0) - 1; row >= 0; row--)
                {
                    field[row, col] = increase;
                    increase += 3;
                }
                changeCol += 3;
                increase = changeCol;
            }

            return field;
        }
    }
}
