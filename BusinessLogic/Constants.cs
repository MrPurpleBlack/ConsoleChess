using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ConsoleChess.BusinessLogic
{
    public static class Constants
    {
        public static byte CellWidth = 7;
        public static byte CellHeight = 3;

        public static ConsoleColor Black => ConsoleColor.Black;
        public static ConsoleColor White => ConsoleColor.White;

        public static ConsoleColor Error => ConsoleColor.Red;
    }

    public enum MoveResult
    {
        Success,
        NeedToConvert,
        WrongInputFormat,
        WrongInputConvertFormat,
        WrongBeginningCell,
        EmptyBeginningCell,
        WrongDestinationCell,
        OccupiedDestinationCell,
        ImpossibleMove
    }
}
