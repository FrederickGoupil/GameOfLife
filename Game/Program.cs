using Library;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Game
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Conwey's Game of life

            // config

            int sizeX = 300;        // Width
            int sizeY = 125;        // Height
            int nbFrames = 200;      // Number of frames to generate
            int density = 90;       // Chance for cells to be alive on generation

            /*
            Single Thread : 74.860s

            2 Threads     : 3.935s
		            3.819s
		            3.803s
		            3.850s
		

            4 threads     : 5.823s
		            5.784s
		            5.946s
		            5.745s

            8 threads     : 4.498s
		            4.343s
		            4.338s
		            4.341s
		
            */

            // Generate

            Console.Clear();

            Console.SetWindowSize((sizeX*2)+1, sizeY+1);
            List<ArrayState> states = new List<ArrayState>(nbFrames);
            
            Stopwatch sw = Stopwatch.StartNew();
            sw.Start();

            states.Add(new ArrayState(sizeX, sizeY,0));
            try
            {
                states[0].GenerateRandomState(density);
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine(ex.Message + "\nPress any key to exit...");
                Console.ReadKey();
                return;
            }

            for (int i  = 1; i < states.Capacity; i++)
            {
                states.Add(new ArrayState(sizeX,sizeY,i));
                states[i].UpdateStateFromPrevious(states[i-1]);
            }

           
            // create strings

            Task<string[]> task = Task.Run(() => RenderFrames(states,sizeX,sizeY,2));

            task.Wait();

            string[] frames = task.Result;

            // Print Results
        
            int frame = 0;

            Console.WriteLine("Time to render : " + (Math.Round((sw.ElapsedMilliseconds/1000.0),3)) + "s");
            Console.ReadKey();
            while (true)
            {
                Console.Clear();
                Console.WriteLine(frames[frame]);

                ConsoleKeyInfo key = Console.ReadKey();

                if (key.Key == ConsoleKey.LeftArrow)
                {
                    if (frame  == 0)
                    {
                        frame = nbFrames-1;
                    }
                    else
                    {
                        frame--;
                    }
                }
                else if (key.Key == ConsoleKey.RightArrow)
                {
                    if (frame  == nbFrames-1)
                    {
                        frame = 0;
                    } 
                    else
                    {
                        frame++;
                    }
                }
            }
        }
        
        static async Task<string[]> RenderFramePart(List<ArrayState> states, int start, int end, int sizeX, int sizeY)
        {
            Console.WriteLine("Thread Started Rendering");

            string[] response = new string[states.Count];

            for (int i = 0; i < states.Count ; i++)
            {
                string framePart = "";
                for (int y = start; y >= end; y--)
                {
                    for (int x = 0; x < sizeX; x++)
                    {
                        if (states[i].GetCells()[(y*sizeX)+x].IsAlive()) { framePart += "■ ";} else { framePart += "  ";}
                        
                    }
                    framePart += "\n";
                }
                response[i] = framePart;
            }
            return response;
        }
        static async Task<string[]> RenderFrames(List<ArrayState> states, int sizeX, int sizeY, int nbThread)
        {
            
            Console.WriteLine("Threads are Initialized");
            string[] frames = new string[states.Count];
            
            if (nbThread == 8)
            {
                Task<string[]> t1 = Task.Run(() => RenderFramePart(states,sizeY-1,(sizeY/8)*7,sizeX,sizeY));
                Task<string[]> t2 = Task.Run(() => RenderFramePart(states,(sizeY/8)*7-1,(sizeY/8)*6,sizeX,sizeY));
                Task<string[]> t3 = Task.Run(() => RenderFramePart(states,(sizeY/8)*6-1,(sizeY/8)*5,sizeX,sizeY));
                Task<string[]> t4 = Task.Run(() => RenderFramePart(states,(sizeY/8)*5-1,(sizeY/8)*4,sizeX,sizeY));
                Task<string[]> t5 = Task.Run(() => RenderFramePart(states,(sizeY/8)*4-1,(sizeY/8)*3,sizeX,sizeY));
                Task<string[]> t6 = Task.Run(() => RenderFramePart(states,(sizeY/8)*3-1,(sizeY/8)*2,sizeX,sizeY));
                Task<string[]> t7 = Task.Run(() => RenderFramePart(states,(sizeY/8)*2-1,(sizeY/8),sizeX,sizeY));
                Task<string[]> t8 = Task.Run(() => RenderFramePart(states,(sizeY/8)-1,0,sizeX,sizeY));

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
                Task<string[]> t1 = Task.Run(() => RenderFramePart(states,sizeY-1,(sizeY/4)*3,sizeX,sizeY));
                Task<string[]> t2 = Task.Run(() => RenderFramePart(states,(sizeY/4)*3-1,(sizeY/4)*2,sizeX,sizeY));
                Task<string[]> t3 = Task.Run(() => RenderFramePart(states,(sizeY/4)*2-1,(sizeY/4),sizeX,sizeY));
                Task<string[]> t4 = Task.Run(() => RenderFramePart(states,(sizeY/4)-1,0,sizeX,sizeY));

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
                Task<string[]> t1 = Task.Run(() => RenderFramePart(states,sizeY-1,(sizeY/4)*3,sizeX,sizeY));
                Task<string[]> t2 = Task.Run(() => RenderFramePart(states,(sizeY/4)*3-1,(sizeY/4)*2,sizeX,sizeY));

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
                Task<string[]> task = Task.Run(() => RenderFramePart(states,sizeY-1,0,sizeX,sizeY));

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
        
    }
}
