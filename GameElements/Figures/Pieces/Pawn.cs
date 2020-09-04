using ConsoleChess.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleChess.Figures.Pieces
{
    class Pawn : ChessPiece
    {
        public override string Name => "Pawn";
        public override char Display => 'i';

        public Pawn(ConsoleColor side) : base(side)
        {

        }
    }
}
