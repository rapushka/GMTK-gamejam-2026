using DefaultNamespace;
using UnityEngine;

namespace Core
{
    public class Item : MonoBehaviour
    {
        [SerializeField] private Collider2D _collider;

        private static ScreensMediator ScreensMediator => ServiceLocator.Get<ScreensMediator>();

        private Vector2 _grabOffset;
        private Vector2 _startPosition;

        public Vector2 WorldPosition
        {
            get => transform.position;
            set => transform.position = value.WithZ(SortingZ.Item);
        }

        public void StartDrag(Vector2 mouseWorld)
        {
            _grabOffset = WorldPosition - mouseWorld;
            _startPosition = WorldPosition;
        }

        public void Drag(Vector2 mouseWorld)
        {
            WorldPosition = mouseWorld + _grabOffset;
        }

        public void EndDrag()
        {
            var mouseWorld = WorldPosition - _grabOffset;

            var droppedInFridge = PhysicsUtils.HasComponentAtPoint<Fridge>(mouseWorld);

            if (droppedInFridge)
                DropOnClosestShelf();
            else
                ReturnToStart();
        }

        private void ReturnToStart()
        {
            WorldPosition = _startPosition;
        }

        private void DropOnClosestShelf()
        {
            var fridge = ScreensMediator.GameScreen.Fridge;
            var shelf = fridge.FindDropShelf(WorldPosition);

            if (shelf is null)
            {
                ReturnToStart();
                return;
            }

            WorldPosition = shelf.ClampItem(WorldPosition, _collider.bounds);
        }
    }
}