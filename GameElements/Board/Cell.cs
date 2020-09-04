using ConsoleChess.BusinessLogic;
using ConsoleChess.Figures;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleChess.GameElements.Board
{
    class Cell
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
        public ChessPiece Piece { get; private set; }

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

        public bool SetOccupation(ChessPiece chessPiece)
        {
            if(!IsOccupied())
            {
                Piece = chessPiece;
                return true;
            }
            return false;
        }

        public void ClearOccupation()
        {
            Piece = null;
        }


        public bool IsAvailableStartingPosition(ConsoleColor player)
        {
            return Piece != null && Piece.Side == player;
        }

        public bool IsAvailabledestinationPosition(ConsoleColor player)
        {
            return Piece != null && Piece.Side == player;
        }
    }
}
