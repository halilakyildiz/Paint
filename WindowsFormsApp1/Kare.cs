using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class Kare:Sekil
    {
        public Kare()
        {
            width = height;
        }
        SolidBrush brush = new SolidBrush(Color.Black);
        public override void Ciz(Graphics cizimAraci,System.Windows.Forms.PaintEventArgs e)
        {


            e.Graphics.FillRectangle(brush, X, Y, width, width);

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
