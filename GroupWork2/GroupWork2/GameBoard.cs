using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupWork2
{
    public class GameBoard
    {
        private int size;
        public int Size
        {
            get
            {
                return this.size;
            }
            set
            {
                this.size = value;
            }
        }

        public int[,] gameBoard { get; set; }
        public GameBoard(int size)
        {
            this.size = size;
            gameBoard = new int[size, size];
        }
        public static GameBoard CreateBoard()

        {
            Console.Write("Hur stor spelplan vill du ha? (x gånger x rutor) ");
            int size = Program.CheckThatInputIsInt();
            GameBoard board = new GameBoard(size);

            return board;
        }

        public void PrintBoard()
        {
            Console.WriteLine("");
            Console.WriteLine();
            for (int i = 0; i < gameBoard.GetLength(0); i++)
            {
                Console.WriteLine("-------------");
                Console.Write("|");

                for (int j = 0; j < gameBoard.GetLength(1); j++)
                {
                    Console.Write(gameBoard[i, j] + "|");
                }
                Console.WriteLine("");
            }
            Console.WriteLine("-------------");
            Console.WriteLine();
        }
    }
}
