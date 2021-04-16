using ConsoleChess.GameElements.Pieces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleChess.GameElements
{
    public class Player
    {
        /// <summary>
        /// Player's name
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Player's color
        /// </summary>
        public ConsoleColor Color { get; private set; }

        /// <summary>
        ///  Default Piece movement direction
        /// </summary>
        public Direction DefaultPieceDirection { get; private set; }

        /// <summary>
        ///  Index of the furthest row from the start, where some pieces are meant to convert into another piece
        /// </summary>
        public byte KingsRow { get; private set; }
        public byte EnemiesKingsRow { get; private set; }



        public Player(string name, ConsoleColor color, byte kingsRow, byte enemiesKingsRow, Direction defaultDirection = null)
        {
            Name = name;
            Color = color;
            KingsRow = kingsRow;
            EnemiesKingsRow = enemiesKingsRow;
            DefaultPieceDirection = defaultDirection?? new Direction(0,0);
        }
    }
}
