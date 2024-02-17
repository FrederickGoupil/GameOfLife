using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    /// <summary>
    /// Represents a single cell with its position and current state
    /// </summary>
    public class Cell
    {
        private bool isAlive;
        private int posX;
        private int posY;
        private bool isAliveNext;
        /// <summary>
        /// Builds a dead cell in a given position
        /// </summary>
        /// <param name="posX">X position of the cell</param>
        /// <param name="posY">Y position of the cell</param>
        /// <exception cref="ArgumentOutOfRangeException">X is below 0</exception>
        /// <exception cref="ArgumentOutOfRangeException">Y is below 0</exception>
        public Cell(int posX, int posY)
        {
            if (posX < 0) { throw new ArgumentOutOfRangeException("X position cannot be negative"); }
            if (posY < 0) { throw new ArgumentOutOfRangeException("Y position cannot be negative"); }

            this.isAlive = false;
            this.posX = posX;
            this.posY = posY;
            this.isAliveNext = false;
        }
        /// <summary>
        /// Set cell to alive
        /// </summary>
        public void GiveLife()
        {
            this.isAlive = true;
        }
        /// <summary>
        /// Set cell to dead
        /// </summary>
        public void Kill()
        {
            this.isAlive = false;
        }
        /// <summary>
        /// Returns if alive or not
        /// </summary>
        /// <returns>True = Alive \ False = Dead</returns>
        public bool IsAlive()
        {
            return isAlive;
        }

    }
}
