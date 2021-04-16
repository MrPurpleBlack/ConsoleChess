using ConsoleChess.GameElements;
using ConsoleChess.GameElements.Pieces;
using System.Collections.Generic;

namespace ConsoleChess.Pieces.ChessPieces
{
    class King : Piece
    {
        public override string Name => "King";
        public override char Display => 'Ф';
        public override List<Direction> MoveDirections => new List<Direction> { 
                        new Direction(1, 1), new Direction(1, 0), new Direction(1, -1), new Direction(0, 1),
                        new Direction(0, -1), new Direction(-1, 1), new Direction(-1, 0), new Direction(-1, -1) };
        public override bool IsContinuous => false;

        public King(Player player) : base(player)
        {

        }
    }
}
