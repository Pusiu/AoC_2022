namespace AoC_2022
{
    public class Day1 : Day
    {
        public override string Part1()
        {
            var elves = input.Split("\n\n");
            var maxCalories = 0;
            foreach (var elf in elves)
            {
                var inventory = elf.Replace("\r", "").Split("\n", StringSplitOptions.RemoveEmptyEntries);
                var calories = 0;
                foreach (var item in inventory)
                {
                    calories += int.Parse(item);
                }
                if (maxCalories < calories)
                    maxCalories = calories;
            }

            return maxCalories.ToString();
        }

        public override string Part2()
        {
            // isTest=true;
            // input = GetInput().Result;
            var elves = input.Split("\n\n");
            var allCalories = new List<int>();
            foreach (var elf in elves)
            {
                var inventory = elf.Replace("\r", "").Split("\n", StringSplitOptions.RemoveEmptyEntries);
                var calories = 0;
                foreach (var item in inventory)
                {
                    calories += int.Parse(item);
                }
                allCalories.Add(calories);
            }

            allCalories.Sort((a,b) => b > a ? 1 : -1);
            return allCalories.Take(3).Sum().ToString();
        }
    }
}