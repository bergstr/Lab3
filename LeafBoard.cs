using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab3
{
    public class LeafBoard : ComponentBoard
    {
        public Player[] Grid;

        public LeafBoard()
        {
            Grid = new Player[9] { Player.None, Player.None, Player.None, Player.None, Player.None, Player.None, Player.None, Player.None, Player.None };
            WonBy = Player.None;
            winList = new List<Coordinate>();
            PlayerXMoves = new List<Coordinate>();
            PlayerOMoves = new List<Coordinate>();
        }


        /// <summary>
        /// Changes Player.None to provided player in grid element according to coordinate.
        /// </summary>
        /// <param name="player">Player enum</param>
        /// <param name="coordinate">LeafBoard coordinate</param>
        /// <returns>If successful</returns>
        public override bool MakeMove(Player player, Coordinate coordinate)
        {
            if (this.WonBy == Player.None && Grid[(int)coordinate] == Player.None)
            {
                Grid[(int)coordinate] = player;
                switch (player)
                {
                    case Player.X:
                        PlayerXMoves.Add(coordinate);
                        break;

                    case Player.O:
                        PlayerOMoves.Add(coordinate);
                        break;
                }
                
                return true;
            }

            return false;
        }

        public override bool MakeMove(Player player, Coordinate largeCoordinate, Coordinate smallCoordinate)
        {
            Console.WriteLine("Leaf cannot handle multiple coordinates!");
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns whether 3 "Player"-attributes in the Grid collection match each other if so add those coordinates to winList from PlayerMoves.
        /// </summary>
        /// <param name="coord1">First Coordinate</param>
        /// <param name="coord2">Second Coordinate</param>
        /// <param name="coord3">Third Coordinate</param>
        /// <returns>If coordinates matched</returns>
        public override bool TripleCoordinateMatch(Coordinate coord1, Coordinate coord2, Coordinate coord3)
        {
            if (Grid[(int)coord1] == Grid[(int)coord2] && Grid[(int)coord2] == Grid[(int)coord3] && Grid[(int)coord1] != Player.None)
            {
                WonBy = Grid[(int)coord1];
                switch (WonBy)
                {
                    case Player.X:
                        winList = PlayerXMoves.Where(x => x == coord1 || x == coord2 || x == coord3).ToList();
                        break;

                    case Player.O:
                        winList = PlayerOMoves.Where(x => x == coord1 || x == coord2 || x == coord3).ToList();
                        break;
                }
                return true;
            }
            return false;
        }

        public override bool CheckPatternWin()
        {
            // Horizontal 1 - 0 1 2
            if (TripleCoordinateMatch(Coordinate.NW, Coordinate.NC, Coordinate.NE))
            {
                return true;
            }
            // Horizontal 2 - 3 4 5
            else if (TripleCoordinateMatch(Coordinate.CW, Coordinate.CC, Coordinate.CE))
            {
                return true;
            }
            // Horizontal 3 - 6 7 8
            else if (TripleCoordinateMatch(Coordinate.SW, Coordinate.SC, Coordinate.SE))
            {
                return true;
            }
            // Vertical   1 - 0 3 6
            else if (TripleCoordinateMatch(Coordinate.NW, Coordinate.CW, Coordinate.SW))
            {
                return true;
            }
            // Vertical   2 - 1 4 7
            else if (TripleCoordinateMatch(Coordinate.NC, Coordinate.CC, Coordinate.SC))
            {
                return true;
            }
            // Vertical   3 - 2 5 8
            else if (TripleCoordinateMatch(Coordinate.NE, Coordinate.CE, Coordinate.SE))
            {
                return true;
            }
            // Diagonal   1 - 0 4 8
            else if (TripleCoordinateMatch(Coordinate.NW, Coordinate.CC, Coordinate.SE))
            {
                return true;
            }
            // Diagonal   2 - 2 4 6
            else if (TripleCoordinateMatch(Coordinate.NE, Coordinate.CC, Coordinate.SW))
            {
                return true;
            }

            return false;
        }

        public override bool CheckWin()
        {
            return CheckPatternWin();
        }

        public override void Add(ComponentBoard componentboard)
        {
            Console.WriteLine("Leaf nodes can't add components!");
            throw new NotImplementedException();
        }

    }
}
