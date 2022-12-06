namespace AoC_2022
{
    public class Day6 : Day
    {
        public override string Part1()
        {
            return GetMarkerPosition(4).ToString();
        }

        int GetMarkerPosition(int distinctCharacterCount)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (i < distinctCharacterCount)
                    continue;

                var buffer = input.Skip(i - distinctCharacterCount).Take(distinctCharacterCount);
                if (buffer.Distinct().Count() == distinctCharacterCount)
                {
                    return i;
                }
            }
            return -1;
        }

        public override string Part2()
        {
            return GetMarkerPosition(14).ToString();
        }
    }
}