using System.Text.RegularExpressions;
namespace AoC_2022
{
    public class Day4 : Day
    {
        public override string Part1()
        {
            var overlappingPairs = 0;
            foreach (var line in input.Split("\n"))
            {
                var numbers = Regex.Matches(line, @"\d+").Select(x => int.Parse(x.Value)).ToArray();
                if ((numbers[0] <= numbers[2] && numbers[1] >= numbers[3])
                ||
                (numbers[0] >= numbers[2] && numbers[1] <= numbers[3])
                )
                    overlappingPairs++;
            }

            return overlappingPairs.ToString();
        }

        public override string Part2()
        {
            var overlappingPairs = 0;
            foreach (var line in input.Split("\n"))
            {
                var numbers = Regex.Matches(line, @"\d+").Select(x => int.Parse(x.Value)).ToArray();
                var seq1 = Enumerable.Range(numbers[0], numbers[1]-numbers[0]+1);
                var seq2 = Enumerable.Range(numbers[2], numbers[3]-numbers[2]+1);
                if (seq1.Intersect(seq2).Any())
                    overlappingPairs++;
            }

            return overlappingPairs.ToString();
        }
    }
}