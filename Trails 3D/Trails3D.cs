namespace Trails_3D
{
    using System;
    using System.Text;

    class Trails3D
    {
        static bool[,] field;
        static string ConvertCommands(string path)
        {
            StringBuilder result = new StringBuilder();

            //if slow - refactor
            path = path.Replace("M", " M ");
            path = path.Replace("L", " L ");
            path = path.Replace("R", " R ");

            string[] separatedPaths = path.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string lastNumber = null;

            for (int i = 0; i < separatedPaths.Length; i++)
            {
                if (separatedPaths[i] == "L" || separatedPaths[i] == "R")
                {
                    result.Append(separatedPaths[i]);
                }
                else if (separatedPaths[i] == "M")
                {
                    if (lastNumber == null)
                    {
                        result.Append("M");
                    }
                    else
                    {
                        int number = int.Parse(lastNumber);
                        result.Append(new string('M', number));
                        lastNumber = null;
                    }
                }
                else
                {
                    lastNumber = separatedPaths[i];
                }
            }
            result.Replace("LM", "L");
            result.Replace("RM", "R");

            return result.ToString();
        }

        static void Main()
        {
            string[] xyz = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int x = int.Parse(xyz[0]);
            int y = int.Parse(xyz[1]);
            int z = int.Parse(xyz[2]);

            //check if player can turn multiple times on one game cycle
            string redCommands = ConvertCommands(Console.ReadLine());
            string blueCommands = ConvertCommands(Console.ReadLine());

            field = new bool[y + 1, 2 * (x + z)];

            int redRow = y / 2;
            int redCol = z + x / 2;
            string redDirection = "right";

            int blueRow = y / 2;
            int blueCol = 2 * z + x + x / 2;
            string blueDirection = "left";

            bool redDies = false;
            bool blueDies = false;

            field[redRow, redCol] = true;
            field[blueRow, blueCol] = true;

            for (int i = 0; i < redCommands.Length; i++)
            {
                // red
                char currentRedCommand = redCommands[i];
                if (currentRedCommand == 'L' || currentRedCommand == 'R')
                {
                    redDirection = ChangeDirection(redDirection, currentRedCommand);
                }
                Move(ref redRow, ref redCol, redDirection);

                //check forbidden walls
                if (redRow < 0)
                {
                    redRow = 0;
                    redDies = true;
                }
                if (redRow == field.GetLength(0))
                {
                    redRow = field.GetLength(0) - 1;
                    redDies = true;
                }

                //check whether we should retun the player
                if (field[redRow, redCol])
                {
                    redDies = true;
                }

                //blue
                char currentBlueCommand = blueCommands[i];
                if (currentBlueCommand == 'L' || currentBlueCommand == 'R')
                {
                    blueDirection = ChangeDirection(blueDirection, currentBlueCommand);
                }
                Move(ref blueRow, ref blueCol, blueDirection);

                if (blueRow < 0)
                {
                    blueRow = 0;
                    blueDies = true;
                }
                if (blueRow == field.GetLength(0))
                {
                    blueRow = field.GetLength(0) - 1;
                    blueDies = true;
                }

                if (field[blueRow, blueCol])
                {
                    blueDies = true;
                }


                // check whether they crash in each other
                if (redRow == blueRow && redCol == blueCol)
                {
                    redDies = true;
                    blueDies = true;
                }

                if (redDies && !blueDies)
                {
                    Console.WriteLine("BLUE");
                    break;
                }

                if (!redDies && blueDies)
                {
                    Console.WriteLine("RED");
                    break;
                }

                if (redDies && blueDies)
                {
                    Console.WriteLine("DRAW");
                    break;
                }
                
                field[redRow, redCol] = true;
                field[blueRow, blueCol] = true;
            }

            int distanceRow = Math.Abs(redRow - (y / 2));
            int distanceCol = Math.Abs(redCol - (z + x / 2));

            if (distanceCol > field.GetLength(1) / 2)
            {
                distanceCol = field.GetLength(1) - distanceCol;
            }

            Console.WriteLine(distanceRow + distanceCol);
        }

        private static void Move(ref int row, ref int col, string direction)
        {
            switch (direction)
            {
                case "up": row--; break;
                case "down": row++; break;
                case "left": col--; break;
                case "right": col++; break;
                default:
                    throw new ArgumentException("direction", "Direction is not valid"); 
            }

            if (col < 0)
            {
                col = field.GetLength(1) - 1;
            }
            if (col == field.GetLength(1))
            {
                col = 0;
            }
        }

        static string ChangeDirection(string direction, char command)
        {
            switch (direction)
            {
                case "up":
                    if (command == 'L')
                    {
                        return "left";
                    }
                    if (command == 'R')
                    {
                        return "right";
                    }
                    break;
                case "down": 
                    if (command == 'L')
                    {
                        return "right";
                    }
                    if (command == 'R')
                    {
                        return "left";
                    }break;
                case "left":
                    if (command == 'L')
                    {
                        return "down";
                    }
                    if (command == 'R')
                    {
                        return "up";
                    }
                    break;
                case "right":
                    if (command == 'L')
                    {
                        return "up";
                    }
                    if (command == 'R')
                    {
                        return "down";
                    }
                    break;
                default:
                    throw new ArgumentException("direction", "Direction is not valid"); 
            }

            throw new ArgumentException("direction", "Direction is not valid");
        }
    }
}
