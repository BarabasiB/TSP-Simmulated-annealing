using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPoints = 30;
            List<Point> points = GeneratePoints(numberOfPoints);
        }

        private static List<Point> GeneratePoints(int size)
        {
            List<Point> points = new List<Point>();
            Random rand = new Random();
            for (int i = 0; i < size; i++)
            {
                points.Add(new Point
                {
                    X = rand.NextDouble() * 100,
                    Y = rand.NextDouble() * 100
                });
            }
            return points;
        }

        private static int RandomPosition(int size)
        {
            Random rand = new Random();
            return rand.Next(0, size);
        }

        private static double CalculateGlobalDistance(List<Point> points)
        {
            double distance = 0;
            for (int i = 0; i < points.Count - 1; i++)
            {
                distance += points[i].Distance(points[i + 1]);
            }
            distance += points[points.Count - 1].Distance(points[0]);
            return distance;
        }

        private static List<Point> SwapCities(List<Point> points, int citiesToSwap)
        {
            List<Point> cities = new List<Point>(points);
            Random rand = new Random();
            int idx1, idx2;
            for (int i = 0; i < citiesToSwap; i++)
            {
                idx1 = rand.Next(0, cities.Count);
                idx2 = rand.Next(0, cities.Count);
                var temp = cities[idx1];
                cities[idx1] = cities[idx2];
                cities[idx2] = temp;
            }
            return cities;
        }
    }
}
