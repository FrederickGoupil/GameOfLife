using Library;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using static System.Net.Mime.MediaTypeNames;

namespace Game
{
    internal class Program
    {
        static void Main(string[] args)
        {

            
            // Conwey's Game of life

            // config
            
            int sizeX = 1000;       // Width
            int sizeY = 1000;       // Height
            int nbFrames = 200;     // Number of frames to generate
            int density = 99;       // Chance for cells to be alive on generation
            int nbThreads = 8;      // 

            // Generate
            
            Console.Clear();

            Console.SetWindowSize((sizeX*2)+1, sizeY+1);
            List<ArrayState> states = new List<ArrayState>(nbFrames);
            
            Stopwatch sw = Stopwatch.StartNew();
            sw.Start();

            states.Add(new ArrayState(sizeX, sizeY,nbFrames));
         
            states[0].GenerateRandomState(density);
           
            for (int i  = 1; i < states.Capacity; i++)
            {
                states.Add(new ArrayState(sizeX,sizeY,i));
                states[i].UpdateStateFromPrevious(states[i-1]);
            }

            // create strings

            Task<string[]> task = Task.Run(() => RenderFrames(states,sizeX,sizeY,nbThreads));

            task.Wait();

            string[] frames = task.Result;

            // Print Results
       

            Console.WriteLine("Time to render : " + (Math.Round((sw.ElapsedMilliseconds/1000.0),3)) + "s       ");
            for (int frame = 0; frame < nbFrames; frame++)
            {
                bool[] booleanArray = new bool[(sizeX*sizeY)+1];
                
                int i = 0;
                for (int y = sizeY-1; y >= 0; y--)
                {
                    for (int x = 0; x < sizeX; x++)
                    {
                        if ((frames[frame])[(y*sizeX)+x] == '■')
                        {
                            booleanArray[i] = true;
                        }
                        i++;
                        
                    }
                }


                // Create black and white image from boolean array
                Bitmap image = RenderImage(booleanArray, sizeX,sizeY);
        
                // Save the image
                image.Save("output"+ frame + ".png", System.Drawing.Imaging.ImageFormat.Png);

            }
            return;
        }
        /// <summary>
        /// Renders the given part of every frames and returns the result
        /// </summary>
        /// <param name="states">Generated Frames</param>
        /// <param name="start">Top of the part int Y</param>
        /// <param name="end">Bottom of the part in Y</param>
        /// <param name="sizeX">Width of the frame</param>
        /// <param name="sizeY">Height of the frame</param>
        /// <param name="timed">If the thread will print its expected render time</param>
        /// <returns>List of all the given part of the frames</returns>
        static async Task<string[]> RenderFramePart(List<ArrayState> states, int start, int end, int sizeX, int sizeY, bool timed)
        {
            Console.WriteLine("Thread " + Thread.CurrentThread.ManagedThreadId + " Started Rendering");
            Stopwatch sw = Stopwatch.StartNew();
            
            string[] response = new string[states.Count];

            for (int i = 0; i < states.Count ; i++)
            {
                sw.Restart();
                string framePart = "";
                for (int y = start; y >= end; y--)
                {
                    for (int x = 0; x < sizeX; x++)
                    {
                        if (states[i].GetCells()[(y*sizeX)+x].IsAlive()) { framePart += "■";} else { framePart += " ";}
                    }
                    
                }
                if (timed)
                {
                    Console.SetCursorPosition(0,9);
                    Console.WriteLine("Rendering... ETA : " + Math.Round(((sw.ElapsedMilliseconds/1000.0)*(states.Count-i)),3) + "s      ");

                }
                response[i] = framePart;
            }
            return response;
        }

        /// <summary>
        /// Main Rendering thread used to seperate the load
        /// </summary>
        /// <param name="states">Generated frames to render</param>
        /// <param name="sizeX">X size of the frames</param>
        /// <param name="sizeY">Y size of the frames</param>
        /// <param name="nbThread">Number of threads to work on rendering</param>
        /// <returns>Returns the resulting frames</returns>
        static async Task<string[]> RenderFrames(List<ArrayState> states, int sizeX, int sizeY, int nbThread)
        {
            Console.WriteLine("Threads are Initialized");
            string[] frames = new string[states.Count];
            if (nbThread == 8)
            {
                Task<string[]> t1 = Task.Run(() => RenderFramePart(states,sizeY-1,(sizeY/8)*7,sizeX,sizeY,true));
                Task<string[]> t2 = Task.Run(() => RenderFramePart(states,(sizeY/8)*7-1,(sizeY/8)*6,sizeX,sizeY,false));
                Task<string[]> t3 = Task.Run(() => RenderFramePart(states,(sizeY/8)*6-1,(sizeY/8)*5,sizeX,sizeY, false));
                Task<string[]> t4 = Task.Run(() => RenderFramePart(states,(sizeY/8)*5-1,(sizeY/8)*4,sizeX,sizeY, false));
                Task<string[]> t5 = Task.Run(() => RenderFramePart(states,(sizeY/8)*4-1,(sizeY/8)*3,sizeX,sizeY , false));
                Task<string[]> t6 = Task.Run(() => RenderFramePart(states,(sizeY/8)*3-1,(sizeY/8)*2,sizeX,sizeY, false));
                Task<string[]> t7 = Task.Run(() => RenderFramePart(states,(sizeY/8)*2-1,(sizeY/8),sizeX,sizeY,false));
                Task<string[]> t8 = Task.Run(() => RenderFramePart(states,(sizeY/8)-1,0,sizeX,sizeY,false));
                

                

                string[] string1 = new string[states.Count];
                string[] string2 = new string[states.Count];
                string[] string3 = new string[states.Count];
                string[] string4 = new string[states.Count];
                string[] string5 = new string[states.Count];
                string[] string6 = new string[states.Count];
                string[] string7 = new string[states.Count];
                string[] string8 = new string[states.Count];

                t1.Wait();
                t2.Wait();
                t3.Wait();
                t4.Wait();
                t5.Wait();
                t6.Wait();
                t7.Wait();
                t8.Wait();
                

                for (int s = 0; s < states.Count; s++)
                {
                    string1[s] = t1.Result[s];
                    string2[s] = t2.Result[s];
                    string3[s] = t3.Result[s];
                    string4[s] = t4.Result[s];
                    string5[s] = t5.Result[s];
                    string6[s] = t6.Result[s];
                    string7[s] = t7.Result[s];
                    string8[s] = t8.Result[s];
                }


                for (int i = 0; i < states.Count; i++)
                {
                    frames[i] = string1[i] + string2[i] + string3[i] + string4[i] + string5[i] + string6[i] + string7[i] + string8[i];
                }
            }
            else if (nbThread == 4)
            {
                Task<string[]> t1 = Task.Run(() => RenderFramePart(states,sizeY-1,(sizeY/4)*3,sizeX,sizeY,true));
                Task<string[]> t2 = Task.Run(() => RenderFramePart(states,(sizeY/4)*3-1,(sizeY/4)*2,sizeX,sizeY, false));
                Task<string[]> t3 = Task.Run(() => RenderFramePart(states,(sizeY/4)*2-1,(sizeY/4),sizeX,sizeY, false));
                Task<string[]> t4 = Task.Run(() => RenderFramePart(states,(sizeY/4)-1,0,sizeX,sizeY, false));

                string[] string1 = new string[states.Count];
                string[] string2 = new string[states.Count];
                string[] string3 = new string[states.Count];
                string[] string4 = new string[states.Count];

                t1.Wait();
                t2.Wait();
                t3.Wait();
                t4.Wait();

                for (int s = 0; s < states.Count; s++)
                {
                    string1[s] = t1.Result[s];
                    string2[s] = t2.Result[s];
                    string3[s] = t3.Result[s];
                    string4[s] = t4.Result[s];
                }

                for (int i = 0; i < states.Count; i++)
                {
                    frames[i] = string1[i] + string2[i] + string3[i] + string4[i];
                }
            }
            else if (nbThread == 2) 
            {
                Task<string[]> t1 = Task.Run(() => RenderFramePart(states,sizeY-1,(sizeY/2),sizeX,sizeY, true));
                Task<string[]> t2 = Task.Run(() => RenderFramePart(states,(sizeY/2)-1,0,sizeX,sizeY, false));

                string[] string1 = new string[states.Count];
                string[] string2 = new string[states.Count];

                t1.Wait();
                t2.Wait();

                for (int s = 0; s < states.Count; s++)
                {
                    string1[s] = t1.Result[s];
                    string2[s] = t2.Result[s];
                }

                for (int i = 0; i < states.Count; i++)
                {
                    frames[i] = string1[i] + string2[i];
                }
            }
            else if (nbThread == 1)
            {
                Task<string[]> task = Task.Run(() => RenderFramePart(states,sizeY-1,0,sizeX,sizeY,true));

                task.Wait();

                string[] string1 = new string[states.Count];
                string1 = task.Result;

                for (int i = 0;i < states.Count ; i++)
                {
                    frames[i] = string1[i];
                }
            }
            Console.WriteLine("Threads are done");
            return frames;
        }
        
        static Bitmap RenderImage(bool[] bools,int width, int height)
        {
            Color blackColor = Color.Black;
            Color whiteColor = Color.White;

            Bitmap bitmap = new Bitmap(width, height);

            for (int y = height-1; y >= 0; y--)
            {
                for (int x = 0; x < width; x++)
                {
                    Color color = bools[(y*width)+x] ? whiteColor : blackColor;

                    using (Graphics g = Graphics.FromImage(bitmap))
                    {
                        using (Pen b = new Pen(color))
                        {
                            g.DrawRectangle(b,x+1,y+1,1,1);
                        }
                    }
                }
            }
            return bitmap;
        }
    }
}
