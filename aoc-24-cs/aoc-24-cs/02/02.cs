using System.Diagnostics;
using System.Security.Cryptography;

namespace aoc_24_cs
{
    public partial class Program
    {
        public static void Problem02()
        {
            var sw = Stopwatch.StartNew();
            int safeReports = 0;
            
            foreach (var line in File.ReadLines("02\\input_02.txt"))
            {
                var nums = line.Split(" ").Select(str => int.Parse(str)).ToList();
                safeReports += CheckReport(nums) ? 1 : 0;
            }

            var timeTaken1 = sw.Elapsed;

            Console.WriteLine("Day 02-01: " + safeReports);
            Console.WriteLine("Execution time (ms): " + timeTaken1.TotalMilliseconds);


            //var timeTaken2 = sw.Elapsed - timeTaken1;

            //Console.WriteLine("Day 01-02: " + similarityScore);
            //Console.WriteLine("Execution time (ms): " + timeTaken2.TotalMilliseconds);
        }

        private static bool CheckReport(List<int> report)
        {
            bool inc = false, dec = false;

            for (int i = 1; i < report.Count; i++)
            {
                int diff = report[i] - report[i - 1];
                if (diff == 0) return false;
                if (Math.Abs(diff) > 3) return false;

                if (diff < 0)
                {
                    if (inc) return false;
                    dec = true;
                }
                else if (diff > 0)
                {
                    if (dec) return false;
                    inc = true;
                }
            }

            return true;
        }
    }
}
