using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace GameProject
{
    class Program
    {
        static char[] spaces = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int player = 1;
        static int choice;
        static int flags;

        /// <summary>
        /// Draws the game board
        /// </summary>
        static void DrawBoard()
        {
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", spaces[0], spaces[1], spaces[2]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", spaces[3], spaces[4], spaces[5]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", spaces[6], spaces[7], spaces[8]);
            Console.WriteLine("     |     |     ");
        }

        /// <summary>
        /// Check if the game was won, tied, or should continue
        /// </summary>
        static int CheckWin()
        {
            if (spaces[0] == spaces[1] &&
               spaces[1] == spaces[2] || //row 1
               spaces[3] == spaces[4] &&
               spaces[4] == spaces[5] || //row 2
               spaces[6] == spaces[7] &&
               spaces[7] == spaces[8] || //row 3
               spaces[0] == spaces[3] &&
               spaces[3] == spaces[6] || // column 1
               spaces[1] == spaces[4] &&
               spaces[4] == spaces[7] || // column 2
               spaces[2] == spaces[5] &&
               spaces[5] == spaces[8] || // column 3
               spaces[0] == spaces[4] &&
               spaces[4] == spaces[8] || // diagonal 1
               spaces[2] == spaces[4] &&
               spaces[4] == spaces[6]) // diagonal 2
            {
                return 1;
            }
            else if (spaces[0] != '1' &&
                     spaces[0] != '2' &&
                     spaces[0] != '3' &&
                     spaces[0] != '4' &&
                     spaces[0] != '5' &&
                     spaces[0] != '6' &&
                     spaces[0] != '7' &&
                     spaces[0] != '8' &&
                     spaces[0] != '9')
            {
                return -1;
            }
            else
            {
                return 0; 
            }
        }   

        /// <summary>
        /// Draws and X ON THE GAME BOARD
        /// </summary>
        /// <param name="pos"></param>
        /// 
        static void DrawX(int pos)
        {
            spaces[pos] = 'X';
        }

        /// <summary>
        /// Draws and O ON THE GAME BOARD
        /// </summary>
        /// <param name="pos"></param>
        /// 
        static void DrawO(int pos)
        {
            spaces[pos] = 'O';
        }

        /// <summary>
        /// The main game loop
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Player 1 : X and Player 2 : O" + " \n");
                if (player % 2 == 0)
                {
                    Console.WriteLine("Player 2's turn");
                }
                else
                {
                    Console.WriteLine("Player 1's turn");
                }

                Console.WriteLine("\n");
                DrawBoard();
                choice = int.Parse(Console.ReadLine()) - 1;

                if (spaces[choice] != 'X' &&
                    spaces[choice] != 'O')
                {
                    if (player % 2 == 0)
                    {
                        DrawO(choice);
                    }
                    else
                    {
                        DrawX(choice);
                    }
                    player++;

                }
                else
                {
                    Console.WriteLine("Sorry the row {0} is already marked with {1} \n", choice, spaces[choice]);
                    Console.WriteLine("Please wait 2 seconds board is loading again...");
                    Thread.Sleep(2000);

                }

                flags = CheckWin();
            } while (flags != 1 && flags != -1);

            Console.Clear();
            DrawBoard();

            if(flags == 1)
            {
                Console.WriteLine("Player {0} has Won", (player % 2) + 1);
            }
            else
            {
                Console.WriteLine("Tie Game");
            }

            Console.ReadLine();
            
        }
    }
}