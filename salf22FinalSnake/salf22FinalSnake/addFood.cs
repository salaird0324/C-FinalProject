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
    class addFood
    {
        public double x, y;
        public Ellipse ell = new Ellipse();
        public addFood(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public void setfoodposition()
        {
            ell.Width = ell.Height = 10;
            ell.Fill = Brushes.Blue;
            Canvas.SetLeft(ell, x);
            Canvas.SetTop(ell, y);
        }
    }
}
