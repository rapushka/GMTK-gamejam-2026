using JetBrains.Annotations;
using UnityEngine;

namespace Core
{
    public class Fridge : MonoBehaviour
    {
        [SerializeField] private Shelf[] _shelves;
        [SerializeField] private Collider2D _collider;

        public Shelf[] Shelves => _shelves;

        public bool IsInBounds(Vector2 worldPoint)
        {
            return _collider.OverlapPoint(worldPoint);
        }

        [CanBeNull]
        public Shelf FindDropShelf(Vector2 dropPosition)
        {
            Shelf target = null;
            var bestY = float.NegativeInfinity;

            foreach (var shelf in _shelves)
            {
                var shelfSurfaceY = shelf.SurfaceY;
                if (shelfSurfaceY <= dropPosition.y && shelfSurfaceY > bestY)
                {
                    bestY = shelfSurfaceY;
                    target = shelf;
                }
            }

            return target;
        }
    }
}