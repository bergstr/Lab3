using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    public interface IState
    {
        bool PlayerMove(ComponentBoard Board, ComponentBoard.Coordinate coord1);
        bool PlayerMove(ComponentBoard Board, ComponentBoard.Coordinate coord1, ComponentBoard.Coordinate coord2);
        void Change(Game game);

    }
}