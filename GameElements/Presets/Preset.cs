using ConsoleChess.GameElements.Pieces;
using System;
using System.Collections.Generic;

namespace ConsoleChess.GameElements.Presets
{
    abstract class Preset
    {
        /// <summary>
        /// Rank of game board
        /// </summary>
        public byte BoardRank { get; set; }

        /// <summary>
        /// Collection of players
        /// </summary>
        public Queue<Player> Players { get; set; }

        /// <summary>
        /// Staring position of pieces
        /// </summary>
        public Piece[] StartingPosition { get; set; }

        public Preset()
        {

        }

        public Preset(byte rank, Queue<Player> players, Piece[] startingPosition)
        {
            if (rank == 0 || startingPosition.Length != rank*rank)
                throw new IndexOutOfRangeException();

            BoardRank = rank;
            Players = players;
            StartingPosition = startingPosition;
        }
    }
}
