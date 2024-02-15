using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Map
    {
        private int sizeX;
        private int sizeY;
        private Square[] squares;

        public Map(int sizeX, int sizeY)
        {
            this.sizeX = sizeX;
            this.sizeY = sizeY;

            this.squares = new Square[sizeX * sizeY];

            for (int x = 0; x < sizeX; x++)
            {
                for (int y = 0; y < sizeY; y++)
                {
                    squares[i] = new Square(x, y, '#');
                }
            }
        }
        public void RenderMap()
        {
            Console.Clear();

            for (int y = 0; y < sizeY;y++)
            {
                for(int x = 0;x < sizeX;x++)
                {
                    Console.Write("#");
                }
                Console.WriteLine();
            }
        }   
    }
}
