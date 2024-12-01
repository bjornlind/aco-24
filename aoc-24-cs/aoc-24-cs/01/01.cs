using System.Diagnostics;

namespace aoc_24_cs
{
    public partial class Program
    {
        public static void Problem01()
        {
            var sw = Stopwatch.StartNew();
            List<int> leftList = new List<int>();
            List<int> rightList = new List<int>();
            
            foreach (var line in File.ReadLines("01\\input_01.txt"))
            {
                var nums = line.Split("   ");
                leftList.Add(int.Parse(nums[0]));
                rightList.Add(int.Parse(nums[1]));
            }

            leftList.Sort();
            rightList.Sort();

            var totalDist = leftList.Zip(rightList, (ai, bi) => Math.Abs(ai - bi)).Sum();
            var timeTaken1 = sw.Elapsed;

            Console.WriteLine("Day 01-01: " + totalDist);
            Console.WriteLine("Execution time (ms): " + timeTaken1.TotalMilliseconds);


            int similarityScore = 0;
            leftList.ForEach(x => similarityScore += x * rightList.Count(y => x == y));
            var timeTaken2 = sw.Elapsed - timeTaken1;

            Console.WriteLine("Day 01-02: " + similarityScore);
            Console.WriteLine("Execution time (ms): " + timeTaken2.TotalMilliseconds);
        }
    }
}
