using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    abstract class Sekil
    {
       public int X;
       public int Y;
  
       public int width;
        public int height;
      

        public abstract void Ciz(Graphics cizimAraci, System.Windows.Forms.PaintEventArgs e);
        

    }
}
