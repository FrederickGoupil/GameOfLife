using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Square
    {
        private char content;
        private int positionX;
        private int positionY;

        public Square(int  positionX, int positionY, char content)
        {
            this.positionX = positionX;
            this.positionY = positionY;
            this.content = content;
        }
    }
}
