using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ConsoleChess.BusinessLogic
{
    public static class Constants
    {
        public static byte BoardRank => 8;
        public static byte CellSize = 7;
        public static byte CellHeight = 3;

        public static ConsoleColor Black => ConsoleColor.Black;
        public static ConsoleColor White => ConsoleColor.White;

        public static ConsoleColor Error => ConsoleColor.Red;

        public static ConsoleColor[] Sides => new ConsoleColor[2] { Black, White };


    }

    public enum ErrorCode
    {
        WrongInputFormat,
        WrongBeginningCell,
        EmptyBeginningCell,
        WrongDestinationCell,
        OccupiedDestinationCell,
        ImpossibleMove
    }
}
