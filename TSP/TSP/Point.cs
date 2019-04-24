﻿using System;
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

        public double Distance(Point b)
        {
            double distX = this.X - b.X;
            double distY = this.Y - b.Y;
            return Math.Sqrt(distX * distX + distY * distY);
        }
    }
}
