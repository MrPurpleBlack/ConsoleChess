using ConsoleChess.BusinessLogic;
using ConsoleChess.Pieces.ChessPieces;
using ConsoleChess.GameElements.Pieces;
using System.Collections.Generic;
using System.Text;

namespace ConsoleChess.GameElements.Presets
{
    class ClassicChessPreset : Preset
    {
        public ClassicChessPreset()
        {
            BoardRank = 8;

            var black = new Player("Black", Constants.Black, 0, 7, new Direction(0,1));
            var white = new Player("White", Constants.White, 7, 0, new Direction(0,-1));
            Players = new Queue<Player>();
            Players.Enqueue(white);
            Players.Enqueue(black);

            StartingPosition = new Piece[]
            {
                    new Rook(black),null,new Bishop(black),new Queen(black),new King(black),new Bishop(black),new Knight(black),new Rook(black),
                    new Pawn(black),new Pawn(white),new Pawn(black),new Pawn(black),new Pawn(black),new Pawn(black),new Pawn(black),new Pawn(black),
                    null,null,null,null,null,null,null,null,
                    null,null,null,null,null,null,null,null,
                    null,null,null,null,null,null,null,null,
                    null,null,null,null,null,null,null,null,
                    new Pawn(white),new Pawn(white),new Pawn(white),new Pawn(white),new Pawn(white),new Pawn(white),new Pawn(white),new Pawn(white),
                    new Rook(white),new Knight(white),new Bishop(white),new Queen(white),new King(white),new Bishop(white),new Knight(white),new Rook(white)
            };
        }
    }
}
