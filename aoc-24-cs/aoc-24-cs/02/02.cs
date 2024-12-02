using System.Diagnostics;

namespace aoc_24_cs
{
    public partial class Program
    {
        public static void Problem02()
        {
            var sw = Stopwatch.StartNew();
            int safeReports = 0;
            int safeReportsWithDamper = 0;

            foreach (var line in File.ReadLines("02\\input_02.txt"))
            {
                var nums = line.Split(" ").Select(str => int.Parse(str)).ToList();
                safeReports += CheckReport(nums) ? 1 : 0;
                safeReportsWithDamper += CheckReportWithDamper(nums) ? 1 : 0;
            }

            var timeTaken = sw.Elapsed;

            Console.WriteLine("Day 02-01: " + safeReports);
            Console.WriteLine("Day 02-02: " + safeReportsWithDamper);
            Console.WriteLine("Execution time (ms): " + timeTaken.TotalMilliseconds);
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

        private static bool CheckReportWithDamper(List<int> report)
        {
            if (CheckReport(report))
            {
                return true;
            }
            else
            {
                for (int i = 0; i < report.Count; i++)
                {
                    List<int> reducedList = new List<int>(report);
                    reducedList.RemoveAt(i);
                    if (CheckReport(reducedList))
                    {
                        Console.WriteLine($"Remove {report[i]} from: [{string.Join(' ', report)}]");
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
