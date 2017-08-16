using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupWork2
{
    class Ship
    {
        string name;
        int size;

        public Ship(int size)
        {
            this.size = size;
            switch (size)
            {
                case 1:
                    name = "Submarine";
                    break;
                case 2:
                    name = "Destroyer";
                    break;
                case 3:
                    name = "Cruiser";
                    break;
                case 4:
                    name = "Battleship";
                    break;
            }
        }
    }
}
