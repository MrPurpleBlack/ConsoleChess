using ConsoleChess.BusinessLogic;
using ConsoleChess.GameElements;
using ConsoleChess.GameElements.Pieces;
using System.Collections.Generic;

namespace ConsoleChess.Pieces.ChessPieces
{
    class Pawn : Piece
    {
        public override string Name => "Pawn";
        public override char Display => 'i';
        public override List<Direction> MoveDirections
        {
            get
            {
                var defaultDirection = Player.DefaultPieceDirection;
                return new List<Direction> {
                    new Direction(0, defaultDirection.Y),
                    new Direction(1, defaultDirection.Y, true),
                    new Direction(-1, defaultDirection.Y, true),
                    new Direction(0, defaultDirection.Y*2, false, true)};
            }
        }

        public override bool IsContinuous => false;

        public Pawn(Player player) : base(player)
        {

        }

        public override bool IsReadyToConvert(byte y, byte enemiesKingsRow)
        {
            return y == enemiesKingsRow;
        }

        public override bool CanCheckmate(Piece piece)
        {
            return piece.GetType() != typeof(King);
        }
    }
}
