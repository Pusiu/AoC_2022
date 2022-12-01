namespace AoC_2022
{
    public class Day1 : Day
    {
        public override string Part1()
        {
            var elves = input.Split("\n\n");
            return elves.Select(x => x.Replace("\r", "").Split("\n", StringSplitOptions.RemoveEmptyEntries))
                        .Select(x => x.Select(int.Parse).Sum())
                        .Max()
                        .ToString();
        }

        public override string Part2()
        {
            var elves = input.Split("\n\n");
            return elves.Select(x => x.Replace("\r", "").Split("\n", StringSplitOptions.RemoveEmptyEntries))
            .Select(x => x.Select(int.Parse).Sum())
            .OrderByDescending(x => x)
            .Take(3)
            .Sum()
            .ToString();
        }
    }
}