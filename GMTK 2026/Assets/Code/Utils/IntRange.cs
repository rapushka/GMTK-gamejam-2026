using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Core
{
    [Serializable]
    public struct IntRange
    {
        [field: SerializeField] public int Min { get; private set; }
        [field: SerializeField] public int Max { get; private set; }

        public IntRange(int min, int max)
        {
            Min = min;
            Max = max;
        }

        public int GetRandom(bool exclusive = true)
        {
            if (Min >= Max)
                return Min;

            return exclusive ? Random.Range(Min, Max) : Random.Range(Min, Max + 1);
        }
    }
}