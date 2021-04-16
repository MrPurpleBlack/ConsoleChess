using ConsoleChess.GameElements.Board;
using ConsoleChess.GameElements.Pieces;
using System.Collections.Generic;

namespace ConsoleChess.GameElements.MoveHistory
{
    class MoveHistory
    {
        public List<MoveHistoryItem> Moves { get; set; }

        public MoveHistory()
        {
            Moves = new List<MoveHistoryItem>();
        }

        public void AddMove(Cell from, Cell to, Piece piece, int turn)
        {
            Moves.Add(new MoveHistoryItem(from, to, piece, turn));
        }
    }
}
