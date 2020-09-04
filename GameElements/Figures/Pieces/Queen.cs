using ConsoleChess.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleChess.Figures.Pieces
{
    class Queen : ChessPiece
    {
        public override string Name => "Queen";
        public override char Display => 'W';

        public Queen(ConsoleColor side) : base(side)
        {

        }
    }
}
