using ConsoleChess.BusinessLogic;
using ConsoleChess.GameElements.Pieces;
using System;
using System.Text;

namespace ConsoleChess.GameElements.Board
{
    public class Board
    {
        public Cell[] Cells { get; set; }

        public byte Rank { get; set; }

        public Board(byte rank)
        {
            Rank = rank;
            Cells = new Cell[Rank * Rank];
            for (var i = 0; i < Rank * Rank; i++)
                Cells[i] = new Cell((byte)(i % Rank), (byte)(i / Rank));
        }

        public Cell GetCell(int index)
        {
            if (IsValidCellIndex(index))
                return Cells[index];

            return null;
        }

        public Cell GetCell(int x, int y)
        {
            if (x < 0 || y < 0)
                return null;
            return GetCell(y * Rank + x);
        }

        public bool IsValidCellIndex(int index)
        {
            return (index >= 0 && index < Rank*Rank);
        }

        public void SetPieces(Piece[] pieces)
        {
            if (Cells?.Length != pieces?.Length)
                throw new ArgumentOutOfRangeException();

            for (var i = 0; i < Rank * Rank; i++)
                GetCell(i).SetOccupation(pieces[i]);
        }
    }


}
