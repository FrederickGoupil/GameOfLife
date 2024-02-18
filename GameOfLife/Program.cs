using System.Diagnostics;
using System.Drawing;

namespace GameOfLife
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int nbFrames = 100;
            int height = 100;
            int width = 100;
            int density = 97;

            Run(nbFrames, height, width, density);
        }

        static async void Run(int nbFrames,int height,int width, int density)
        {
            bool[,,] frames = new bool[nbFrames, height, width];
            Stopwatch sw = new Stopwatch();

            // Generate first frame
            sw.Restart();
            Console.WriteLine("Generating first frame");

            Random rnd = new Random();

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (rnd.Next(density, 101) == 100)
                    {
                        frames[0, x, y] = true;
                    }
                }
            }

            Console.WriteLine("Generated in " + Math.Round(sw.ElapsedMilliseconds / 1000.0, 3) + "s");

            // update every frame

            sw.Restart();

            Console.WriteLine("Updating the rest of the frames");

            for (int frame = 1; frame < nbFrames; frame++)
            {
                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        frames[frame,x,y] = UpdateCell(frames,height, width, frame, x, y);
                    }
                }
            }

            Console.WriteLine("Generated in " + Math.Round(sw.ElapsedMilliseconds / 1000.0, 3) + "s");

            // Render frame

            for (int frame = 0;  frame < nbFrames; frame++)
            {
                Bitmap image = new Bitmap(width*100, height*100);

                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < height;y++)
                    {
                        Color color = frames[frame, x, y] ? color = Color.White : color = Color.Black;
                        using (Graphics g = Graphics.FromImage(image))
                        {

                            using (Brush b = new SolidBrush(color))
                            {
                                g.FillRectangle(b,x*100,y*100,100,100);
                            }
                        }
                    }
                }

                image.Save("output" + frame + ".png", System.Drawing.Imaging.ImageFormat.Png);
            }
        }

        static bool UpdateCell(bool[,,] frames, int height,int width, int frame, int x, int y)
        {
            bool result = false;

            int neighbors = GetNeighbors(frames,height,width, frame-1, x, y);

            
            if (frames[frame-1,x,y] && neighbors == 2)
            {
                result = true;
            }
            else if (neighbors == 3)
            {
                result = true;
            }
            return result;
        }

        static int GetNeighbors(bool[,,] frames, int height, int width, int frame, int x, int y)
        {
            int neighbors = 0;
            //up 
            if (y < height-1 && frames[frame, x, y + 1]) { neighbors++; }
            //up left
            if (y < height-1 && x > 0 && frames[frame,x-1,y+1]) { neighbors++;}
            //left
            if (x > 0 && frames[frame, x - 1, y]) { neighbors++; }
            //down left
            if (y > 0 && x > 0 && frames[frame,x-1,y-1]) { neighbors++; }
            //down
            if (y > 0 && frames[frame,x,y-1]) { neighbors++; }
            //down right
            if (y > 0 && x < width-1 && frames[frame, x + 1, y - 1]) { neighbors++; }
            //right
            if (x < width-1 && frames[frame, x + 1, y]) { neighbors++; }
            //up right
            if (y < height-1 && x < width-1 && frames[frame, y+1, y+1]) { neighbors++;}
            return neighbors;
        }
    }
}
