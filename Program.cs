using ConsoleChess.BusinessLogic;
using ConsoleChess.GameElements.Board;
using System;

namespace ConsoleChess
{
    class Program
    {
        static void Main(string[] args)
        {
            var proc = new GameProcessor();
            proc.Start();        
        }
    }
}
