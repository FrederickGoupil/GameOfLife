using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class ThreadWithState
    {
        private Square[] squares;
        private int start;
        private int end;
        private int lineWidth;
        private TWSCallback callback; 

        public ThreadWithState(Square[] squares, int start, int end, int lineWidth, TWSCallback callback, int currentFrame, string[] frames)
        {
            this.squares = squares;
            this.start = start;
            this.end = end;
            this.lineWidth = lineWidth;
            this.callback = callback;
        }

        public void RenderThread()
        {
            StringBuilder sb = new StringBuilder();

            for (int y = end - 1; y >= start; y--)
            {

                for (int x = 0; x < lineWidth; x++)
                {
                    sb.Append(GetSquare(x, y).GetContent() + " ");
                }
                sb.Append('\n');
                Console.WriteLine("Frame done");
            }

            callback(sb.ToString());
        }

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
    }

    public delegate string TWSCallback(string render);
}
