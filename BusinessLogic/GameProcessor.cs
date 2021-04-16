using ConsoleChess.GameElements;
using ConsoleChess.GameElements.Board;
using ConsoleChess.GameElements.Presets;
using System;
using System.Collections.Generic;
using System.Linq;


namespace ConsoleChess.BusinessLogic
{
    class GameProcessor
    {
        /// <summary>
        /// Board for the game
        /// </summary>
        public Board MainBoard { get; private set; }

        /// <summary>
        /// Collection of players
        /// </summary>
        private Queue<Player> Players { get; set; }

        /// <summary>
        /// Player that is making the move
        /// </summary>
        private Player CurrentPlayer { get; set; }

        /// <summary>
        /// Last move result
        /// </summary>
        private MoveResult LastMoveResult { get; set; }



        private DrawProcessor DrawProcessor { get; set; }
        private MovementProcessor MovementProcessor { get; set; }



        public GameProcessor()
        {
            DrawProcessor = new DrawProcessor();
            MovementProcessor = new MovementProcessor();
        }


        public void SetPreset(Preset preset)
        {
            try
            {
                MainBoard = new Board(preset.BoardRank);
                DrawProcessor.SetBoard(MainBoard);
                MovementProcessor.SetBoard(MainBoard);
                Players = preset.Players;
                MainBoard.SetPieces(preset.StartingPosition);
                SwapSides();
            }
            catch{
                DrawProcessor.Display("Invalid game preset");
            }

        }

        public void Start()
        {
            if (MainBoard == null || DrawProcessor.MainBoard == null || MovementProcessor.MainBoard == null)
                throw new NullReferenceException();


            while (true)
                Turn();

        }


        private void Turn()
        {
            try
            {
                DrawProcessor.Clear();
                DrawProcessor.DrawBoard();
                DisplayInfo();

                LastMoveResult = LastMoveResult == MoveResult.NeedToConvert 
                    ? MovementProcessor.ConvertPiece(GetMove(), CurrentPlayer)
                    : LastMoveResult = MovementProcessor.ProcessAMove(GetMove(), CurrentPlayer);

                if (LastMoveResult == MoveResult.Success)
                    SwapSides();
            }
            catch (NullReferenceException)
            {

            }
        }


        private string GetMove()
        {
            Console.Write("Your move: ");
            return Console.ReadLine();
        }

        private void DisplayInfo()
        {
            switch (LastMoveResult)
            {
                case MoveResult.Success:
                default:
                    break;
                case MoveResult.NeedToConvert:
                    DrawProcessor.Display($"{CurrentPlayer.Color} pawn is ready to convert.");
                    DrawProcessor.Display($"Please choose piece pawb wiil be converted into: ");
                    DrawProcessor.Display($"Ф - Queen");
                    DrawProcessor.Display($"i - Bishop");
                    DrawProcessor.Display($"2 - Knight");
                    DrawProcessor.Display($"Д - Rook");
                    DrawProcessor.Display($"");
                    break;
                case MoveResult.WrongInputFormat:
                    DrawProcessor.DisplayError("Wrong format");
                    break;
                case MoveResult.WrongBeginningCell:
                    DrawProcessor.DisplayError($"Chosen piece is not yours. Choose {CurrentPlayer.Color} piece");
                    break;
                case MoveResult.EmptyBeginningCell:
                    DrawProcessor.DisplayError("Chosen starting cell is empty");
                    break;
                case MoveResult.WrongDestinationCell:
                    break;
                case MoveResult.OccupiedDestinationCell:
                    DrawProcessor.DisplayError("Chosen target cell is occupied by your piece");
                    break;
                case MoveResult.ImpossibleMove:
                    DrawProcessor.DisplayError("Chosen piece cannot move to the target cell");
                    break;

            }

            DrawProcessor.Display("");
            DrawProcessor.Display("Type in your move in following format - \"A7 A5\",\"B5 E2\",\"G8 F6\"");
            DrawProcessor.Display("");
            DrawProcessor.Display($"Now is {CurrentPlayer.Name}'s turn");

        }


        private void SwapSides()
        {
            if(CurrentPlayer != null)
                Players.Enqueue(CurrentPlayer);
            CurrentPlayer = Players.Dequeue();
        }
    }
}
