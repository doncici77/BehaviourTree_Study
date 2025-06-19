using System;
using System.Collections.Generic;

namespace NPC_Example
{
    // Fisher-Yates shuffle
    public static class RandomExtensions
    {
        public static void Shuffle<T>(this Random random, IList<T> list)
        {
            int n = list.Count;

            while (n > 1)
            {
                int m = random.Next(0, n--);
                T tmp = list[m];
                list[m] = list[n];
                list[n] = tmp;
            }
        }
    }
}