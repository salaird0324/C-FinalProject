using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace salf22FinalSnake
{
    class getBomb
    {
        public double x, y;
        public Ellipse ell = new Ellipse();
        public getBomb(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public void setBombPosition()
        {
            ell.Width = ell.Height = 11;
            ell.Fill = Brushes.Blue;
            Canvas.SetLeft(ell, x);
            Canvas.SetTop(ell, y);
        }
    }
}
