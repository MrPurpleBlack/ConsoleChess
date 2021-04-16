using ConsoleChess.GameElements;
using ConsoleChess.GameElements.Pieces;
using System.Collections.Generic;

namespace ConsoleChess.Pieces.ChessPieces
{
    class Queen : Piece
    {
        public override string Name => "Queen";
        public override char Display => 'W';
        public override List<Direction> MoveDirections => new List<Direction> { 
            new Direction(1, 1), new Direction(1, 0), new Direction(1, -1), new Direction(0, 1),
            new Direction(0, -1), new Direction(-1, 1), new Direction(-1, 0), new Direction(-1, -1) };

        public Queen(Player player) : base(player)
        {

        }
    }
}
