using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    /// <summary>
    /// Represents a single frame of the game with its content and its size
    /// </summary>
    public class ArrayState
    {
        private List<Cell> cells;
        private int sizeX;
        private int sizeY;
        public int[] Xpositions;
        /// <summary>
        /// Builds an state filled with empty cells
        /// </summary>
        /// <param name="sizeX">Width</param>
        /// <param name="sizeY">Height</param>
        public ArrayState(int sizeX, int sizeY)
        {
            this.sizeX = sizeX;
            this.sizeY = sizeY;
            this.cells = new List<Cell>();

            this.Xpositions = new int[sizeX+1];
            int j = 0;
            for (int i = 0; i <= sizeX; i++)
            {
                this.Xpositions[i] = j;
                j += 2;
            }
        }
        /// <summary>
        /// Returns size of ArrayState in an array
        /// </summary>
        /// <returns>response[0] : Width  \  response[1] : Height</returns>
        public int[] GetSize()
        {
            return [sizeX,sizeY];
        }
        /// <summary>
        /// Returns the cells inside the array
        /// </summary>
        /// <returns>List of cell</returns>
        public List<Cell> GetCells()
        {
            return cells;
        }
        /// <summary>
        /// Fills the ArrayState with random cells with a given density
        /// </summary>
        /// <remarks></remarks>
        /// <param name="density">Density of the generation 0-100</param>
        /// <exception cref="ArgumentOutOfRangeException">Density is out of range</exception>
        /// <exception cref="NullReferenceException">Array State is null</exception>
        /// <returns>1 on success / 0 on error</returns>
        public int GenerateRandomState(int density)
        {
            if (density <= 0 || density > 100) { throw new ArgumentOutOfRangeException("Density needs to be between 0 and 100. Current : " + density);}

            Random random = new Random();

            for (int y = sizeY; y >= 0; y--)
            {
                for (int x = 0; x < sizeX;x++)
                {
                    Cell newCell = new Cell(x,y);
                    if (random.Next(density,101) == 100)
                    {
                        newCell.GiveLife();

                    }
                    cells.Add(newCell);
                }
            }

            return 1;
        }
    }
}
