using System.Diagnostics;

namespace aoc_24_cs
{
    public partial class Program
    {
        public static void Problem06()
        {
            var sw = Stopwatch.StartNew();
            int sum1 = 0;
            int sum2 = 0;

            //foreach (var line in File.ReadLines("06\\input_05.txt"))
            foreach (var line in File.ReadLines("06\\example_06.txt"))
            {
                
            }

            var timeTaken1 = sw.Elapsed;

            Console.WriteLine("Day 06-01: " + sum1);
            Console.WriteLine("Day 06-02: " + sum2);
            Console.WriteLine("Execution time (ms): " + timeTaken1.TotalMilliseconds);
        }
    }
}
