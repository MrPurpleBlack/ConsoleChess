using ConsoleChess.GameElements;
using ConsoleChess.GameElements.Pieces;
using System.Collections.Generic;

namespace ConsoleChess.Pieces.ChessPieces
{
    class Bishop : Piece
    {
        public override string Name => "Bishop";
        public override char Display => 'I';
        public override List<Direction> MoveDirections => new List<Direction> {
            new Direction(1, 1), new Direction(1, -1), new Direction(-1, 1), new Direction(-1, -1) };

        public Bishop(Player player) : base(player)
        {

        }
    }
}
