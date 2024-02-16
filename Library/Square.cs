using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    /// <summary>
    /// Represents a square with its position on the board and its content
    /// </summary>
    public class Square
    {
        private int posX;
        private int posY;
        private char content;
        private char future;
        /// <summary>
        /// Builds an empty square with a position
        /// </summary>
        /// <param name="posX"></param>
        /// <param name="posY"></param>
        public Square(int posX, int posY)
        {
            this.posX = posX;
            this.posY = posY;
            this.content = ' ';
            this.future = ' ';
        }
        /// <summary>
        /// Gets the current content of the square
        /// </summary>
        /// <returns>char : Contents of the square</returns>
        public char GetContent()
        {
            return this.content;
        }
        /// <summary>
        /// Used to set the content to a desired char
        /// </summary>
        /// <param name="content">char : Desired content</param>
        public void SetContent(char content)
        {
            this.content = content;
        }
        /// <summary>
        /// Returns X position of the square
        /// </summary>
        /// <returns>Position of the square in X</returns>
        public int GetXPos()
        {
            return posX;
        }
        /// <summary>
        /// Returns Y position of the square
        /// </summary>
        /// <returns>Position of the square in Y</returns>
        public int GetYPos()
        {
            return posY;
        }
        /// <summary>
        /// Sets the future state of the square to the desired content
        /// </summary>
        /// <param name="future">Desired state after update</param>
        public void SetFutureContent(char future)
        {
            this.future = future;
        }
        /// <summary>
        /// Returns the Future content for update
        /// </summary>
        /// <returns>future content</returns>
        public char GetFutureContent()
        {
            return this.future;
        }
    }
}
