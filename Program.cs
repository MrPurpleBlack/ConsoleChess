using ConsoleChess.BusinessLogic;
using ConsoleChess.GameElements.Board;
using ConsoleChess.GameElements.Presets;
using System;

namespace ConsoleChess
{
    class Program
    {
        static void Main(string[] args)
        {
            var proc = new GameProcessor();
            proc.SetPreset(new ClassicChessPreset());
            proc.Start();        
        }
    }
}
