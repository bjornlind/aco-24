namespace aoc_24_cs
{
    public partial class Program
    {
        public static void Problem01()
        {
            List<int> leftList = new List<int>();
            List<int> rightList = new List<int>();
            
            foreach (var line in File.ReadLines("01\\input_01.txt"))
            {
                var firstNumLen = line.IndexOf(' ');
                leftList.Add(int.Parse(line.Substring(0, firstNumLen)));

                var sndNumIdx = line.LastIndexOf(" ") + 1;
                rightList.Add(int.Parse(line.Substring(sndNumIdx)));
            }

            leftList.Sort();
            rightList.Sort();

            var totalDist = leftList.Zip(rightList, (ai, bi) => Math.Abs(ai - bi)).Sum();

            Console.WriteLine(totalDist);

            int similarityScore = 0;
            leftList.ForEach(x => similarityScore += x * rightList.Count(y => x == y));

            Console.WriteLine(similarityScore);
        }
    }
}
