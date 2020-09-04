using ConsoleChess.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleChess.Figures.Pieces
{
    class Bishop : ChessPiece
    {
        public override string Name => "Bishop";
        public override char Display => 'I';

        public Bishop(ConsoleColor side) : base(side)
        {

        }
    }
}
