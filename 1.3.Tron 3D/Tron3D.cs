using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._3.Tron_3D
{
    class Tron3D
    {
        static int oldX, oldY, oldZ;
        static string redMoves, blueMoves;
        static int X, Y;
        static bool[,] used;
        static int currentRedX;
        static int currentRedY;
        static int currentBlueX;
        static int currentBlueY;
        static int redDirection;
        static int blueDirection; 
        
        //Directions:
        // 0 -> right
        // 1 -> down
        // 2 -> left
        // 3 -> up
        // 4 -> 0 (%)
        // rotate right -> direction++; //cw (clock wise)
        // rotate left -> direction--; //ccw (contra clock wise)

        static void Main()
        {
            ReadInput();

            X = oldX; 
            Y = oldY + oldZ + oldY + oldZ;

            used = new bool[X + 1, Y];

            currentRedX = oldX / 2;
            currentRedY = oldY / 2;

            currentBlueX = oldX / 2;
            currentBlueY = oldY + oldZ + oldY / 2;

            redDirection = 0; // right
            blueDirection = 2; // left

            var redIndex = 0;
            var blueIndex = 0;

            //MMLMMMMRMRMMLMMRMMRMLMMRMMRMLMMLMMMLMMM
            //      ^
            //LMMMMRMRMMMLMMRMMMMLMLMMMMRMLMMRMMMMRMM
            //        ^
            while (true)
            {
                #region Move Red
                int newRedX = currentRedX;
                int newRedY = currentRedY;

                while (redIndex < redMoves.Length && redMoves[redIndex] != 'M')
                {
                    if (redMoves[redIndex] == 'L')
                    {
                        redDirection = RotateLeft(redDirection);
                    }
                    else //if (redMover[redIndex] == 'R')
                    {
                        redDirection = RotateRight(redDirection);
                    }

                    redIndex++;
                }

                // move
                MovePlayer(ref newRedX, ref newRedY, redDirection);
                redIndex++;
                #endregion

                #region Move Blue
                int newBlueX = currentBlueX;
                int newBlueY = currentBlueY;

                while (blueIndex < blueMoves.Length && blueMoves[blueIndex] != 'M')
                {
                    if (blueMoves[blueIndex] == 'L')
                    {
                        blueDirection = RotateLeft(blueDirection);
                    }
                    else //if (redMover[redIndex] == 'R')
                    {
                        blueDirection = RotateRight(blueDirection);
                    }

                    blueIndex++;
                }

                // move
                MovePlayer(ref newBlueX, ref newBlueY, blueDirection);
                blueIndex++;
                #endregion 

                #region Fix Y coords (loops)
                if (newRedY >= Y)
                {
                    newRedY = 0;
                }

                if (newRedY < 0)
                {
                    newRedY = Y - 1;
                }


                if (newBlueY >= Y)
                {
                    newBlueY = 0;
                }

                if (newBlueY < 0)
                {
                    newBlueY = Y - 1;
                }
                #endregion

                bool redLoses = Loses(newRedX, newRedY);
                bool blueLoses = Loses(newBlueX, newBlueY);

                if (redLoses && blueLoses)
                {
                    Console.WriteLine("DRAW");
                }
                else if (redLoses)
                {
                    Console.WriteLine("BLUE");
                }
                else if (blueLoses)
                {
                    Console.WriteLine("RED");
                }

                currentRedX = newRedX;
                currentRedY = newRedY;
                currentBlueX = newBlueX;
                currentBlueY = newBlueY;

                if (redLoses || blueLoses)
                {
                    int startRedX = oldX / 2;
                    int startRedY = oldY / 2;

                    int diffRedX = Math.Abs(currentRedX - startRedX);
                    int diffRedY = Math.Abs(currentRedY - startRedY);

                    if (currentRedY > oldY + oldZ + oldY / 2)
                    {
                        diffRedY = oldY / 2 + Y - currentRedY; 
                    }

                    int diffRed = diffRedX + diffRedY;

                    if (redLoses && blueLoses)
                    {
                        Console.WriteLine(diffRed - 1);
                    }
                    else
                    {
                        Console.WriteLine(diffRed);
                    }

                    break;
                }

                used[newRedX, newRedY] = true;
                used[newBlueX, newBlueY] = true;
            }
        }

        static bool Loses(int playerX, int playerY)
        {
            if (playerX < 0)
            {
                return true;
            }

            if (playerX > X)
            {
                return true;
            }

            if (used[playerX, playerY])
            {
                return true;
            }

            return false;
        }

        static void MovePlayer(ref int currentX, ref int currentY, int direction)
        {
            // 0 -> right
            // 1 -> down
            // 2 -> left
            // 3 -> up
            if (direction == 0)
            {
                // 0 -> right
                currentY++;
            }
            else if (direction == 1)
            {
                // 1 -> down
                currentX++;
            }
            else if (direction == 2)
            {
                // 2 -> left
                currentY--;
            }
            else if (direction == 3)
            {
                // 3 -> up
                currentX--;
            }
        }

        static void ReadInput()
        {
            string xyzAsString = Console.ReadLine();
            var xyzStringParts = xyzAsString.Split(' ');
            oldX = int.Parse(xyzStringParts[0]);
            oldY = int.Parse(xyzStringParts[1]);
            oldZ = int.Parse(xyzStringParts[2]);

            redMoves = Console.ReadLine();
            blueMoves = Console.ReadLine();
        }

        static int RotateLeft(int direction)
        {
            // rotate left -> direction--; //ccw
            // -1 -> 3
            int newDirection = direction - 1;
            if (newDirection == -1)
            {
                newDirection = 3;
            }
            return newDirection;
        }

        static int RotateRight(int direction)
        {
            // 4 -> 0 (%)
            // rotate right -> direction++; //cw
            int newDirection = direction + 1;
            if (newDirection == 4)
            {
                newDirection = 0;
            }
            return newDirection;
        }
    }
}
