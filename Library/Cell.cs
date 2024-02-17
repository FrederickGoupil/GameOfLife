using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Cell
    {
        private bool isAlive;
        private int posX;
        private int posY;
        private bool isAliveNext;

        public Cell(int posX, int posY)
        {
            this.isAlive = false;
            this.posX = posX;
            this.posY = posY;
            this.isAliveNext = false;
        }

        public void GiveLife()
        {
            this.isAlive = true;
        }
        public void GiveLifeNext()
        {
            this.isAliveNext = true;
        }
        public void Kill()
        {
            this.isAlive = false;
        }
        public void KillNext()
        {
            this.isAliveNext = false;
        }

        public int[] GetPosition()
        {
            return [posX,posY];
        }

        public bool IsAlive()
        {
            return isAlive;
        }
        public bool IsAliveNext()
        {
            return isAliveNext;
        }
    }
}
