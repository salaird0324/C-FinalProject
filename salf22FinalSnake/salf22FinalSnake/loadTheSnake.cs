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
    class loadTheSnake
    {
        public double x, y;
        public Rectangle rec = new Rectangle();
        public loadTheSnake(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public void setsnakeposition()
        {
            rec.Width = rec.Height = 10;
            rec.Fill = Brushes.Aquamarine;
            Canvas.SetLeft(rec, x);
            Canvas.SetTop(rec, y);
        }
    }
}
