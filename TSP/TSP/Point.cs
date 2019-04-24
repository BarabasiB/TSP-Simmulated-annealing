using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP
{
    public class Point
    {
        public int Order { get; set; }
        public double X { get; set; }
        public double Y { get; set; }

        public double Distance(Point b)
        {
            double distX = this.X - b.X;
            double distY = this.Y - b.Y;
            return Math.Sqrt(distX * distX + distY * distY);
        }

        public string PrintPoint()
        {
            return this.Order.ToString() + ". (" + this.X.ToString() + "," + this.Y.ToString() + ")";
        }
    }
}
