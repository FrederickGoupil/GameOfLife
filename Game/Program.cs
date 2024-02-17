using Library;
using System;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace Game
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Conwey's Game of life

            // config

            int sizeX = 500;        // Width
            int sizeY = 250;        // Height
            int nbFrames = 10;      // Number of frames to generate
            int density = 95;       // Chance for cells to be alive on generation

            // Generate

            Console.SetWindowSize((sizeX*2)+1, sizeY+1);
            List<ArrayState> states = new List<ArrayState>(nbFrames);
            states.Add(new ArrayState(sizeX, sizeY));
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

            // Render Frames

            for (int i = 1; i < nbFrames; i++)
            {
                states.Add(new ArrayState(sizeX,sizeY));
                states[i]
            }

            // Print Results


            
            

        }
        
        static string RenderFramePart(ArrayState state, int start, int end)
        {
            string response = "";

            for (int y = start)

            return response;
        }
        /*
        public static void SpawnGlider(Map map)
        {
            map.PlaceSquare(3,35,'■');
            map.PlaceSquare(4,34,'■');
            map.PlaceSquare(4,33,'■');
            map.PlaceSquare(3,33,'■');
            map.PlaceSquare(2,33,'■');
        }

        public static void SpawnGosperGliderGun(Map map)
        {
            map.PlaceSquare(2,34,'■');
            map.PlaceSquare(2,33,'■');
            map.PlaceSquare(3,34,'■');
            map.PlaceSquare(3,33,'■');

            map.PlaceSquare(36,36,'■');
            map.PlaceSquare(36,35,'■');
            map.PlaceSquare(37,36,'■');
            map.PlaceSquare(37,35,'■');

            map.PlaceSquare(26,38,'■');
            map.PlaceSquare(26,37,'■');
            map.PlaceSquare(26,33,'■');
            map.PlaceSquare(26,32,'■');

            map.PlaceSquare(24,37,'■');
            map.PlaceSquare(24,33,'■');
            map.PlaceSquare(22,34,'■');
            map.PlaceSquare(22,35,'■');
            map.PlaceSquare(22,36,'■');
            map.PlaceSquare(23,34,'■');
            map.PlaceSquare(23,35,'■');
            map.PlaceSquare(23,36,'■');

            map.PlaceSquare(19,33,'■');
            map.PlaceSquare(18,32,'■');
            map.PlaceSquare(18,33,'■');
            map.PlaceSquare(18,34,'■');
            map.PlaceSquare(17,35,'■');
            map.PlaceSquare(17,31,'■');

            map.PlaceSquare(16,33,'■');

            map.PlaceSquare(15,36,'■');
            map.PlaceSquare(14,36,'■');
            map.PlaceSquare(13,35,'■');
            map.PlaceSquare(12,34,'■');
            map.PlaceSquare(12,33,'■');
            map.PlaceSquare(12,32,'■');
            map.PlaceSquare(13,31,'■');
            map.PlaceSquare(14,30,'■');
            map.PlaceSquare(15,30,'■');
        }

        public static void SpawnPulsar(Map map)
        {
            map.PlaceSquare(3,5,'■');
            map.PlaceSquare(3,6,'■');
            map.PlaceSquare(3,7,'■');

            map.PlaceSquare(5,8,'■');
            map.PlaceSquare(6,8,'■');
            map.PlaceSquare(7,8,'■');

            map.PlaceSquare(8,7,'■');
            map.PlaceSquare(8,6,'■');
            map.PlaceSquare(8,5,'■');

            map.PlaceSquare(5,3,'■');
            map.PlaceSquare(6,3,'■');
            map.PlaceSquare(7,3,'■');



            map.PlaceSquare(5,10,'■');
            map.PlaceSquare(6,10,'■');
            map.PlaceSquare(7,10,'■');

            map.PlaceSquare(5,15,'■');
            map.PlaceSquare(6,15,'■');
            map.PlaceSquare(7,15,'■');

            map.PlaceSquare(5,15,'■');
            map.PlaceSquare(6,15,'■');
            map.PlaceSquare(7,15,'■');

            map.PlaceSquare(3,11,'■');
            map.PlaceSquare(3,12,'■');
            map.PlaceSquare(3,13,'■');

            map.PlaceSquare(8,11,'■');
            map.PlaceSquare(8,12,'■');
            map.PlaceSquare(8,13,'■');



            map.PlaceSquare(10,11,'■');
            map.PlaceSquare(10,12,'■');
            map.PlaceSquare(10,13,'■');

            map.PlaceSquare(11,10,'■');
            map.PlaceSquare(12,10,'■');
            map.PlaceSquare(13,10,'■');

            map.PlaceSquare(15,11,'■');
            map.PlaceSquare(15,12,'■');
            map.PlaceSquare(15,13,'■');

            map.PlaceSquare(11,15,'■');
            map.PlaceSquare(12,15,'■');
            map.PlaceSquare(13,15,'■');



            map.PlaceSquare(10,7,'■');
            map.PlaceSquare(10,6,'■');
            map.PlaceSquare(10,5,'■');

            map.PlaceSquare(11,8,'■');
            map.PlaceSquare(12,8,'■');
            map.PlaceSquare(13,8,'■');

            map.PlaceSquare(15,7,'■');
            map.PlaceSquare(15,6,'■');
            map.PlaceSquare(15,5,'■');

            map.PlaceSquare(11,3,'■');
            map.PlaceSquare(12,3,'■');
            map.PlaceSquare(13,3,'■');
        }

        public static void SpawnIColumn(Map map)
        {
            map.PlaceSquare(5,4,'■');
            map.PlaceSquare(6,4,'■');
            map.PlaceSquare(7,4,'■');
            map.PlaceSquare(6,5,'■');
            map.PlaceSquare(6,6,'■');
            map.PlaceSquare(5,7,'■');
            map.PlaceSquare(6,7,'■');
            map.PlaceSquare(7,7,'■');

            map.PlaceSquare(5,9,'■');
            map.PlaceSquare(6,9,'■');
            map.PlaceSquare(7,9,'■');
            map.PlaceSquare(5,10,'■');
            map.PlaceSquare(6,10,'■');
            map.PlaceSquare(7,10,'■');

            map.PlaceSquare(5,12,'■');
            map.PlaceSquare(6,12,'■');
            map.PlaceSquare(7,12,'■');
            map.PlaceSquare(6,13,'■');
            map.PlaceSquare(6,14,'■');
            map.PlaceSquare(5,15,'■');
            map.PlaceSquare(6,15,'■');
            map.PlaceSquare(7,15,'■');
        }

        public static void SpawnGliderLoop(Map map)
        {
            map.PlaceSquare(29,70-2,'■');
            map.PlaceSquare(30,70-2,'■');
            map.PlaceSquare(29,70-3,'■');
            map.PlaceSquare(29,70-2,'■');
            map.PlaceSquare(31,70-3,'■');
            map.PlaceSquare(31,70-4,'■');
            map.PlaceSquare(39,70-5,'■');
            map.PlaceSquare(39,70-6,'■');
            map.PlaceSquare(38,70-6,'■');
            map.PlaceSquare(37,70-4,'■');
            map.PlaceSquare(36,70-4,'■');
            map.PlaceSquare(36,70-5,'■');
            map.PlaceSquare(36,70-6,'■');
            map.PlaceSquare(36,70-7,'■');
            map.PlaceSquare(36,70-8,'■');
            map.PlaceSquare(35,70-9,'■');
            map.PlaceSquare(33,70-5,'■');
            map.PlaceSquare(32,70-5,'■');
            map.PlaceSquare(34,70-6,'■');
            map.PlaceSquare(34,70-7,'■');
            map.PlaceSquare(34,70-8,'■');
            map.PlaceSquare(32,70-7,'■');
            map.PlaceSquare(32,70-8,'■');
            map.PlaceSquare(31,70-8,'■');
            map.PlaceSquare(30,70-7,'■');
            map.PlaceSquare(30,70-6,'■');
            map.PlaceSquare(30,70-5,'■');
            map.PlaceSquare(29,70-5,'■');
            map.PlaceSquare(28,70-5,'■');
            map.PlaceSquare(27,70-5,'■');
            map.PlaceSquare(27,70-6,'■');
            map.PlaceSquare(31,70-12,'■');
            map.PlaceSquare(30,70-13,'■');
            map.PlaceSquare(31,70-13,'■');
            map.PlaceSquare(37,70-15,'■');
            map.PlaceSquare(38,70-16,'■');
            map.PlaceSquare(38,70-17,'■');
            map.PlaceSquare(37,70-17,'■');
            map.PlaceSquare(36,70-17,'■');
            map.PlaceSquare(21,70-11,'■');
            map.PlaceSquare(22,70-11,'■');
            map.PlaceSquare(22,70-12,'■');
            map.PlaceSquare(22,70-13,'■');
            map.PlaceSquare(24,70-13,'■');
            map.PlaceSquare(24,70-14,'■');
            map.PlaceSquare(23,70-14,'■');
            map.PlaceSquare(27,70-19,'■');
            map.PlaceSquare(26,70-21,'■');
            map.PlaceSquare(27,70-20,'■');
            map.PlaceSquare(28,70-20,'■');
            map.PlaceSquare(28,70-21,'■');
            map.PlaceSquare(34,70-21,'■');
            map.PlaceSquare(33,70-21,'■');
            map.PlaceSquare(33,70-22,'■');
            map.PlaceSquare(34,70-23,'■');
            map.PlaceSquare(35,70-23,'■');
            map.PlaceSquare(36,70-23,'■');
            map.PlaceSquare(36,70-24,'■');
            
            map.PlaceSquare(5,70-29,'■');
            map.PlaceSquare(6,70-29,'■');
            map.PlaceSquare(6,70-30,'■');
            map.PlaceSquare(4,70-31,'■');
            map.PlaceSquare(4,70-32,'■');
            map.PlaceSquare(5,70-32,'■');
            map.PlaceSquare(6,70-32,'■');
            map.PlaceSquare(7,70-32,'■');
            map.PlaceSquare(8,70-32,'■');
            map.PlaceSquare(9,70-33,'■');
            map.PlaceSquare(8,70-34,'■');
            map.PlaceSquare(7,70-34,'■');
            map.PlaceSquare(6,70-34,'■');
            map.PlaceSquare(5,70-35,'■');
            map.PlaceSquare(5,70-36,'■');
            map.PlaceSquare(7,70-36,'■');
            map.PlaceSquare(8,70-36,'■');
            map.PlaceSquare(8,70-37,'■');
            map.PlaceSquare(3,70-37,'■');
            map.PlaceSquare(4,70-37,'■');
            map.PlaceSquare(2,70-38,'■');
            map.PlaceSquare(2,70-39,'■');
            map.PlaceSquare(3,70-39,'■');
            map.PlaceSquare(5,70-38,'■');
            map.PlaceSquare(6,70-38,'■');
            map.PlaceSquare(7,70-38,'■');
            map.PlaceSquare(5,70-39,'■');
            map.PlaceSquare(5,70-40,'■');
            map.PlaceSquare(5,70-41,'■');
            map.PlaceSquare(6,70-41,'■');
            map.PlaceSquare(15,70-31,'■');
            map.PlaceSquare(16,70-30,'■');
            map.PlaceSquare(17,70-30,'■');
            map.PlaceSquare(17,70-31,'■');
            map.PlaceSquare(17,70-32,'■');
            map.PlaceSquare(12,70-37,'■');
            map.PlaceSquare(13,70-37,'■');
            map.PlaceSquare(13,70-38,'■');
            map.PlaceSquare(24,70-32,'■');
            map.PlaceSquare(23,70-32,'■');
            map.PlaceSquare(23,70-33,'■');
            map.PlaceSquare(23,70-34,'■');
            map.PlaceSquare(21,70-34,'■');
            map.PlaceSquare(21,70-35,'■');
            map.PlaceSquare(22,70-35,'■');
            map.PlaceSquare(21,70-42,'■');
            map.PlaceSquare(21,70-40,'■');
            map.PlaceSquare(20,70-40,'■');
            map.PlaceSquare(19,70-41,'■');
            map.PlaceSquare(20,70-41,'■');
            map.PlaceSquare(13,70-44,'■');
            map.PlaceSquare(14,70-44,'■');
            map.PlaceSquare(14,70-45,'■');
            map.PlaceSquare(11,70-46,'■');
            map.PlaceSquare(12,70-46,'■');
            map.PlaceSquare(11,70-47,'■');
            map.PlaceSquare(13,70-46,'■');
            map.PlaceSquare(57,70-21,'■');
            map.PlaceSquare(57,70-22,'■');
            map.PlaceSquare(56,70-22,'■');
            map.PlaceSquare(55,70-22,'■');
            map.PlaceSquare(54,70-23,'■');
            map.PlaceSquare(54,70-24,'■');
            map.PlaceSquare(55,70-24,'■');
            map.PlaceSquare(47,70-26,'■');
            map.PlaceSquare(48,70-27,'■');
            map.PlaceSquare(49,70-27,'■');
            map.PlaceSquare(47,70-28,'■');
            map.PlaceSquare(48,70-28,'■');
            map.PlaceSquare(44,70-36,'■');
            map.PlaceSquare(46,70-33,'■');
            map.PlaceSquare(45,70-34,'■');
            map.PlaceSquare(45,70-35,'■');
            map.PlaceSquare(45,70-36,'■');
            map.PlaceSquare(47,70-33,'■');
            map.PlaceSquare(47,70-34,'■');
            map.PlaceSquare(51,70-36,'■');
            map.PlaceSquare(51,70-37,'■');
            map.PlaceSquare(51,70-38,'■');
            map.PlaceSquare(52,70-38,'■');
            map.PlaceSquare(53,70-37,'■');
            map.PlaceSquare(55,70-30,'■');
            map.PlaceSquare(55,70-31,'■');
            map.PlaceSquare(56,70-31,'■');
            map.PlaceSquare(63,70-39,'■');
            map.PlaceSquare(62,70-39,'■');
            map.PlaceSquare(62,70-38,'■');
            map.PlaceSquare(64,70-37,'■');
            map.PlaceSquare(64,70-36,'■');
            map.PlaceSquare(63,70-36,'■');
            map.PlaceSquare(62,70-36,'■');
            map.PlaceSquare(61,70-36,'■');
            map.PlaceSquare(60,70-36,'■');
            map.PlaceSquare(59,70-35,'■');
            map.PlaceSquare(60,70-34,'■');
            map.PlaceSquare(61,70-34,'■');
            map.PlaceSquare(62,70-34,'■');
            map.PlaceSquare(63,70-33,'■');
            map.PlaceSquare(63,70-32,'■');
            map.PlaceSquare(64,70-31,'■');
            map.PlaceSquare(65,70-31,'■');
            map.PlaceSquare(66,70-30,'■');
            map.PlaceSquare(66,70-29,'■');
            map.PlaceSquare(65,70-29,'■');
            map.PlaceSquare(62,70-27,'■');
            map.PlaceSquare(63,70-27,'■');
            map.PlaceSquare(63,70-28,'■');
            map.PlaceSquare(63,70-29,'■');
            map.PlaceSquare(63,70-30,'■');
            map.PlaceSquare(62,70-30,'■');
            map.PlaceSquare(61,70-30,'■');
            map.PlaceSquare(60,70-31,'■');
            map.PlaceSquare(60,70-32,'■');
            map.PlaceSquare(61,70-32,'■');
            map.PlaceSquare(32,70-44,'■');
            map.PlaceSquare(32,70-45,'■');
            map.PlaceSquare(33,70-45,'■');
            map.PlaceSquare(34,70-45,'■');
            map.PlaceSquare(35,70-46,'■');
            map.PlaceSquare(34,70-47,'■');
            map.PlaceSquare(35,70-47,'■');
            map.PlaceSquare(42,70-47,'■');
            map.PlaceSquare(40,70-47,'■');
            map.PlaceSquare(40,70-48,'■');
            map.PlaceSquare(41,70-48,'■');
            map.PlaceSquare(41,70-49,'■');
            map.PlaceSquare(44,70-55,'■');
            map.PlaceSquare(44,70-54,'■');
            map.PlaceSquare(45,70-54,'■');
            map.PlaceSquare(46,70-55,'■');
            map.PlaceSquare(46,70-56,'■');
            map.PlaceSquare(46,70-57,'■');
            map.PlaceSquare(47,70-57,'■');
            map.PlaceSquare(38,70-55,'■');
            map.PlaceSquare(37,70-55,'■');
            map.PlaceSquare(37,70-56,'■');
            map.PlaceSquare(32,70-51,'■');
            map.PlaceSquare(31,70-51,'■');
            map.PlaceSquare(30,70-51,'■');
            map.PlaceSquare(30,70-52,'■');
            map.PlaceSquare(31,70-53,'■');
            map.PlaceSquare(29,70-63,'■');
            map.PlaceSquare(29,70-62,'■');
            map.PlaceSquare(30,70-62,'■');
            map.PlaceSquare(31,70-64,'■');
            map.PlaceSquare(32,70-64,'■');
            map.PlaceSquare(32,70-63,'■');
            map.PlaceSquare(32,70-62,'■');
            map.PlaceSquare(32,70-61,'■');
            map.PlaceSquare(32,70-60,'■');
            map.PlaceSquare(33,70-59,'■');
            map.PlaceSquare(34,70-60,'■');
            map.PlaceSquare(34,70-61,'■');
            map.PlaceSquare(34,70-62,'■');
            map.PlaceSquare(35,70-63,'■');
            map.PlaceSquare(36,70-63,'■');
            map.PlaceSquare(36,70-60,'■');
            map.PlaceSquare(36,70-61,'■');
            map.PlaceSquare(37,70-60,'■');
            map.PlaceSquare(38,70-61,'■');
            map.PlaceSquare(38,70-62,'■');
            map.PlaceSquare(41,70-62,'■');
            map.PlaceSquare(41,70-63,'■');
            map.PlaceSquare(40,70-63,'■');
            map.PlaceSquare(39,70-63,'■');
            map.PlaceSquare(38,70-63,'■');
            map.PlaceSquare(37,70-64,'■');
            map.PlaceSquare(37,70-65,'■');
            map.PlaceSquare(38,70-66,'■');
            map.PlaceSquare(39,70-66,'■');
            map.PlaceSquare(39,70-65,'■');
        }
        */
    }
}
