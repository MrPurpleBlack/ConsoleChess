using ConsoleChess.GameElements;
using ConsoleChess.GameElements.Pieces;
using System.Collections.Generic;

namespace ConsoleChess.Pieces.ChessPieces
{
    class Knight : Piece
    {
        public override string Name => "Knight";
        public override char Display => '2';
        public override List<Direction> MoveDirections =>  new List<Direction> {
                        new Direction(2, 1), new Direction(2, -1), new Direction(-2, 1), new Direction(-2, -1),
                        new Direction(1, 2), new Direction(1, -2), new Direction(-1, 2), new Direction(-1, -2) };
        public override bool IsContinuous => false;

        public Knight(Player player) : base(player)
        {

        }
    }
}
