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
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[,] floor = {                                 
                                    {"RED", "BLUE", "RED"},
                                    {"BLUE", "GREEN", "BLUE"},
                                    {"RED", "BLUE", "RED"}
                                  };

                int[][] turns = {
                                    new int[] {0, 1},  //right
                                    new int[] {-1, 0}, //up
                                    new int[] {0, -1}, //left
                                    new int[] {1, 0}   //down
                                };

                string dance = Console.ReadLine();

                int[] pos = { 1, 1 };
                int currentTurn = 0;
                int[] dir = turns[currentTurn];

                foreach (var step in dance)
                {
                    switch (step)
                    {
                        case 'W':
                            pos = Walk(pos, dir);

                            for (int j = 0; j < pos.Length; j++)
                            {
                                if (pos[j] >= floor.GetLength(0))
                                {
                                    pos[j] = 0;
                                }
                                else if (pos[j] < 0)
                                {
                                    pos[j] = floor.GetLength(0) - 1;
                                }
                            }

                            break;
                        case 'L':
                            currentTurn = TurnLeft(turns, currentTurn);
                            dir = turns[currentTurn];
                            break;
                        case 'R':
                            currentTurn = TurnRight(turns, currentTurn);
                            dir = turns[currentTurn];
                            break;
                    }
                }

                int currRow = pos[0];
                int currCol = pos[1];
                Console.WriteLine(floor[currRow, currCol]);
            }
        }

        private static int[] Walk(int[] pos, int[] dir)
        {
            for (int i = 0; i < pos.GetLength(0); i++)
            {
                pos[i] += dir[i];
            }

            return pos;
        }

        private static int TurnLeft(int[][] turns, int currentTurn)
        {
            currentTurn += 1;

            if (currentTurn >= turns.GetLength(0))
            {
                currentTurn = 0;
            }
            return currentTurn;
        }

        private static int TurnRight(int[][] turns, int currentTurn)
        {
            currentTurn -= 1;

            if (currentTurn < 0)
            {
                currentTurn = turns.GetLength(0) - 1;
            }
            return currentTurn;
        }
    }
}
