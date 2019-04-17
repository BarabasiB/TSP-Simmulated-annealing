using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP
{
    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }

        public double Distance(Point a, Point b)
        {
            double distX = a.X - b.X;
            double distY = a.Y - b.Y;
            return Math.Sqrt(distX * distX + distY * distY);
        }
    }
}
