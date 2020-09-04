using ConsoleChess.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleChess.Figures.Pieces
{
    class Rook : ChessPiece
    {
        public override string Name => "Rook";
        public override char Display => 'Д';

        public Rook(ConsoleColor side) : base(side)
        {

        }
    }
}
