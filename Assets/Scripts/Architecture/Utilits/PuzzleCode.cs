using System.Collections.Generic;

namespace Architecture.Utilits
{
    public static class PuzzleCode
    {
        public static string GetPuzzleCode(List<int> puzzle)
        {
            var result = "";
            puzzle.Sort();
            foreach (var num in puzzle) result += num.ToString();
            return result;
        }
    }
}