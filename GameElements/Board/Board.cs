using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleChess.Game_elements.Board
{
    class Board
    {
        public IList<Cell> Cells { get; set; }

        public Board(byte grid)
        {
            for (var i = 0; i < grid * grid; i++)
                Cells.Add(new Cell((byte)(i % grid), (byte)(i / grid)));
        }
    }
}
