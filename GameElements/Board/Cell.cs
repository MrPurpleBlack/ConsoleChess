using ConsoleChess.Figures;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleChess.Game_elements.Board
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
    }
}
