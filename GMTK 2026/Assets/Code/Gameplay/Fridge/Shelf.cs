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
    }
}