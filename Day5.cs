using System.Xml.Linq;
using System.Text.RegularExpressions;
namespace AoC_2022
{
    public class Day5 : Day
    {
        public override string Part1()
        {
            // isTest = true;
            // input = GetInput().Result;
            return Simulate(false);
        }

        public string Simulate(bool isCrateMover9001)
        {
            var parts = input.Replace("\r", "").Split("\n\n");
            var stacksDefinition = parts[0].Split("\n");
            var stackCount = stacksDefinition.Select(x => Regex.Matches(x, @"\d+")).Where(x => x.Count > 0).Select(x => x.Select(y => int.Parse(y.Value))).First().Max();

            var stacks = new Stack<char>[stackCount];
            foreach (var def in stacksDefinition.Reverse().Skip(1))
            {
                var targetStack = 0;
                for (int i = 1; i < def.Length; i += 4)
                {
                    if (def[i] != ' ')
                    {
                        if (stacks[targetStack] == null)
                            stacks[targetStack] = new Stack<char>();

                        stacks[targetStack].Push(def[i]);
                    }
                    targetStack++;
                }
            }

            foreach (var instruction in parts[1].Split("\n"))
            {
                var r = Regex.Matches(instruction, @"\d+").Select(x => int.Parse(x.Value)).ToArray();
                if (r.Length == 0)
                    continue;

                var targetStack = stacks[r[2] - 1];
                var currentTargetStack = (isCrateMover9001) ? new Stack<char>() : targetStack;
                for (int i = 0; i < r[0]; i++)
                {
                    var c = stacks[r[1] - 1].Pop();
                    currentTargetStack.Push(c);
                }
                if (isCrateMover9001)
                {
                    while (currentTargetStack.Count > 0)
                    {
                        targetStack.Push(currentTargetStack.Pop());
                    }
                }
            }

            return string.Join("", stacks.Select(x => x.Peek()));
        }

        public override string Part2()
        {
            return Simulate(true);
        }
    }
}