using JetBrains.Annotations;
using UnityEngine;

namespace Core
{
    public class Fridge : MonoBehaviour
    {
        [SerializeField] private Shelf[] _shelves;

        public Shelf[] Shelves => _shelves;

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