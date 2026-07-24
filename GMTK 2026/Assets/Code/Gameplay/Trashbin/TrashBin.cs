using UnityEngine;

namespace Core
{
    public class TrashBin : MonoBehaviour
    {
        private Collider2D _collider;

        private Collider2D Collider => _collider ??= GetComponent<Collider2D>();

        public bool IsInBounds(Vector2 worldPoint)
        {
            return Collider.OverlapPoint(worldPoint);
        }
    }
}