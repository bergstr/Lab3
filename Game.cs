using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    public class Game
    {
        public IState State { get; set; }
        ComponentBoard Board { get; set; }

        public Game(ComponentBoard board)
        {
            this.State = new PlayerXState();
            this.Board = board;
        }

        public void PlayerMove(ComponentBoard.Coordinate coord1)
        {
            if (State.PlayerMove(Board, coord1))
            {
                State.Change(this);
            }
        }

        public void PlayerMove(ComponentBoard.Coordinate coord1, ComponentBoard.Coordinate coord2)
        {
            if (State.PlayerMove(Board, coord1, coord2))
            {
                State.Change(this);
            }
        }

    }
}
