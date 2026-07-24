using UnityEngine;

namespace Core
{
    public class Shelf : MonoBehaviour
    {
        [SerializeField] private Collider2D _collider;

        private Bounds Bounds => _collider.bounds;

        private Vector2 WorldPosition => transform.position;

        public Vector2 CreateRandomPoint()
        {
            var point = new Vector2
            {
                x = Random.Range(Bounds.min.x, Bounds.max.x),
                y = Bounds.max.y,
            };
            return point;
        }

        public Vector2 ClampItem(Vector2 worldPoint, Bounds itemBounds)
        {
            var halfW = itemBounds.extents.x;
            var halfH = itemBounds.extents.y;

            var minX = Bounds.min.x + halfW;
            var maxX = Bounds.max.x - halfW;
            var minY = Bounds.min.y + halfH;
            var maxY = Bounds.max.y - halfH;

            return new()
            {
                x = minX > maxX ? Bounds.center.x : worldPoint.x.Clamp(minX, maxX),
                y = minY > maxY ? Bounds.center.y : worldPoint.y.Clamp(minY, maxY),
            };
        }
    }
}