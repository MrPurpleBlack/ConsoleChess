using System.Collections.Generic;

namespace ConsoleChess.GameElements.Pieces
{
    public abstract class Piece
    {
        /// <summary>
        /// Piece name
        /// </summary>
        public virtual string Name { get; }

        /// <summary>
        /// Display char
        /// </summary>
        public virtual char Display { get; }

        /// <summary>
        /// Directions of movement
        /// </summary>
        public virtual List<Direction> MoveDirections { get; }

        /// <summary>
        /// Defines if piece can move all the way through the board
        /// </summary>
        public virtual bool IsContinuous => true;

        /// <summary>
        /// Defines if piece can attack again after succesfully attacking another piece
        /// </summary>
        public virtual bool CanKeepAttacking => false;


        /// <summary>
        /// Player
        /// </summary>
        public Player Player { get; private set; }



        public Piece(Player player)
        {
            Player = player;
        }

        public bool IsSameSide(Player player)
        {
            return Player.Color == player.Color;
        }

        public virtual bool IsReadyToConvert(byte y, byte enemiesKingsRow)
        {
            return false;
        }

        public virtual bool CanCheckmate(Piece piece)
        {
            return true;
        }        
    }
}
