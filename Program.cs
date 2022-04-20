using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {

            bool islargeboard = false;
            string inputmoves = args[0].ToUpper();
            string trimmedmoves = String.Concat(inputmoves.Where(x => !char.IsWhiteSpace(x) && !char.IsControl(x)));
            string[] moves = trimmedmoves.Split(",", StringSplitOptions.RemoveEmptyEntries);

            try
            {
                if (moves[0].Contains('.'))
                {
                    islargeboard = true;
                }
            }

            catch (IndexOutOfRangeException)
            {
                Console.Clear();
                System.Console.WriteLine("The provided input contained bad or no characters!");
                return;
            }

            Score scoreboard = new Score();
            ComponentBoard.Coordinate[] coordinates = new ComponentBoard.Coordinate[] { };
            ComponentBoard board;

            if (islargeboard)
            {
                board = new CompositeBoard();
            }
            else
            {
                board = new LeafBoard();
            }

            // A game should be supplied with a board to play on
            Game game = new Game(board);

            try
            {
                foreach (string move in moves)
                {

                    string[] splittedmove = move.Split(".", StringSplitOptions.RemoveEmptyEntries);
                    coordinates = Array.ConvertAll(splittedmove, item => (ComponentBoard.Coordinate)Enum.Parse(typeof(ComponentBoard.Coordinate), item));

                    if (islargeboard)
                    {
                        game.PlayerMove(coordinates[0], coordinates[1]);
                    }

                    else
                    {
                        game.PlayerMove(coordinates[0]);
                    }


                    if (board.CheckWin())
                    {
                        break;
                    }

                }

                scoreboard.PrintScore((dynamic)board);
            }

            catch (ArgumentException)
            {
                Console.Clear();
                System.Console.WriteLine("Incorrect input!");
            }

            catch (InvalidOperationException)
            {
                Console.Clear();
                System.Console.WriteLine("The input does not match allowed characters!");
            }
            catch (NotImplementedException)
            {
                Console.Clear();
                System.Console.WriteLine("The called upon object cannot perform the task provided!");
            }
            catch (Exception)
            {
                Console.Clear();
                System.Console.WriteLine("Error!");
            }
        }
    }
}
