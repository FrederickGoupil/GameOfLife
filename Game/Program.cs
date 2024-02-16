using Library;
using System.Security.Cryptography.X509Certificates;

namespace Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Map map = new Map(60,40);
            // init
            
            SpawnGosperGliderGun(map);
            map.RenderMap();
 
            // loop
            while (true)
            {
                Thread.Sleep(100);
                map.UpdateMap();
                map.RenderMap();
            }
            

        }

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
    }
}
