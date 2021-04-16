using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleChess.GameElements.Pieces
{
    public class Direction
    {
        /// <summary>
        /// Direction by coordinate X
        /// </summary>
        public int X { get; private set; }

        /// <summary>
        /// Direction by coordinate Y
        /// </summary>
        public int Y { get; private set; }

        /// <summary>
        /// Defines whether Piece can move in this direction only with attack
        /// </summary>
        public bool OnlyWithAttack { get; private set; }

        /// <summary>
        /// Movement possible only as first one
        /// </summary>
        public bool FirstMove { get; private set; }


        public Direction(int x, int y, bool onlyWithAttack = false, bool firstMove = false)
        {
            X = x;
            Y = y;

            OnlyWithAttack = onlyWithAttack;
            FirstMove = firstMove;
        }
    }
}
