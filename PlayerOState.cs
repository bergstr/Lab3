using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    class PlayerOState : IState
    {
        public bool PlayerMove(ComponentBoard Board, ComponentBoard.Coordinate coord1)
        {
            if (Board.MakeMove(ComponentBoard.Player.O, coord1))
            {
                return true;
            }
            return false;
        }

        public bool PlayerMove(ComponentBoard Board, ComponentBoard.Coordinate coord1, ComponentBoard.Coordinate coord2)
        {
            if (Board.MakeMove(ComponentBoard.Player.O, coord1, coord2))
            {
                return true;
            }
            return false;
        }

        public void Change(Game game)
        {
            game.State = new PlayerXState();
        }

    }
}
