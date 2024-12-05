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

            foreach (var line in File.ReadLines("05\\input_05.txt"))
                //foreach (var line in File.ReadLines("05\\example_05.txt"))
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

                    if (ok)
                    {
                        nums.ForEach(n =>
                        {
                            if(rules.ContainsKey(n))
                                Console.WriteLine(n + " | " + string.Join(",", rules[n]));
                        });
                        Console.WriteLine(string.Join(",", nums));
                        Console.WriteLine();
                    }

                    sum1 += ok ? nums[nums.Count / 2] : 0;
                }
            }

            var timeTaken1 = sw.Elapsed;

            Console.WriteLine("Day 01-01: " + sum1);
            Console.WriteLine("Execution time (ms): " + timeTaken1.TotalMilliseconds);


            //Console.WriteLine("Day 01-02: " + similarityScore);
        }
    }
}
