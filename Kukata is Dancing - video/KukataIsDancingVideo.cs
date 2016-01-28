using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kukata_is_Dancing___video
{
    class KukataIsDancingVideo
    {
        static void Main()
        {
            //read input
            int n = int.Parse(Console.ReadLine());

            string[,] floor = {                                 
                                    {"RED", "BLUE", "RED"},
                                    {"BLUE", "GREEN", "BLUE"},
                                    {"RED", "BLUE", "RED"}
                              };
            //[][] масив от масиви
            int[][] dirs = { 
                                 new int[] {0, 1},  // right
                                 new int[] {-1, 0}, // up
                                 new int[] {0, -1}, // left
                                 new int[] {1, 0}   // down
                                 };

            for (int i = 0; i < n; i++)
            {
                string dance = Console.ReadLine();
                int[] pos = { 1, 1 };
                int dirInd = 0;
                int[] dir = dirs[dirInd];

                foreach (char step in dance)
                {
                    switch (step)
                    {
                        case 'W':
                            pos = Walk(pos, dir);

                            for (int j = 0; j < pos.Length; j++)
                            {
                                //check if out of the dance floor
                                if (pos[j] >= floor.GetLength(j)) // row
                                {
                                    pos[j] = 0;
                                }
                                else if (pos[j] < 0)
                                {
                                    pos[j] = floor.GetLength(j) - 1;
                                }
                            }

                            ////Да не се повтаря кода е направено горе с цикъл
                            //if (pos[0] >= floor.GetLength(0)) // row
                            //{
                            //    pos[0] = 0;
                            //}
                            //else if (pos[0] < 0)
                            //{
                            //    pos[0] = floor.GetLength(0) - 1;
                            //}
                            //
                            //if (pos[1] >= floor.GetLength(1)) // row
                            //{
                            //    pos[1] = 0;
                            //}
                            //else if (pos[1] < 0)
                            //{
                            //    pos[1] = floor.GetLength(1) - 1;
                            //}

                            break;
                        case 'R':
                            dirInd = TurnRight(dirs, dirInd);
                            dir = dirs[dirInd]; //change current direction
                            break;
                        case 'L':
                            dirInd = TurnLeft(dirs, dirInd);
                            dir = dirs[dirInd]; //change current direction
                            break;
                    }
                }




                //print result for current dance
                int currentRow = pos[0];
                int currentCol = pos[1];
                string result = floor[currentRow, currentCol];
                Console.WriteLine(result);
            }
        }

        private static int[] Walk(int[] pos, int[] dir)
        {
            for (int i = 0; i < pos.GetLength(0); i++)
            {
                pos[i] += dir[i];
            }

            ////това е еквивалент на цикъла отгоре
            //pos[0] += dir[0];
            //pos[1] += dir[1];

            return pos;
        }

        private static int TurnLeft(int[][] dirs, int dirInd)
        {
            dirInd += 1;
            if (dirInd >= dirs.GetLength(0))
            {
                dirInd = 0;
            }
            return dirInd;
        }

        private static int TurnRight(int[][] dirs, int dirInd)
        {
            dirInd -= 1;
            if (dirInd < 0)
            {
                dirInd = dirs.GetLength(0) - 1;
            }
            return dirInd;
        }
    }
}