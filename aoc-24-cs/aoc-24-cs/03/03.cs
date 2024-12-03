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
            int sum2 = 0;

            string input = File.ReadAllText("03\\input_03.txt");
            
            // Part 1
            sum += ExtractSum(input);

            // Part 2
            var donts = input.Split("don't()");

            for (int i = 0; i < donts.Length; i++)
            {
                if(i == 0)
                {
                    sum2 += ExtractSum(donts[i]);
                }
                else
                {
                    int doIdx = donts[i].IndexOf("do()");
                    if (doIdx > -1)
                    {
                        string doStr = donts[i].Substring(doIdx);
                        sum2 += ExtractSum(doStr);

                    }
                }
            }

            var timeTaken1 = sw.Elapsed;

            Console.WriteLine("Day 03-01: " + sum);
            Console.WriteLine("Day 03-02: " + sum2);
            Console.WriteLine("Execution time (ms): " + timeTaken1.TotalMilliseconds);
        }

        private static int ExtractSum(string line)
        {
            var matches = Regex.Matches(line, "mul\\([0-9]{1,3},[0-9]{1,3}\\)");
            int sum = 0;

            foreach (var match in matches)
            {
                var str = match.ToString();
                var comma = str.IndexOf(',');
                var num1 = int.Parse(str.Substring(4, comma - 4));
                var num2 = int.Parse(str.Substring(comma + 1, str.Length - 2 - comma));

                sum += num1 * num2;
            }

            return sum;
        }
    }
}
