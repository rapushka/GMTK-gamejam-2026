using System;
using DefaultNamespace;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Core
{
    public class Item : MonoBehaviour
    {
        [SerializeField] private Collider2D _collider;

        private static ScreensMediator ScreensMediator => ServiceLocator.Get<ScreensMediator>();
        private static CalendarSystem  CalendarSystem  => ServiceLocator.Get<CalendarSystem>();

        private Vector2 _grabOffset;
        private Vector2 _startPosition;
        private Vector2 _lasMousePosition;

        private int _daysToLive;
        public DateTime ExpiresOnDate { get; private set; }

        public ItemKey Key { get; private set; }

        public Bounds Bounds => _collider.bounds;

        public Vector2 WorldPosition
        {
            get => transform.position;
            set => transform.position = value.WithZ(SortingZ.Item);
        }

        public void Init(ItemConfig config)
        {
            Key = config.Key;
            _daysToLive = Random.Range(config.MinDaysToLive, config.MaxDaysToLive);

            ExpiresOnDate = CalendarSystem.CurrentDate.AddDays(_daysToLive);
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
            var wasSpoiled = CalendarSystem.IsSpoiled(this);

            Destroy(gameObject);

            if (!wasSpoiled)
            {
                Debug.Log("TODO: MISTAKE! THROWN AWAY GOOD FOOD!");
            }
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