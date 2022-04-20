using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Lab3
{
    public class Score : IScore
    {
        string compositeWinString = "";
        string leafWinString = "";
        int xLeafWins = 0;
        int oLeafWins = 0;

        public void PrintScore(LeafBoard leafBoard)
        {
            Console.WriteLine("");

            foreach (ComponentBoard.Coordinate coordinate in leafBoard.winList)
            {
                leafWinString += coordinate.ToString() + ", ";
            }
            Console.WriteLine(leafWinString.Substring(0, leafWinString.Length - 2));

            switch (leafBoard.WonBy)
            {
                case ComponentBoard.Player.X:
                    Console.WriteLine("1, 0");
                    break;

                case ComponentBoard.Player.O:
                    Console.WriteLine("0, 1");
                    break;
            }
        }

        public void PrintScore(CompositeBoard compositeBoard)
        {
            xLeafWins = compositeBoard.Grid.Where(x => x.WonBy == ComponentBoard.Player.X).Count();
            oLeafWins = compositeBoard.Grid.Where(x => x.WonBy == ComponentBoard.Player.O).Count();


            foreach (ComponentBoard.Coordinate largeCoordinate in compositeBoard.winList)
            {
                compositeWinString += largeCoordinate.ToString() + ", ";

                foreach (ComponentBoard.Coordinate leafcoordinate in compositeBoard.Grid[(int)largeCoordinate].winList)
                {
                    leafWinString += largeCoordinate.ToString() + "." +  leafcoordinate.ToString() + ", ";
                }

            }
            Console.WriteLine(compositeWinString.Substring(0, compositeWinString.Length - 2));
            Console.WriteLine(leafWinString.Substring(0, leafWinString.Length - 2));


            switch (compositeBoard.WonBy) 
            {
                case ComponentBoard.Player.X:
                    Console.WriteLine("1" + "." + xLeafWins + ", " + "0" + "." + oLeafWins);
                    break;

                case ComponentBoard.Player.O:
                    Console.WriteLine("0" + "." + xLeafWins + ", " + "1" + "." + oLeafWins);
                    break;

                case ComponentBoard.Player.None:
                    Console.WriteLine("0" + "." + xLeafWins + ", " + "0" + "." + oLeafWins);
                    break;
            }
        }

        public void PrintScore(ComponentBoard componentBoard)
        {
            throw new NotImplementedException();
        }
    }
}
