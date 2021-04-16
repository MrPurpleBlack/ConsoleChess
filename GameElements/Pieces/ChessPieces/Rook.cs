using ConsoleChess.BusinessLogic;
using ConsoleChess.GameElements;
using ConsoleChess.GameElements.Pieces;
using System.Collections.Generic;

namespace ConsoleChess.Pieces.ChessPieces
{
    class Rook : Piece
    {
        public override string Name => "Rook";
        public override char Display => 'Д';
        public override List<Direction> MoveDirections => new List<Direction> { 
            new Direction(1, 0), new Direction(0, 1), new Direction(-1, 0), new Direction(0, -1) };

        public Rook(Player player) : base(player)
        {

        }
    }
}
