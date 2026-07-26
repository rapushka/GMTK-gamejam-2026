using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Core
{
    [Serializable]
    public struct FloatRange
    {
        [field: SerializeField] public float Min { get; private set; }
        [field: SerializeField] public float Max { get; private set; }

        public FloatRange(float min, float max)
        {
            Min = min;
            Max = max;
        }

        public FloatRange(float value)
        {
            Min = value;
            Max = value;
        }

        public float GetRandom(bool exclusive = true)
        {
            if (Min >= Max)
                return Min;

            return exclusive ? Random.Range(Min, Max) : Random.Range(Min, Max + 1);
        }
    }
}