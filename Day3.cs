namespace AoC_2022
{
    public class Day3 : Day
    {
        public override string Part1()
        {
            var totalSum = 0;
            foreach (var rucksack in input.Split("\n"))
            {
                var compartment1 = rucksack.Take(rucksack.Length / 2);
                var compartment2 = rucksack.Skip(rucksack.Length / 2);
                var common = compartment1.Intersect(compartment2).FirstOrDefault();

                var priority = (int)((common > 'a') ? common % 'a' + 1 : common % 'A' + 27);
                totalSum += priority;
            }

            return totalSum.ToString();
        }

        public override string Part2()
        {
            var totalSum = 0;
            var rucksacks = input.Split("\n");
            for (int i = 0; i < rucksacks.Length / 3; i++)
            {
                var rucksackGroup = rucksacks.Skip(i * 3).Take(3).ToList();

                var common = rucksackGroup.Select(x => x.ToCharArray()).Aggregate((a, b) => a.Intersect(b).ToArray()).FirstOrDefault();
                var priority = (int)((common > 'a') ? common % 'a' + 1 : common % 'A' + 27);
                totalSum += priority;
            }

            return totalSum.ToString();
        }
    }
}