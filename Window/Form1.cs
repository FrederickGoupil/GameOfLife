using Library;
using Game;
using System.Diagnostics;

namespace Window
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            Map map = new Map(200, 100);
            Stopwatch sw = Stopwatch.StartNew();

            InitializeComponent();

            tableLayoutPanel1 = new TableLayoutPanel();

            tableLayoutPanel1.Size = new System.Drawing.Size(200, 100);
            tableLayoutPanel1.RowCount = 100;
            tableLayoutPanel1.ColumnCount = 200;
            
            // init

            map.GenerateMap(5);


            sw.Start();
            // loop
            /*while (true)
            {*/
            double updateTime;
            double RenderTime = 0.0;

            Thread.Sleep(100);

            sw.Restart();
            map.UpdateMap();
            updateTime = sw.Elapsed.TotalMilliseconds;
            sw.Restart();
            //map.RenderMap();

            map.RenderForm();

            RenderTime = sw.Elapsed.TotalMilliseconds;

            /* }*/

            

            
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
