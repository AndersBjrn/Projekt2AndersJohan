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
            List<Player> players = new List<Player>();
            Console.Write("Hur stor spelplan vill du ha? (x gånger x rutor): ");
            int size = CheckThatInputIsInt();
            for (int i = 0; i < 2; i++)
            {
                GameBoard board = GameBoard.CreateBoard(size);
                Console.WriteLine("Enter name for player" + (i + 1));
                Player player = new Player(Console.ReadLine(), board);
                players.Add(player);
            }
            for (int i = 0; i < 2; i++)
            {
                GameBoard b = players[i].board;
                List<Ship> ships = new List<Ship>(ChooseShips(b));
                PlaceShips(b, ships);
            }
            Playgame(players);
        }

        private static void Playgame(List<Player> players)
        {
            while (true)
            {
                for (int i = 0; i < 2; i++)
                {
                    Console.WriteLine("Player "+ players[i].name + ", enter coordinate to shoot! (ex 4 + enter + 3)" );
                    int Xcoordinate = CheckThatInputIsInt();
                    int Ycoordinate = CheckThatInputIsInt();
                    Shoot(players[i].board, Xcoordinate, Ycoordinate);
                    GameBoard.PrintBoard(players[i].board);
                }
            }
        }

        private static void Shoot(GameBoard board, int x, int y)
        {
            if (board.matrix[x,y] == 0)
            {
                board.matrix[x, y] = 3;
            }
            else if (board.matrix[x, y] == 1)
            {
                board.matrix[x, y] = 2;
            }
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
            if (board.size * board.size > 64)
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
            while (!input.Equals("yes", StringComparison.InvariantCultureIgnoreCase) && !input.Equals("no", StringComparison.InvariantCultureIgnoreCase) && !input.Equals("y", StringComparison.InvariantCultureIgnoreCase) && !input.Equals("n", StringComparison.InvariantCultureIgnoreCase))
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
                bool breakFlag = false;
                string[] coordinate = null;
                while (!breakFlag)
                {
                    coordinate = AskForCoordinateForShip(board, ship);
                    int coordinateX = Convert.ToInt32(coordinate[0]);
                    int coordinateY = Convert.ToInt32(coordinate[1]);
                    string direction = coordinate[2];
                    if (ShipPositionIsValid(coordinateX, coordinateY, board, ship, direction))
                    {
                        ship.positionX = coordinateX;
                        ship.positionY = coordinateY;
                        ship.direction = direction;
                        board = AddShipToBoard(board, ship);
                        breakFlag = true;
                    }
                    GameBoard.PrintBoard(board);
                }
            }
        }

        private static GameBoard AddShipToBoard(GameBoard board, Ship ship)
        {
            string direction = ship.direction;
            for (int i = 0; i < ship.size; i++)
            {
                if (ship.direction.Equals("v"))
                {
                    board.matrix[ship.positionX + i, ship.positionY] = 1;
                }
                else if (ship.direction.Equals("h"))
                {
                    board.matrix[ship.positionX, ship.positionY + i] = 1;
                }
            }
            return board;
        }

        private static string[] AskForCoordinateForShip(GameBoard board, Ship ship)
        {
            Console.Write("At which coordinate do you want to place your ship: " + ship.name + ", and in which direction? Ex: 4,3,H: ");
            string input = Console.ReadLine();
            while (!ShipStringIsValid(input, board))
            {
                Console.Write("Enter coordinate and direction, EX: 6,5,V");
                input = Console.ReadLine();
            }
            string[] shipCoordinate = input.Split(',');
            return shipCoordinate;
        }

        private static bool ShipPositionIsValid(int coordinateX, int coordinateY, GameBoard board, Ship ship, string direction)
        {
            if (coordinateX > board.size || coordinateY > board.size)
            {
                return false;
            }
            if (direction.Equals("v"))
            {
                if (coordinateX + ship.size > board.size)
                {
                    return false;
                }
            }
            if (direction.Equals("h"))
            {
                if (coordinateY + ship.size > board.size)
                {
                    return false;
                }
            }

            for (int i = 0; i < ship.size; i++)
            {
                if (direction.Equals("v"))
                {
                    if (board.matrix[coordinateX + i, coordinateY] != 0)
                    {
                        return false;
                    }
                    else if (direction.Equals("h"))
                    {
                        if (board.matrix[ship.positionX, ship.positionY + i] != 0)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private static bool ShipStringIsValid(string input, GameBoard board)
        {
            string[] inputs = input.Split(',');
            if (inputs.Length != 3)
            {
                return false;
            }
            int int1;
            int int2;
            if (int.TryParse(inputs[0], out int1) && int.TryParse(inputs[1], out int2))
            {
                if (int1 <= board.size && int2 <= board.size)
                {
                    string direction = inputs[2].ToLower();
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
