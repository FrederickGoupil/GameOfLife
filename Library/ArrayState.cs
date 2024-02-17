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
        private Cell[] cells;
        private int sizeX;
        private int sizeY;
        public int[] Xpositions;
        public int frameNumber;
        /// <summary>
        /// Builds an state filled with empty cells
        /// </summary>
        /// <param name="sizeX">Width</param>
        /// <param name="sizeY">Height</param>
        public ArrayState(int sizeX, int sizeY, int frameNumber)
        {
            if (sizeX <= 0) { throw new ArgumentOutOfRangeException("Size X cannot be 0 or negative"); }
            if (sizeY <= 0) { throw new ArgumentOutOfRangeException("Size Y cannot be 0 or negative"); }
            if (frameNumber <= 0) { throw new ArgumentOutOfRangeException("Number of frames cannot be 0 or negative"); }

            this.frameNumber = frameNumber;
            this.sizeX = sizeX;
            this.sizeY = sizeY;
            Cell[] cells = new Cell[sizeX*sizeY];

            int i = 0;
            for (int y = 0; y < sizeY; y++)
            {
                for (int x = 0; x < sizeX; x++)
                {
                    cells[i] = new Cell(x, y);
                    i++;
                }
            }
            this.cells = cells;

            this.Xpositions = new int[sizeX+1];
            int j = 0;
            for (int ki = 0; ki <= sizeX; ki++)
            {
                this.Xpositions[ki] = j;
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
        public Cell[] GetCells()
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
            for (int y = 0; y < sizeY; y++)
            {
                for (int x = 0; x < sizeX;x++)
                {
                   
                    if (random.Next(density,101) == 100)
                    {
                        cells[(y*sizeX)+x].GiveLife();
                    }
                }
            }
            return 1;
        }
        /// <summary>
        /// Updates the cells in the ArrayState by applying the rules to the previous frame
        /// </summary>
        /// <param name="previousState">Previous frame</param>
        public void UpdateStateFromPrevious(ArrayState previousState)
        {
            Cell[] previousCells = previousState.GetCells();

            // Set Future State
            for (int y = sizeY - 1; y >= 0; y--)
            {
                for (int x =0; x < sizeX; x++)
                {

                    int neighbors = GetCellNeighbors(previousCells,x,y);

                    // Rules

                    // Rule 2 : Survival
                    if (neighbors == 2 && previousCells[(y*sizeX)+x].IsAlive())
                    {
                        cells[(y*sizeX)+x].GiveLife();
                    }
                    // Rule 4 : Birth
                    if (neighbors == 3)
                    {
                        cells[(y*sizeX)+x].GiveLife();
                    }
                    // Rule 1 : Underpopulation
                    if (neighbors < 2)
                    {
                        cells[(y*sizeX)+x].Kill();
                    }
                    // Rule 3 : Overpopulation
                    if (neighbors > 3)
                    {
                        cells[(y*sizeX)+x].Kill();
                    }
                }
            }
        }
        /// <summary>
        /// Check in every 8 direction and returns the number of neighbor found
        /// </summary>
        /// <param name="cells">List of cells to check</param>
        /// <param name="x">X Position of the cell</param>
        /// <param name="y">Y Position of the cell</param>
        /// <returns>Number of neighbors found</returns>
        public int GetCellNeighbors(Cell[] herecells, int x, int y)
        {
            if(x<0 || x>=sizeX) { throw new ArgumentOutOfRangeException("X cannot be outside of the array");}
            if(y<0 || y>=sizeY) { throw new ArgumentOutOfRangeException("Y cannot be outside of the array");}
            if(herecells.Length==0 || herecells==null) { throw new ArgumentException("The array of cell is invalid");}

            int neighbor = 0;
            // up
            if (y < sizeY-1 && herecells[((y+1) * sizeX) + x].IsAlive()){neighbor++;}
            // down
            if (y > 0 && herecells[((y-1) * sizeX) + x].IsAlive()){neighbor++;}
            // left
            if (x > 0 && herecells[(y*sizeX) + (x - 1)].IsAlive()){neighbor++;}
            // right
            if (x < sizeX-1 && herecells[(y*sizeX) + (x + 1)].IsAlive()){neighbor++;}
            // up left
            if (y < sizeY-1 && x > 0 && herecells[((y+1) * sizeX) + (x-1)].IsAlive()){neighbor++;}
            // up right
            if (y < sizeY-1 && x < sizeX-1 && herecells[((y+1) * sizeX) + (x+1)].IsAlive()){neighbor++;}
            // down left
            if (y > 0 && x > 0 && herecells[((y-1) * sizeX) + (x-1)].IsAlive()){neighbor++;}
            // down right
            if (y > 0 && x < sizeX-1 && herecells[((y-1) * sizeX) + (x+1)].IsAlive()){neighbor++;}

            return neighbor;
        }
    }
}
