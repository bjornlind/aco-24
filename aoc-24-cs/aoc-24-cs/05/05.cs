using System.Diagnostics;

namespace aoc_24_cs
{
    public partial class Program
    {
        public static void Problem05()
        {
            var sw = Stopwatch.StartNew();
            Dictionary<int, List<int>> rules = new Dictionary<int, List<int>>();
            bool parsingRules = true;
            int sum1 = 0;
            int sum2 = 0;

            foreach (var line in File.ReadLines("05\\input_05.txt"))
            {
                if (parsingRules)
                {
                    if (string.IsNullOrEmpty(line))
                    {
                        parsingRules = false;
                        continue;
                    }

                    var rule = line.Split("|").Select(s => int.Parse(s)).ToList();
                    var page = rule[0];
                    var otherPage = rule[1];

                    if (!rules.ContainsKey(page))
                        rules.Add(page, new List<int>() { otherPage });
                    else
                        rules[page].Add(otherPage);
                }
                else
                {
                    var nums = line.Split(",").Select(int.Parse).ToList();
                    bool ok = true;
                    for (int i = 0; i < nums.Count; i++)
                    {
                        if (!ok) break;
                        var key = nums[i];

                        if (!rules.ContainsKey(key))
                        {
                            // ok if last element 
                            ok = i == nums.Count - 1;
                            break;
                        }
                        else
                        {
                            var pageRules = rules[key];

                            for (int j = i + 1; j < nums.Count; j++)
                            {
                                var nextNum = nums[j];
                                if (!pageRules.Contains(nextNum))
                                {
                                    ok = false;
                                    break;
                                }
                            }
                        }
                    }

                    sum1 += ok ? nums[nums.Count / 2] : 0;

                    // Part 2

                    if (!ok)
                    {
                        nums.ForEach(n =>
                        {
                            if (rules.ContainsKey(n))
                                Console.WriteLine(n + " | " + string.Join(",", rules[n]));
                        });
                        Console.WriteLine(string.Join(",", nums));

                        nums.Sort((scndNum, firstNum) =>
                        {
                            if (!rules.ContainsKey(firstNum))
                            {
                                return -1;
                            }

                            if (!rules.ContainsKey(scndNum))
                            {
                                return 1;
                            }

                            var xRules = rules[scndNum];
                            var yRules = rules[firstNum];

                            if (xRules.Contains(firstNum))
                            {
                                return -1;
                            }

                            if (yRules.Contains(scndNum))
                            {
                                return 1;
                            }

                            return 0;
                        });

                        Console.WriteLine(string.Join(",", nums));
                        Console.WriteLine();

                        sum2 += nums[nums.Count / 2];
                    }
                }
            }

            var timeTaken1 = sw.Elapsed;

            Console.WriteLine("Day 05-01: " + sum1);
            Console.WriteLine("Day 05-02: " + sum2);
            Console.WriteLine("Execution time (ms): " + timeTaken1.TotalMilliseconds);
        }
    }
}
