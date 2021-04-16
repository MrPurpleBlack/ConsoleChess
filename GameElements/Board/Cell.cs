using ConsoleChess.BusinessLogic;
using ConsoleChess.GameElements.Pieces;
using System;

namespace ConsoleChess.GameElements.Board
{
    public class Cell
    {
        /// <summary>
        /// X coordinate of cell
        /// </summary>
        public byte X { get; set; }

        /// <summary>
        /// X coordinate of cell
        /// </summary>
        public byte Y { get; set; }

        /// <summary>
        /// Chess piece
        /// </summary>
        public Piece Piece { get; private set; }


        public string AlphabeticalNum => Convert.ToChar(65 + X).ToString() + Convert.ToChar(49 + Y);

        /// <summary>
        /// Cell color
        /// </summary>
        public ConsoleColor Color => (X % 2 == 0) ^ (Y % 2 == 1)
                ? Constants.White
                : Constants.Black;

        public Cell(byte x, byte y)
        {
            X = x;
            Y = y;
        }

        public bool IsOccupied()
        {
            return Piece != null;
        }

        public void SetOccupation(Piece piece)
        {
            Piece = piece;

        }

        public void ClearOccupation()
        {
            Piece = null;
        }
    }
}
