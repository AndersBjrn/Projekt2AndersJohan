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
            // Hello from Johan

            GameBoard board = CreateBoard();
            ChooseShips(board);
            PlaceShips();
        }

        private static List<Ship> ChooseShips(GameBoard board)
        {
            Console.WriteLine("Do you want default number of ships?(y/n):");
            string answer = YesOrNo();
            if (answer == "y")
            {
                return DecideDefaultNumberOfShips();
            }
            else
            {
                List<Ship> ships = new List<Ship>();
                Console.Write("How many Battleships(size 4)?: ");
                int battleships = CheckThatInputIsInt();
                return ships;
            }
        }

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

        private static int CheckThatInputIsInt()//Makes sure the imput string is convertable to int and returns it
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

        private static void PlaceShips(board)
        {
            Console.WriteLine();
        }
    }
}
