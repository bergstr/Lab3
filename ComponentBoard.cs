using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    public abstract class ComponentBoard
    {
        public Player WonBy { get; set; }
        public List<Coordinate> winList;
        public List<Coordinate> PlayerXMoves;
        public List<Coordinate> PlayerOMoves;
        public abstract bool MakeMove(Player player, Coordinate coordinate);
        public abstract bool MakeMove(Player player, Coordinate largeCoordinate, Coordinate smallCoordinate);
        public abstract bool CheckWin();
        public abstract void Add(ComponentBoard board);
        public abstract bool TripleCoordinateMatch(Coordinate coord1, Coordinate coord2, Coordinate coord3);
        public abstract bool CheckPatternWin();

        public enum Coordinate
        {
            NW = 0,
            NC = 1,
            NE = 2,
            CW = 3,
            CC = 4,
            CE = 5,
            SW = 6,
            SC = 7,
            SE = 8
        }

        public enum Player
        {
            None = 0,
            X = 1,
            O = 2
        }
    }
}
