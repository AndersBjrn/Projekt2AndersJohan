using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupWork2
{
    class Program
    {
        static void Main(string[] args)
        {
            GameBoard board = GameBoard.CreateBoard();
            ChooseShips(board);
            PlaceShips();
        }

        private static List<Ship> ChooseShips(GameBoard board)//Lets the user decide to add ships or use default number of ships
        {
            Console.WriteLine("Do you want default number of ships?(y/n):");
            string answer = YesOrNo();
            if (answer == "y")
            {
                return DecideDefaultNumberOfShips(board);
            }
            else
            {
                List<Ship> ships = new List<Ship>();
                Console.Write("How many Battleships(size 4)?: ");
                int battleships = CheckThatInputIsInt();
                for (int i = 0; i < battleships; i++)
                {
                    Ship ship = new Ship(4);
                    ships.Add(ship);
                }
                Console.Write("How many Cruisers(size 3)?: ");
                int cruisers = CheckThatInputIsInt();
                for (int i = 0; i < cruisers; i++)
                {
                    Ship ship = new Ship(3);
                    ships.Add(ship);
                }
                Console.Write("How many Destroyers(size 2)?: ");
                int destroyers = CheckThatInputIsInt();
                for (int i = 0; i < destroyers; i++)
                {
                    Ship ship = new Ship(2);
                    ships.Add(ship);
                }
                Console.Write("How many Submarines(size 1)?: ");
                int submarines = CheckThatInputIsInt();
                for (int i = 0; i < submarines; i++)
                {
                    Ship ship = new Ship(1);
                    ships.Add(ship);
                }
                return ships;
            }
        }

        private static List<Ship> DecideDefaultNumberOfShips(GameBoard board)
        {
            List<Ship> ships = new List<Ship>();
            if (board.size*board.size > 64)
            {
                ships.Add(new Ship(4));
                ships.Add(new Ship(3));
                ships.Add(new Ship(3));
                ships.Add(new Ship(2));
                ships.Add(new Ship(2));
                ships.Add(new Ship(1));
                ships.Add(new Ship(1));
            }
            else
            {
                ships.Add(new Ship(4));
                ships.Add(new Ship(3));
                ships.Add(new Ship(2));
                ships.Add(new Ship(2));
                ships.Add(new Ship(1));
                ships.Add(new Ship(1));
            }
            return ships;
        }//Adds a default number of ships

        private static string YesOrNo()//Checks that the answer is yes, y or no, n and returns y or n in lower case
        {
            string input = Console.ReadLine();
            while (!input.Equals("yes", StringComparison.InvariantCultureIgnoreCase) && !input.Equals("no", StringComparison.InvariantCultureIgnoreCase) && !input.Equals("y",StringComparison.InvariantCultureIgnoreCase) && !input.Equals("n", StringComparison.InvariantCultureIgnoreCase))
            {
                Console.WriteLine("Enter answer again (y/n): ");
                input = Console.ReadLine();
            }
            if (input.Equals("yes", StringComparison.InvariantCultureIgnoreCase) || input.Equals("y", StringComparison.InvariantCultureIgnoreCase))
            {
                input = "y";
            }
            else
            {
                input = "n";
            }
            return input;
        }

        public static int CheckThatInputIsInt()//Makes sure the imput string is convertable to int and returns it
        {
            int inputInt = 0;
            string input = Console.ReadLine();
            while (!int.TryParse(input, out inputInt))
            {
                Console.Write("Please enter a number again: ");
                input = Console.ReadLine();
            }
            return inputInt;
        }

        private static void PlaceShips(GameBoard board, List<Ship> ships)
        {
            foreach (Ship ship in ships)
            {
                Gameboard.PrintGameBoard();
                Console.Write("At which coordinate do you want to place your ship, and in which direction? EX: 4,3,H");
                string input = Console.ReadLine();
                while (!ShipStringIsValid(input))
                {
                    Console.Write("Enter coordinate and direction, EX: 6,5,V");
                    input = Console.ReadLine();
                }
                ship.position = new int[Convert.ToInt32(input[0]), Convert.ToInt32(input[1])];
                ship.direction = input[2];
                while (!ShipPlacementIsValid)
                {

                }
            }
            Console.WriteLine();
        }

        private static bool ShipStringIsValid(string input)
        {
            string[] inputs = input.Split(',');
            int int1;
            int int2;
            if (int.TryParse(inputs[0], out int1) && int.TryParse(inputs[1],out int2))
            {
                if (int1 <= Gameboard.size && int2 <= GameBoard.size)
                {
                    string direction = inputs[3].ToLower();
                    if (direction == "v" || direction == "h")
                    {
                        return true;
                    }

                }
            }
            return false;
        }
    }
}
