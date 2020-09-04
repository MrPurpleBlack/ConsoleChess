using ConsoleChess.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleChess.Figures.Pieces
{
    class Knight : ChessPiece
    {
        public override string Name => "Knight";
        public override char Display => '2';

        public Knight(ConsoleColor side) : base(side)
        {

        }
    }
}
