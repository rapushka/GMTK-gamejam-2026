using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public static class PhysicsUtils
    {
        private static readonly List<Collider2D> Buffer = new();

        public static bool TryGetComponentAtPoint<TComponent>(Vector2 worldPoint, out TComponent component)
            where TComponent : Component
        {
            Physics2D.OverlapPoint(worldPoint, ContactFilter2D.noFilter, Buffer);

            foreach (var hit in Buffer)
            {
                if (hit.TryGetComponent(out component))
                    return true;
            }

            component = null;
            return false;
        }
    }
}