using ConsoleChess.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleChess.Figures
{
    public class ChessPiece
    {
        /// <summary>
        /// Figure name
        /// </summary>
        public virtual string Name { get;}

        /// <summary>
        /// Display char
        /// </summary>
        public virtual char Display { get; }

        /// <summary>
        /// Pieces side
        /// </summary>
        public ConsoleColor Side { get; private set; }

        public ConsoleColor CellColor => Side == Constants.Black ? Constants.White : Constants.Black;
        public ConsoleColor PieceColor => Side == Constants.Black ? Constants.Black : Constants.White;



        public ChessPiece(ConsoleColor side)
        {
            Side = side;
        }  
    }
}
