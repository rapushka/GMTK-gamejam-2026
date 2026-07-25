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
        private Vector2 _lasMousePosition;

        public ItemKey Key { get; private set; }

        public Bounds Bounds => _collider.bounds;

        public Vector2 WorldPosition
        {
            get => transform.position;
            set => transform.position = value.WithZ(SortingZ.Item);
        }

        public void Init(ItemKey key)
        {
            Key = key;
        }

        public void StartDrag(Vector2 mouseWorld)
        {
            _grabOffset = WorldPosition - mouseWorld;
            _startPosition = WorldPosition;
        }

        public void Drag(Vector2 mouseWorld)
        {
            _lasMousePosition = mouseWorld;
            WorldPosition = _lasMousePosition + _grabOffset;
        }

        public void EndDrag()
        {
            var fridge = ScreensMediator.GameScreen.Fridge;
            var isDroppedInFridge = fridge.IsInBounds(_lasMousePosition);

            if (isDroppedInFridge)
            {
                DropOnClosestShelf();
                return;
            }

            var trashBin = ScreensMediator.GameScreen.TrashBin;
            var isDroppedInTrash = trashBin.IsInBounds(_lasMousePosition);

            if (isDroppedInTrash)
            {
                DropInTrash();
                return;
            }

            ReturnToStart();
        }

        private void DropInTrash()
        {
            Destroy(gameObject);
            // TODO: health controller
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