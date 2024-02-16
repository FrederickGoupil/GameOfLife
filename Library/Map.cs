using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
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
            if (sizeX <= 0){ throw new ArgumentException("Invalid Size for X");}
            if (sizeY <= 0) { throw new ArgumentException("Invalid Size for Y"); }


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
        public async void MTRenderMap(int nbframe)
        {
            throw new NotImplementedException("Multi Threading is WIP");
        }
        public void STRenderMap(int nbframe)
        {
            string[] frames = new string[nbframe];
            double[] updateTimes = new double[nbframe];

            Stopwatch sw = Stopwatch.StartNew();
            StringBuilder sb = new StringBuilder();

            Console.WriteLine("Rendering...");

            for (int i = 0; i < frames.Length; i++)
            {
                sw.Restart();

                for (int y = sizeY / 2; y >= 0; y--)
                {

                    for (int x = 0; x < sizeX; x++)
                    {
                        sb.Append(GetSquare(x, y).GetContent() + " ");
                    }
                    sb.Append('\n');
                }

                double time = sw.ElapsedMilliseconds;
                double timeLeft = sw.ElapsedMilliseconds * (frames.Length-i);

                frames[i] = sb.ToString();
                sb.Clear();
                Console.Clear();
                Console.WriteLine("Rendering ETA : " + Math.Round((timeLeft/60),2) + "s");
                UpdateMap();
            }

            Console.Clear() ;
            Console.WriteLine("Rendering complete");

            while (true)
            {
                Console.ReadLine();
                for (int i = 0; i < frames.Length; ++i)
                {
                    Console.Clear();
                    Console.WriteLine(frames[i]);
                    Thread.Sleep(100);
                }
            }
        }
        /// <summary>
        /// Places the desired content in the square in the position given in parameters
        /// </summary>
        /// <param name="posX">X position of the square</param>
        /// <param name="posY">Y position of the square</param>
        /// <param name="content">Desired content</param>
        public void PlaceSquare(int posX, int posY, char content)
        {
            if (posX < 0 || posX >= sizeX) { throw new ArgumentOutOfRangeException("X is out of bounds"); }
            if (posY < 0 || posY >= sizeY) { throw new ArgumentOutOfRangeException("Y is out of bounds"); }

            GetSquare(posX,posY).SetContent(content);
        }
        /// <summary>
        /// Returns the amount of neighbors a square given in parameters has
        /// </summary>
        /// <param name="square">Square to find neighbors to</param>
        /// <returns>Number of neighbors</returns>
        public int GetNumberOfNeighbors(Square square)
        {
            if (square == null) { throw new ArgumentNullException("Square is Null"); }

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
            if (x < 0 || x >= sizeX) { throw new ArgumentOutOfRangeException("X is out of bounds"); }
            if (y < 0 || y >= sizeY) { throw new ArgumentOutOfRangeException("Y is out of bounds"); }

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
        /// <summary>
        /// Makes every square update itself based on its neighbors
        /// </summary>
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
        /// <summary>
        /// Generates a map with random disposition based on density given in parameters
        /// </summary>
        /// <param name="density">Density of the map, Higher is less dense</param>
        public void GenerateMap(int density)
        {
            Random random = new Random();

            foreach (Square square in squares)
            {
                int num = random.Next(1,density);

                if (num == 1)
                {
                    square.SetContent('■');
                }
            }
        }

    }
}
