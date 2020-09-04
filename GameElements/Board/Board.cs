using ConsoleChess.BusinessLogic;
using ConsoleChess.Figures;
using ConsoleChess.Figures.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleChess.GameElements.Board
{
    class Board
    {
        public Cell[] Cells { get; set; }

        public byte Rank => Constants.BoardRank;

        public Board()
        {
            Cells = new Cell[Rank * Rank];
            for (var i = 0; i < Rank * Rank; i++)
                Cells[i] = new Cell((byte)(i % Rank), (byte)(i / Rank));

            SetDefaultPieces();
        }

        public Cell GetCell(byte x, byte y)
        {
            if (x >= Rank && y >= Rank)
                throw new IndexOutOfRangeException();

            return Cells[y * Rank + x];
        }


        private void SetDefaultPieces()
        {
            byte mainLine = 0;
            byte pawnLine = 1;


            foreach(ConsoleColor side in Constants.Sides)
            {
                var piecesOrder = new ChessPiece[8] { 
                    new Rook(side),
                    new Knight(side),
                    new Bishop(side),
                    new Queen(side),
                    new King(side),
                    new Bishop(side),
                    new Knight(side),
                    new Rook(side)
                };

                for (byte i = 0; i < Rank; i++)
                {
                    GetCell(i, mainLine).SetOccupation(piecesOrder[i]);
                    GetCell(i, pawnLine).SetOccupation(new Pawn(side));
                }
                mainLine = (byte)(Rank - 1 - mainLine);
                pawnLine = (byte)(Rank - 1 - pawnLine);

            }

            
        }
    }
}
