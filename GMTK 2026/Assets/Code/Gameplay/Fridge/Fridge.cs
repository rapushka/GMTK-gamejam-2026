using JetBrains.Annotations;
using UnityEngine;

namespace Core
{
    public class Fridge : MonoBehaviour
    {
        [SerializeField] private Shelf[] _shelves;
        [SerializeField] private Collider2D _collider;
        [SerializeField] private GameObject _doorPivot;

        [field: SerializeField] public GameObject PeopleContainer { get; private set; }

        public Shelf[] Shelves => _shelves;

        public GameObject DoorPivot => _doorPivot;

        public bool IsInBounds(Vector2 worldPoint)
        {
            return _collider.OverlapPoint(worldPoint);
        }

        [CanBeNull]
        public Shelf FindDropShelf(Vector2 dropPosition)
        {
            const float slack = Constants.ItemDropSlack;

            Shelf target = null;
            var bestY = float.NegativeInfinity;

            foreach (var shelf in _shelves)
            {
                var shelfSurfaceY = shelf.SurfaceY;

                if (shelfSurfaceY - slack <= dropPosition.y && shelfSurfaceY > bestY)
                {
                    bestY = shelfSurfaceY;
                    target = shelf;
                }
            }

            return target;
        }
    }
}