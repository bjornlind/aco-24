using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace aoc_24_cs
{
    public partial class Program
    {
        public static void Problem06()
        {
            var sw = Stopwatch.StartNew();
            int sum1 = 0;
            int sum2 = 0;

            string guard = "v^<>";
            Point start = new Point();

            var inputs = File.ReadAllText("06\\example_06.txt").Split(Environment.NewLine);
            //var inputs = File.ReadAllText("06\\input_06.txt").Split(Environment.NewLine);
            char[,] map = new char[inputs[0].Length, inputs.Length];

            for (int i = 0; i < inputs.Length; i++)
            {
                for (int j = 0; j < inputs[i].Length; j++)
                {
                    char c = char.Parse(inputs[i].Substring(j, 1));
                    map[i, j] = c;

                    if (guard.Contains(c))
                    {
                        start.X = j;
                        start.Y = i;
                    }
                }
            }

            int xSize = map.GetLength(0);
            int ySize = map.GetLength(1);

            int xPos = start.X;
            int yPos = start.Y;
            int xDir = 0;
            int yDir = -1;

            List<Point> visitedPoints = new List<Point>();
            visitedPoints.Add(start);

            // rotation matrix for 2d rotation of 90 degress clockwise is:
            // xDirNew = -yDir
            // yDirNew = -xDir
            bool nextPosValid;

            do
            {
                int xNext = xPos + xDir;
                int yNext = yPos + yDir;

                nextPosValid = xNext < xSize && xNext >= 0 && yNext < ySize && yNext >= 0;

                if (nextPosValid)
                {
                    char next = map[xPos + xDir, yPos + yDir];
                
                    if(next == '#')
                    {
                        int xDirPrev = xDir;
                        int yDirPrev = yDir;
                        xDir = -yDirPrev;
                        yDir = -xDirPrev;
                    }

                    xPos += xDir;
                    yPos += yDir;

                    visitedPoints.Add(new Point(xPos, yPos));
                }

            } while (nextPosValid);

            int uniquePoints = visitedPoints.Distinct().Count();

            //for(int i = 0; i < map.GetLength(0); i++)
            //{
            //    for (int j = 0;j < map.GetLength(1); j++)
            //    {
            //        Console.Write(map[i, j]);
            //    }
            //    Console.WriteLine();
            //}



            var timeTaken1 = sw.Elapsed;

            Console.WriteLine("Day 06-01: " + uniquePoints);
            Console.WriteLine("Day 06-02: " + sum2);
            Console.WriteLine("Execution time (ms): " + timeTaken1.TotalMilliseconds);
        }
    }

    //public struct Point
    //{
    //    public int x;
    //    public int y;

    //    public Point(int x, int y) 
    //    {
    //        this.x = x;
    //        this.y = y;
    //    }
    //}
}
