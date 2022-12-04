namespace AoC_2022
{
    public class Day2 : Day
    {
        public override string Part1()
        {
            var totalPoints = 0;
            foreach (var line in input.Split("\n"))
            {
                var points = line.Replace("\r","").Split(" ") switch
                {
                    ["A", "X"] => 3 + 1,
                    ["A", "Y"] => 6 + 2,
                    ["A", "Z"] => 0 + 3,
                    ["B", "X"] => 0 + 1,
                    ["B", "Y"] => 3 + 2,
                    ["B", "Z"] => 6 + 3,
                    ["C", "X"] => 6 + 1,
                    ["C", "Y"] => 0 + 2,
                    ["C", "Z"] => 3 + 3,
                    _ => 0
                };
                totalPoints+=points;
            }
            return totalPoints.ToString();
        }

        public override string Part2()
        {
            var totalPoints = 0;
            foreach (var line in input.Split("\n"))
            {
                var points = line.Replace("\r","").Split(" ") switch
                {
                    ["A", "X"] => 0 + 3, //C to loose
                    ["A", "Y"] => 3 + 1, //A to draw
                    ["A", "Z"] => 6 + 2, //B to win
                    ["B", "X"] => 0 + 1,
                    ["B", "Y"] => 3 + 2,
                    ["B", "Z"] => 6 + 3,
                    ["C", "X"] => 0 + 2,
                    ["C", "Y"] => 3 + 3,
                    ["C", "Z"] => 6 + 1,
                    _ => 0
                };
                totalPoints+=points;
            }
            return totalPoints.ToString();        }
    }
}