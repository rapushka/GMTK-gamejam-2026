using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public static class CollectionExtensions
    {
        public static T PickRandom<T>(this T[] self)
        {
            var count = self.Length;
            if (count == 0)
                throw new($"To Pick Random {self.GetType().Name} has to have at least 1 item!");

            if (count == 1)
                return self[0];

            var randomIndex = Random.Range(0, count);
            return self[randomIndex];
        }

        public static T PickRandom<T>(this List<T> self)
        {
            var count = self.Count;
            if (count == 0)
                throw new($"To Pick Random {self.GetType().Name} has to have at least 1 item!");

            if (count == 1)
                return self[0];

            var randomIndex = Random.Range(0, count);
            return self[randomIndex];
        }
    }
}