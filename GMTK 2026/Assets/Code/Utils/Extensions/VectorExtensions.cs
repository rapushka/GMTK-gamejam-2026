using UnityEngine;

namespace Core
{
    public static class VectorExtensions
    {
        public static Vector3 WithZ(this Vector2 self, float z)
        {
            return new Vector3(self.x, self.y, z);
        }
    }
}