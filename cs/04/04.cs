using System.Diagnostics;
using System.Text.RegularExpressions;

namespace aoc_24_cs
{
    public partial class Program
    {
        public static void Problem04()
        {
            var sw = Stopwatch.StartNew();
            int sum = 0;
            int sum2 = 0;

            // Extract horizontal strings:
            var horizontals = File.ReadAllLines("04\\input_04.txt").ToList();
            var rows = horizontals.Count;
            var cols = horizontals[0].Length;

            // Extract vertical strings:
            var verticals = new List<string>();
            for (int i = 0; i < cols; i++)
            {
                string verticalString = "";

                for (int j = 0; j < rows; j++)
                {
                    verticalString += horizontals[j].ElementAt(i);
                }

                verticals.Add(verticalString);
            }

            // Extract diagonal top left to bottom right
            var diagonals1 = new List<string>();
            for (int i = 0; i < cols - 3; i++)
            {
                string diagString = "";
                int row = 0;
                int col = i;

                while (row < rows && col < cols)
                {
                    diagString += horizontals[row].ElementAt(col);
                    row++;
                    col++;
                }

                diagonals1.Add(diagString);
            }

            for (int i = 1; i < rows - 3; i++)
            {
                string diagString = "";
                int row = i;
                int col = 0;

                while (row < rows && col < cols)
                {
                    diagString += horizontals[row].ElementAt(col);
                    row++;
                    col++;
                }

                diagonals1.Add(diagString);
            }

            // Extract diagonal top right to bottom left
            var diagonals2 = new List<string>();
            for (int i = 3; i < cols; i++)
            {
                string diagString = "";
                int row = 0;
                int col = i;

                while (row < rows && col >= 0)
                {
                    diagString += horizontals[row].ElementAt(col);
                    row++;
                    col--;
                }

                diagonals2.Add(diagString);
            }

            for (int i = 1; i < rows - 3; i++)
            {
                string diagString = "";
                int row = i;
                int col = cols-1;

                while (row < rows && col >= 0)
                {
                    diagString += horizontals[row].ElementAt(col);
                    row++;
                    col--;
                }

                diagonals2.Add(diagString);
            }

            var all = new List<List<string>> { horizontals, verticals, diagonals1, diagonals2 };
            foreach(string str in all.SelectMany(x => x))
            {
                sum += CountMatches(str, "XMAS");
            }


            // Part 2

            for (int i = 0; i <= rows - 3; i++)
            {
                for (int j = 0; j <= cols - 3; j++)
                {
                    string str1 = horizontals[i].Substring(j, 3);
                    string str2 = horizontals[i+1].Substring(j, 3);
                    string str3 = horizontals[i+2].Substring(j, 3);

                    if (str2.ElementAt(1) == 'A')
                    {
                        string diag1 = str1.ElementAt(0).ToString() + str2.ElementAt(1).ToString() + str3.ElementAt(2).ToString();
                        string diag2 = str1.ElementAt(2).ToString() + str2.ElementAt(1).ToString() + str3.ElementAt(0).ToString();

                        sum2 += (CountMatches(diag1, "MAS") == 1 && CountMatches(diag2, "MAS") == 1) ? 1 : 0;
                    }

                }
            }

            var timeTaken1 = sw.Elapsed;

            Console.WriteLine("Day 04-01: " + sum);
            Console.WriteLine("Day 04-02: " + sum2);
            Console.WriteLine("Execution time (ms): " + timeTaken1.TotalMilliseconds);
        }

        private static int CountMatches(string str, string wordToFind)
        {
            string reversed = new string(wordToFind.Reverse().ToArray());
            int sum = 0;
            sum += Regex.Count(str, wordToFind);
            sum += Regex.Count(str, reversed);
            return sum;
        }
    }
}
