namespace AoC_2022
{
    public class Day8 : Day
    {
        public override string Part1()
        {
            return GetTreesVisibility().Where(x => x.visibleFromOutside).Count().ToString();
        }

        List<(int x, int y, int score, bool visibleFromOutside)> GetTreesVisibility()
        {
            var treeMap = input.Replace("\r", "").Split("\n", StringSplitOptions.RemoveEmptyEntries).Select(x => x.Select(x => int.Parse(x.ToString())).ToArray()).ToArray();

            var yLen = treeMap.Length;
            var xLen = treeMap[0].Length;
            var visibleTrees = new List<(int x, int y, int score, bool visibleFromOutside)>();
            for (int y = 0; y < yLen; y++)
            {
                for (int x = 0; x < xLen; x++)
                {
                    var visibleDirs = new Dictionary<string, (int score, bool visibleFromOutside)>
                    {
                        {"u", (0, true)},
                        {"d", (0, true)},
                        {"l", (0, true)},
                        {"r", (0, true)},
                    };

                    for (var x2 = 1; x2 < xLen; x2++)
                    {
                        var key = "r";
                        if (x + x2 < xLen)
                            if (visibleDirs[key].visibleFromOutside)
                                if (treeMap[y][x + x2] >= treeMap[y][x])
                                    visibleDirs[key] = (visibleDirs[key].score + 1, false);
                                else
                                    visibleDirs[key] = (visibleDirs[key].score + 1, visibleDirs[key].visibleFromOutside);
                        key = "l";
                        if (x - x2 >= 0)
                            if (visibleDirs[key].visibleFromOutside)
                                if (treeMap[y][x - x2] >= treeMap[y][x])
                                    visibleDirs[key] = (visibleDirs[key].score + 1, false);
                                else
                                    visibleDirs[key] = (visibleDirs[key].score + 1, visibleDirs[key].visibleFromOutside);
                    }

                    for (var y2 = 1; y2 < yLen; y2++)
                    {
                        var key = "d";
                        if (y + y2 < yLen)
                            if (visibleDirs[key].visibleFromOutside)
                                if (treeMap[y + y2][x] >= treeMap[y][x])
                                    visibleDirs[key] = (visibleDirs[key].score + 1, false);
                                else
                                    visibleDirs[key] = (visibleDirs[key].score + 1, visibleDirs[key].visibleFromOutside);
                        key = "u";
                        if (y - y2 >= 0)
                            if (visibleDirs[key].visibleFromOutside)
                                if (treeMap[y - y2][x] >= treeMap[y][x])
                                    visibleDirs[key] = (visibleDirs[key].score + 1, false);
                                else
                                    visibleDirs[key] = (visibleDirs[key].score + 1, visibleDirs[key].visibleFromOutside);
                    }

                    var isVisible = visibleDirs.Any(x => x.Value.visibleFromOutside);
                    if (isVisible)
                    {
                        visibleTrees.Add(new(y, x, visibleDirs.Select(x => x.Value.score).Aggregate((x, y) => x * y), isVisible));
                    }
                }
            }
            return visibleTrees;
        }

        public override string Part2()
        {
            return GetTreesVisibility().OrderByDescending(x => x.score).First().score.ToString();
        }
    }
}