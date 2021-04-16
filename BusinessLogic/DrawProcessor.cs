using ConsoleChess.GameElements.Board;
using System;
using System.Text;

namespace ConsoleChess.BusinessLogic
{
    class DrawProcessor
    {
        /// <summary>
        /// Board for the drawing
        /// </summary>
        public Board MainBoard { get; set; }

        /// <summary>
        /// Width of the cell in chars
        /// </summary>
        private readonly byte _cellWidth = Constants.CellWidth;
        /// <summary>
        /// Height of the cell in chars
        /// </summary>
        private readonly byte _cellHeight = Constants.CellHeight;

        private readonly ConsoleColor _whiteColor = Constants.White;
        private readonly ConsoleColor _blackColor = Constants.Black;

        public DrawProcessor()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.WindowHeight = 50;
            Console.WindowWidth = 30;
        }

        /// <summary>
        /// Draw empty board
        /// </summary>
        public void DrawBoard()
        {
            DrawAlphabethicalLine();
            for (byte i = 0; i < MainBoard.Rank; i++)
                DrawChessBoardLine(i);
        }

        /// <summary>
        /// Clear screen
        /// </summary>
        public void Clear()
        {
            Console.Clear();
        }

        /// <summary>
        /// Set the board for the game
        /// </summary>
        public void SetBoard(Board board)
        {
            MainBoard = board;
            
            Console.WindowHeight = (MainBoard.Rank + 5) * _cellHeight;
            Console.WindowWidth = (MainBoard.Rank + 2) * _cellWidth;
        }



        private void DrawChessBoardLine(byte numOfLine)
        {
            var rank = MainBoard.Rank;
            
            // num of line where pieces being displayed
            var lineWithChars = _cellHeight / 2;

            for(byte i = 0; i < _cellHeight; i++)
            {
                for (byte j = 0; j < rank; j++)
                    DrawOneLineCell(MainBoard.GetCell(j, numOfLine), i == lineWithChars);

                if (i == lineWithChars)
                    DrawOneLineCell(_blackColor, _blackColor, _whiteColor, Convert.ToChar(49 + numOfLine));

                Console.WriteLine();
            }          
        }

        private void DrawAlphabethicalLine()
        {
            var rank = MainBoard.Rank;
            Console.WriteLine();

            for (var i = 0; i < rank; i++)
                DrawOneLineCell(_blackColor, _blackColor, _whiteColor, Convert.ToChar(65 + (i % rank)));

            Console.WriteLine();
            Console.WriteLine();
        }
 

        private void DrawOneLineCell(Cell cell, bool isCenterOfCell)
        {
            var cellColor = cell.Color;
            var pieceColor = cell.Color;
            var display = ' ';

            if (isCenterOfCell)
            {
                cellColor = GetOppositeColor(cell.Piece?.Player?.Color) ?? cell.Color;
                pieceColor = cell.Piece?.Player?.Color ?? cell.Color;
                display = cell.Piece?.Display ?? ' ';
            }

            DrawOneLineCell(cell.Color, cellColor, pieceColor , display);
        }


        private void DrawOneLineCell(ConsoleColor emptyColor, ConsoleColor cellColor, ConsoleColor pieceColor, char display)
        {
            var offset = _cellWidth / 2;

            SetCellColor(emptyColor);
            SetPieceColor(emptyColor);
            Console.Write(new string(' ', offset));

            SetCellColor(cellColor);
            SetPieceColor(pieceColor);
            Console.Write(display);

            SetCellColor(emptyColor);
            SetPieceColor(emptyColor);
            Console.Write(new string(' ', _cellWidth - offset - 1));
        }


        public void DisplayError(string error)
        {
            SetCellColor(_blackColor);
            SetPieceColor(Constants.Error);
            Console.WriteLine(error);
            SetPieceColor(_whiteColor);
        }

        public void Display(string info)
        {
            SetCellColor(_blackColor);
            SetPieceColor(_whiteColor);
            Console.WriteLine(info);
        }


        private void SetCellColor(ConsoleColor color)
        {
            Console.BackgroundColor = color;
        }

        
        private void SetPieceColor(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }

        private ConsoleColor? GetOppositeColor(ConsoleColor? color)
        {
            if (color == null)
                return null;
            return (ConsoleColor)(15 - (int)color);
        }
    }
}
