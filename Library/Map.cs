using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    /// <summary>
    /// Represents a map of x and y size and includes all its squares
    /// </summary>
    public class Map
    {
        private Square[] squares;
        private int sizeX;
        private int sizeY;
        /// <summary>
        /// Builds an empty map with a size given in parameters
        /// </summary>
        /// <param name="sizeX">width of the map</param>
        /// <param name="sizeY">height of the map</param>
        public Map(int sizeX, int sizeY)
        {
            squares = new Square[sizeX*sizeY];
            this.sizeX = sizeX;
            this.sizeY = sizeY;


            int i = 0;
            for (int y = 0; y < sizeY; y++)
            {
                for (int x = 0; x < sizeX; x++)
                {
                    squares[i] = new Square(x, y);
                    i++;
                }
            }
        }
        /// <summary>
        /// Renders the current state of the map on the console
        /// </summary>
        public void RenderMap()
        { 
            StringBuilder sb = new StringBuilder();

            for (int y = sizeY -1 ; y >= 0; y--)
            {
                for (int x = 0;x < sizeX; x++)
                {
                    sb.Append(GetSquare(x, y).GetContent() + " ");
                }
                sb.Append('\n');
            }

            Console.WriteLine(sb.ToString());
            sb.Clear();
        }
        /// <summary>
        /// Places the desired content in the square in the position given in parameters
        /// </summary>
        /// <param name="posX">X position of the square</param>
        /// <param name="posY">Y position of the square</param>
        /// <param name="content">Desired content</param>
        public void PlaceSquare(int posX, int posY, char content)
        {
            GetSquare(posX,posY).SetContent(content);
        }
        /// <summary>
        /// Returns the amount of neighbors a square given in parameters has
        /// </summary>
        /// <param name="square">Square to find neighbors to</param>
        /// <returns>Number of neighbors</returns>
        public int GetNumberOfNeighbors(Square square)
        {
            int count = 0;

            //up
            if (square.GetYPos() != sizeY-1 && squares[((square.GetYPos() + 1)*sizeX)+square.GetXPos()].GetContent() != ' ')
            {
                count++;
            }
            //down
            if (square.GetYPos() != 0 && squares[((square.GetYPos() - 1)*sizeX)+square.GetXPos()].GetContent() != ' ')
            {
                count++;
            }
            //right
            if (square.GetXPos() != sizeX-1 && squares[(square.GetYPos()*sizeX)+square.GetXPos()+1].GetContent() != ' ')
            {
                count++;
            }
            //left
            if (square.GetXPos() != 0 && squares[(square.GetYPos()*sizeX)+square.GetXPos()-1].GetContent() != ' ')
            {
                count++;
            }
            // up left
            if (square.GetYPos() != sizeY-1 && square.GetXPos() != 0 && squares[((square.GetYPos() + 1)*sizeX)+square.GetXPos()-1].GetContent() != ' ')
            {
                count++;
            }
            // up right
            if (square.GetYPos() != sizeY-1 && square.GetXPos() != sizeX-1 && squares[((square.GetYPos() + 1)*sizeX)+square.GetXPos()+1].GetContent() != ' ')
            {
                count++;
            }
            // down left
            if (square.GetYPos() != 0 && square.GetXPos() != 0 && squares[((square.GetYPos() - 1)*sizeX)+square.GetXPos()-1].GetContent() != ' ')
            {
                count++;
            }
            // down right
            if (square.GetYPos() != 0 && square.GetXPos() != sizeX-1 && squares[((square.GetYPos() - 1)*sizeX)+square.GetXPos()+1].GetContent() != ' ')
            {
                count++;
            }

            return count;
        }
        /// <summary>
        /// Returns the Square (full object) at the given position
        /// </summary>
        /// <param name="x">X Position</param>
        /// <param name="y">Y Position</param>
        /// <returns>Square object</returns>
        public Square GetSquare(int x, int y)
        {
            List<Square> squareList = new List<Square>();

            for (int i = 0; i < squares.Length; i++)
            {
                if (squares[i].GetXPos() == x)
                {
                    squareList.Add(squares[i]);
                }
            }
            for (int i = 0; i < squareList.Count; i++)
            {
                if (squareList[i].GetYPos() == y) { return squareList[i]; }
            }


            return null;
        }

        public void UpdateMap()
        {
            for (int i = 0; i < squares.Length; i++)
            {
                // dies of overpopulation or underpopulation
                if (GetNumberOfNeighbors(squares[i]) > 3 || GetNumberOfNeighbors(squares[i]) < 2)
                {
                    squares[i].SetFutureContent(' ');
                }
                // New Square born
                else if (GetNumberOfNeighbors(squares[i]) == 3)
                {
                    squares[i].SetFutureContent('■');
                }
                // stays alive
                else if (squares[i].GetContent() == '■' && GetNumberOfNeighbors(squares[i]) == 2)
                {
                    squares[i].SetFutureContent('■');
                }
            }

            foreach (Square square in squares)
            {
                square.SetContent(square.GetFutureContent());
            }
        }
    }
}
