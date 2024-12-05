namespace aoc_24_cs
{
    public partial class Program
    {
        private static readonly int Days = 25;

        private static List<Action> actions = new List<Action>()
        {
            Problem01, Problem02, Problem03, Problem04
        };

        public static void Main(string[] args)
        {
            if(args.Length > 0 && int.TryParse(args[0], out int problem))
            {
                if(problem > Days || problem < 1)
                {
                    throw new ArgumentOutOfRangeException(nameof(args), problem,
                        $"Invalid input, select between day 1 to 25.");
                }

                if(problem > actions.Count)
                {
                    Console.WriteLine($"Day {problem} not solved yet ...");
                    return;
                }

                Console.WriteLine($"Solving day {problem} ...");
                actions[problem - 1].Invoke();
            }
            else
            {
                Console.WriteLine($"Solving day {actions.Count} ...");
                actions.Last().Invoke();
            }
        }
    }
}
