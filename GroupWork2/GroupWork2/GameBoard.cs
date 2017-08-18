using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupWork2
{
    public class GameBoard // Metoderna som skapar spelplanen
    {
        private int size; // Sätta parametrarna för storleken på spelplanen
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

        public static int[,] gameBoard { get; set; } // Tvådimensionell vektor = spelplanen
        public GameBoard(int size)
        {
            this.size = size;
            gameBoard = new int[size, size];
        }
        public static GameBoard CreateBoard()

        {
            Console.Write("Hur stor spelplan vill du ha? (x gånger x rutor) ");
            int size = Program.CheckThatInputIsInt();                           // Kolla korrekt användarinput
            GameBoard board = new GameBoard(size);

            return board;
        }

        public static void PrintBoard() // Skriver ut spelplanen med streckmarkeringar runtom planen och de enskilda cellerna
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

        public bool CheckCoordinate(int row, int col) // Talar om ifall positionen/cellen man skjutit på innehåller ett skepp eller är tom = träff eller miss
        {
            int cell = gameBoard[size, size];

            if (cell == 1)
            {
                return true; // = Träff
            }
            else
            {
                return false; // = Miss
            }


        }
    }
}
