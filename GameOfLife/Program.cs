using ImageMagick;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace GameOfLife
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int nbFrames = 1000;
            int height = 1000;
            int width = 1000;
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

            Stopwatch update = new Stopwatch();

            for (int frame = 1; frame < nbFrames; frame++)
            {
                update.Restart();
                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        frames[frame,x,y] = UpdateCell(frames,height, width, frame, x, y);
                    }
                }
                Console.SetCursorPosition(0,3);
                Console.WriteLine("Rendering... ETA : " + Math.Round((update.ElapsedMilliseconds*(nbFrames-frame))/1000.0,3));
            }

            Console.WriteLine("Generated in " + Math.Round(sw.ElapsedMilliseconds / 1000.0, 3) + "s");

            // Render frame
            sw.Restart();

            Console.WriteLine("Deleting old files");
            string[] pngFiles = System.IO.Directory.GetFiles("C:/Users/krow/Documents/GitHub/GameOfLife/GameOfLife/bin/Debug/net8.0", "*.png");
            foreach (string pngFile in pngFiles)
            {
                File.Delete(pngFile);
            }

            Console.WriteLine("Rendering new files");

            Task threading = Task.Run(() => Render(frames,height,width,nbFrames));

            threading.Wait();

            Console.Write("Rendered in " + Math.Round((sw.ElapsedMilliseconds/1000.0),3) + "s");

            return;

        }

        static async void Render(bool[,,] frames, int height,int width,int nbFrames)
        {
            Task t1 = Task.Run(() => RenderFrame(frames,height,width,0,nbFrames/8,true));
            Task t2 = Task.Run(() => RenderFrame(frames,height,width,nbFrames/8,(nbFrames/8)*2,false));
            Task t3 = Task.Run(() => RenderFrame(frames,height,width,(nbFrames/8)*2,(nbFrames/8)*3,false));
            Task t4 = Task.Run(() => RenderFrame(frames,height,width,(nbFrames/8)*3,(nbFrames/8)*4,false));
            Task t5 = Task.Run(() => RenderFrame(frames,height,width,(nbFrames/8)*4,(nbFrames/8)*5,false));
            Task t6 = Task.Run(() => RenderFrame(frames,height,width,(nbFrames/8)*5,(nbFrames/8)*6,false));
            Task t7 = Task.Run(() => RenderFrame(frames,height,width,(nbFrames/8)*6,(nbFrames/8)*7,false));
            Task t8 = Task.Run(() => RenderFrame(frames,height,width,(nbFrames/8)*7,nbFrames,false));

            t1.Wait();
            t2.Wait();
            t3.Wait();
            t4.Wait();
            t5.Wait();
            t6.Wait();
            t7.Wait();
            t8.Wait();

            return;
        }
        
        static async void RenderFrame(bool[,,] frames,int height,int width,int start, int end,bool timed)
        {
            Stopwatch sw = Stopwatch.StartNew();
            

            for (int frame = start;  frame < end; frame++)
            {
                Bitmap image = new Bitmap(width*10, height*10);
                sw.Restart();
                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < height;y++)
                    {
                        Color color = frames[frame, x, y] ? color = Color.White : color = Color.Black;
                        using (Graphics g = Graphics.FromImage(image))
                        {

                            using (Brush b = new SolidBrush(color))
                            {
                                g.FillRectangle(b,x*10,y*10,10,10);
                            }
                        }
                    }
                }
                if (timed)
                {
                    Console.SetCursorPosition(0,7);
                    Console.WriteLine("Rendering... ETA : " + Math.Round((sw.ElapsedMilliseconds*(end-frame))/1000.0,3));
                }
                image.Save("output" + frame + ".png", System.Drawing.Imaging.ImageFormat.Png);
            }
            sw.Stop();
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
            if (y < height-1 && x < width-1 && frames[frame, x+1, y+1]) { neighbors++;}
            return neighbors;
        }
    }
}
