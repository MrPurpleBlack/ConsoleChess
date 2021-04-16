using ConsoleChess.GameElements.Board;
using ConsoleChess.GameElements.Pieces;

namespace ConsoleChess.GameElements.MoveHistory
{
    public class MoveHistoryItem
    {
        /// <summary>
        /// Starting cell
        /// </summary>
        public Cell From { get; private set; }

        /// <summary>
        /// Destination cell
        /// </summary>
        public Cell To { get; private set; }

        /// <summary>
        /// Player that made a move
        /// </summary>
        public Piece Piece { get; private set; }

        /// <summary>
        /// Turn of move
        /// </summary>
        public int Turn { get; private set; }


        public MoveHistoryItem(Cell from, Cell to, Piece piece, int turn)
        {
            From = from;
            To = to;
            Piece = piece;
            Turn = turn;
        }
    }
}
