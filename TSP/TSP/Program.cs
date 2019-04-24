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
            Console.WriteLine("Number of points you want to generate: ");
            int numberOfPoints = int.Parse(Console.ReadLine());
            Console.WriteLine("Initial temperature: ");
            double initialTemperature = double.Parse(Console.ReadLine());
            Console.WriteLine("Cooling rate: ");
            double coolingRate = double.Parse(Console.ReadLine());
            List<Point> points = GeneratePoints(numberOfPoints);
            for (int i = 0; i < points.Count; i++)
            {
                Console.WriteLine(points[i].Order + ". (" + points[i].X + "," + points[i].Y + ")");
            }
            Console.WriteLine("Starting distance:" + CalculateGlobalDistance(points));
            SimulateAnnealing(points, initialTemperature, coolingRate);
        }

        private static List<Point> GeneratePoints(int size)
        {
            List<Point> points = new List<Point>();
            Random rand = new Random();
            for (int i = 0; i < size; i++)
            {
                points.Add(new Point
                {
                    Order = i + 1,
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
        
        private static void SimulateAnnealing(List<Point> points, double initialTtemperature, double coolingRate)
        {
            Random rand = new Random();
            int iterations = 0;
            double temperature = initialTtemperature;
            double previousDistance = CalculateGlobalDistance(points);
            List<Point> currentSolution = new List<Point>(points);
            List<Point> bestSolution = new List<Point>(points);

            while (temperature > 1)
            {
                var cities = SwapCities(points, 1);
                double currentDistance = CalculateGlobalDistance(cities);
                double difference = Math.Abs(currentDistance - previousDistance);
                if (currentDistance < previousDistance)
                {
                    currentSolution = cities;
                    bestSolution = cities;
                    previousDistance = currentDistance;
                }
                else
                {
                    if (Math.Exp((previousDistance - currentDistance)/temperature) > rand.NextDouble())
                    {
                        currentSolution = cities;
                        previousDistance = currentDistance;
                    }
                }

                temperature *= 1 - coolingRate;
                iterations += 1;
            }
            PrintResult(bestSolution, iterations, temperature);
        }

        private static void PrintResult(List<Point> solution, int iteration, double temperature)
        {
            Console.WriteLine();
            Console.WriteLine("Finished annealing!");
            Console.WriteLine("Distance: " + CalculateGlobalDistance(solution));
            Console.WriteLine("Iterations: " + iteration);
            Console.WriteLine("Temperature: " + temperature);
            for (int i = 0; i < solution.Count; i++)
            {
                Console.WriteLine(solution[i].Order + ". (" + solution[i].X + "," + solution[i].Y + ")");
            }
            Console.ReadKey();
        }
    }
}
