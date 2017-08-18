using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupWork2
{
    class Player
    {
        public string name { get; set; }
        public GameBoard board { get; set; }

        public Player(string name, GameBoard board)
        {
            this.name = name;
            this.board = board;
        }
    }
}
