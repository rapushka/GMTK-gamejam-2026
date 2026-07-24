using UnityEngine;

namespace Core
{
    public static class MathExtensions
    {
        public static float Clamp(this float self, float min = float.NaN, float max = float.NaN)
        {
            min = float.IsNaN(min) ? self : min;
            max = float.IsNaN(max) ? self : max;

            return Mathf.Clamp(self, min, max);
        }
    }
}