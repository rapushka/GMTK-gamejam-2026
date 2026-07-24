using UnityEngine;

namespace Core
{
    public class Shelf : MonoBehaviour
    {
        [SerializeField] private Collider2D _collider;

        private Bounds Bounds => _collider.bounds;

        public Vector2 CreateRandomPosition()
            => new()
            {
                x = Random.Range(Bounds.min.x, Bounds.max.x),
                y = Bounds.max.y,
            };
    }
}