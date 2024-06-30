using System.Collections.Generic;
using UnityEngine;

namespace Architecture.Utilits
{
    public static class PuzzleGenerator
    {
        public static List<int> GetRandomPuzzle()
        {
            var result = new List<int>();
            for (var i = 0; i < 9; i++)
                if (Random.Range(0, 2) == 1)
                    result.Add(i);
            return result;
        }
    }
}