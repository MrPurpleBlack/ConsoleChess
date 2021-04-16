using ConsoleChess.GameElements;
using ConsoleChess.GameElements.Board;
using ConsoleChess.GameElements.MoveHistory;
using ConsoleChess.GameElements.Pieces;
using ConsoleChess.Pieces.ChessPieces;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace ConsoleChess.BusinessLogic
{
    class MovementProcessor
    {
        public Board MainBoard { get; set; }

        private int _currentMove { get; set; }

        public MoveHistory MoveHistory { get; set; }

        private Cell From { get; set; }
        private Cell To { get; set; }

        public MovementProcessor()
        { 
            _currentMove = 0;
            MoveHistory = new MoveHistory();
        }


        /// <summary>
        /// Set the board for the game
        /// </summary>
        public void SetBoard(Board board)
        {
            MainBoard = board;
        }


        public MoveResult ProcessAMove(string move, Player currentPlayer)
        {
            try
            {
                var cells = move.Trim().Split(' ');
                if (cells.Length != 2)
                    throw new IndexOutOfRangeException();


                //Parse and Validate starting cell
                var (x, y) = ParseCellNum(cells[0]);
                From = MainBoard.GetCell(x, y);

                if (From != null && !From.IsOccupied())
                    return MoveResult.EmptyBeginningCell;

                if (From != null && From.IsOccupied() && !From.Piece.IsSameSide(currentPlayer))
                    return MoveResult.WrongBeginningCell;


                //Parse and Validate destination cell
                (x, y) = ParseCellNum(cells[1]);
                To = MainBoard.GetCell(x, y);

                if (To != null && To.IsOccupied() && To.Piece.IsSameSide(currentPlayer))
                    return MoveResult.WrongDestinationCell;


                var possibleMoves = GetPossibleMoves(From);

                if (!possibleMoves.Contains(To))
                    return MoveResult.ImpossibleMove;

                return PerformAMove();
            }
            catch
            {
                return MoveResult.WrongInputFormat;
            }
        }


        private (byte, byte) ParseCellNum(string cell)
        {
            cell = cell.ToUpper();
            byte x = (byte)(cell[0] - 65);
            byte y = (byte)(cell[1] - 49);
            return (x, y);
        }

        private List<Cell> GetPossibleMoves(Cell Start)
        {
            var possibleMoves = new List<Cell>();

            if (Start?.Piece == null)
                return possibleMoves;

            var x = Start.X;
            var y = Start.Y;
            var player = Start.Piece.Player;
            var isContinouos = Start.Piece.IsContinuous;

            foreach (var direction in Start.Piece.MoveDirections.Where(md => !md.FirstMove || (md.FirstMove && IsFirstMove(Start.Piece))))
            {
                for (var i = 1; i < (isContinouos ? MainBoard.Rank : 2); i++)
                {
                    var cell = MainBoard.GetCell(x + direction.X * i, y + direction.Y * i);
                    if (cell == null)
                        break;

                    if (cell.IsOccupied())
                    {
                        if (!cell.Piece.IsSameSide(player))
                            possibleMoves.Add(cell);

                        break;
                    }

                    if (!direction.OnlyWithAttack)
                        possibleMoves.Add(cell);
                }
            }

            return possibleMoves;
        }

        public MoveResult PerformAMove()
        {
            To.SetOccupation(From.Piece);
            From.ClearOccupation();
            MoveHistory.AddMove(From, To, To.Piece, _currentMove);
            _currentMove++;

            if (To.Piece.IsReadyToConvert(To.Y, To.Piece.Player.EnemiesKingsRow))
                return MoveResult.NeedToConvert;

            return MoveResult.Success;
        }

        public MoveResult ConvertPiece(string target, Player currentPlayer)
        {
            switch (target.ToLower())
            {
                case "queen":
                case "w":
                    To.SetOccupation(new Queen(currentPlayer));
                    break;

                case "bishop":
                case "i":
                    To.SetOccupation(new Bishop(currentPlayer));
                    break;

                case "knight":
                case "2":
                    To.SetOccupation(new Knight(currentPlayer));
                    break;

                case "rook":
                case "д":
                    To.SetOccupation(new Rook(currentPlayer));
                    break;
                default:
                    return MoveResult.NeedToConvert;
            }

            return MoveResult.Success;
        }



        public bool IsFirstMove(Piece piece)
        {
            return !MoveHistory.Moves.Any(item => item.Equals(piece));
        }
    }
}
