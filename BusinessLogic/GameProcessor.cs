using ConsoleChess.Figures;
using ConsoleChess.GameElements.Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleChess.BusinessLogic
{
    class GameProcessor
    {
        public Board MainBoard { get; set; }
        private DrawProcessor DrawProcessor { get; }


        private ConsoleColor _currentSide { get; set; }
        private Cell From { get; set; }
        private Cell To { get; set; }

        private List<string> Errors { get; set; }



        public GameProcessor()
        {
            MainBoard = new Board();
            _currentSide = Constants.White;
            DrawProcessor = new DrawProcessor(MainBoard);
            Errors = new List<string>();
        }

        public void Start()
        {


            while (true)
                Turn();


        }


        private void Turn()
        {
            DrawProcessor.Clear();
            DrawProcessor.DrawBoard();
            DisplayInfo();
            DisplayErrors();

            ParseAndValidate(GetMove());

            if(!Errors.Any())
            {
                MakeMove();
                SwapSides();
            }

            
        }


        private string GetMove()
        {
            Console.Write("Your move: ");
            return Console.ReadLine();
        }

        private void MakeMove()
        {
            To.SetOccupation(From.Piece);
            From.ClearOccupation();
        }



        private void ParseAndValidate(string move)
        {
            try
            {
                var cells = move.Trim().Split(' ');
                if (cells.Length > 2)
                    throw new IndexOutOfRangeException();


                //Parse and Validate starting cell
                var (x, y) = ParseCellNum(cells[0]);

                Console.WriteLine(x);
                Console.WriteLine(y);
                Console.ReadLine();
                From = MainBoard.GetCell(x, y);

                CheckFromCellForAvailability();


                //Parse and Validate destination cell
                (x, y) = ParseCellNum(cells[1]);
                To = MainBoard.GetCell(x, y);

                Console.WriteLine(x);
                Console.WriteLine(y);
                Console.ReadLine();

                CheckToCellForAvailability();
            }
            catch
            {
                Errors.Add("Input format of your move is wrong. Try Again");
            }
        }

        private (byte,byte) ParseCellNum(string cell)
        {
            byte x = (byte)(cell[0] - 65);
            byte y = (byte)(cell[1] - 49);
            return (x, y);
        }

        private void CheckFromCellForAvailability()
        {
            if (From.Piece == null)
                Errors.Add("Chosen starting position is empty");

            if(From.Piece != null && From.Piece.Side != _currentSide)
                Errors.Add($"Chosen piece is {From.Piece.Side} {From.Piece.Name}. Now is {_currentSide}'s turn.");
        }

        private void CheckToCellForAvailability()
        {
            if (To.Piece != null && To.Piece.Side == _currentSide)
                Errors.Add($"Chosen destination position is occupied by your {To.Piece.Side} {To.Piece.Name}");

        }



        private void DisplayInfo()
        {
            DrawProcessor.Display("");
            DrawProcessor.Display("Type in your move in following format - \"A7 A5\"");
            DrawProcessor.Display("");
            DrawProcessor.Display($"Now is {_currentSide}'s turn");
        }


        private void DisplayErrors()
        {
            foreach(var error in Errors)
                DrawProcessor.DisplayError(error);

            Errors.Clear();
        }

        private void SwapSides()
        {
            _currentSide = _currentSide == Constants.Black ? Constants.White : Constants.Black;
        }


        
    }
}
