using ConsoleChess.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleChess.Figures.Pieces
{
    class King : ChessPiece
    {
        public override string Name => "King";
        public override char Display => 'Ф';

        public King(ConsoleColor side) : base(side)
        {

        }
    }
}
