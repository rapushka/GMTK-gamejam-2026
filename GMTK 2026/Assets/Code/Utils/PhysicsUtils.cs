using UnityEngine;

namespace Core
{
    public static class PhysicsUtils
    {
        public static bool TryGetComponentAtPoint<TComponent>(Vector2 worldPoint, out TComponent component)
            where TComponent : Component
        {
            var hit = Physics2D.OverlapPoint(worldPoint);

            component = null;
            return hit != null && hit.TryGetComponent(out component);
        }

        public static bool HasComponentAtPoint<TComponent>(Vector2 worldPoint)
            where TComponent : Component
        {
            return TryGetComponentAtPoint<TComponent>(worldPoint, out var _);
        }
    }
}