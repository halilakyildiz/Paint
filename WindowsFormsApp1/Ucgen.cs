using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class Ucgen : Sekil
    {
        public int x1;
        public int y1;
        public int x2;
        public int y2;
        public int x3;
        public int y3;
        public int renksecimi;

        SolidBrush brush=new SolidBrush(Color.Black);   

        public override void Ciz(Graphics cizimAraci, PaintEventArgs e)
        {            
                    Point point1 = new Point(x1, y1);
                    Point point2 = new Point(x2, y2);
                    Point point3 = new Point(x3, y3);
               
                    Point[] curvePoints =
                    {
                     point1,
                     point2,
                     point3,
               
                };

                   
                    e.Graphics.FillPolygon(brush, curvePoints);
            

        }
        public void Renk(int r1)
        {

            if (r1 == 1) { brush = new SolidBrush(Color.Crimson); }
            else if (r1 == 2) { brush = new SolidBrush(Color.Blue); }
            else if (r1 == 3) { brush = new SolidBrush(Color.Green); }
            else if (r1 == 4) { brush = new SolidBrush(Color.Chocolate); }
            else if (r1 == 5) { brush = new SolidBrush(Color.Black); }
            else if (r1 == 6) { brush = new SolidBrush(Color.Yellow); }
            else if (r1 == 7) { brush = new SolidBrush(Color.Purple); }
            else if (r1 == 8) { brush = new SolidBrush(Color.Brown); }
            else if (r1 == 9) { brush = new SolidBrush(Color.White); }

        }


    }
}
