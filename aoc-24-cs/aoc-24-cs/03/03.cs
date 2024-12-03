using System.Diagnostics;
using System.Text.RegularExpressions;

namespace aoc_24_cs
{
    public partial class Program
    {
        public static void Problem03()
        {
            var sw = Stopwatch.StartNew();
            int sum = 0;

            foreach (var line in File.ReadLines("03\\input_03.txt"))
                //foreach (var line in File.ReadLines("03\\example_03.txt"))
            {
                var matches = Regex.Matches(line, "mul\\([0-9]{1,3},[0-9]{1,3}\\)");

                foreach (var match in matches)
                {
                    var str = match.ToString();
                    var comma = str.IndexOf(',');
                    var num1 = int.Parse(str.Substring(4, comma - 4));
                    var num2 = int.Parse(str.Substring(comma + 1, str.Length - 2 - comma));

                    sum += num1 * num2;
                    Console.WriteLine(match.ToString());
                }
            }

            Console.WriteLine(sum);

            var timeTaken1 = sw.Elapsed;

            //Console.WriteLine("Day 01-01: " + totalDist);
            Console.WriteLine("Execution time (ms): " + timeTaken1.TotalMilliseconds);

            var timeTaken2 = sw.Elapsed - timeTaken1;

            Console.WriteLine("Execution time (ms): " + timeTaken2.TotalMilliseconds);
        }
    }
}
