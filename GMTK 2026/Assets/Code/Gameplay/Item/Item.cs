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
        private static ItemsContainer  ItemsContainer  => ServiceLocator.Get<ItemsContainer>();
        private static AudioPlayer     AudioPlayer     => ServiceLocator.Get<AudioPlayer>();

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

            ExpiresOnDate = CalendarSystem.CurrentDateTime.AddDays(_daysToLive);
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

            var trashBin = ScreensMediator.GameScreen.TrashBin;
            trashBin.SetOpen(trashBin.IsInBounds(mouseWorld));
        }

        public void EndDrag()
        {
            var trashBin = ScreensMediator.GameScreen.TrashBin;
            trashBin.SetOpen(false);

            var fridge = ScreensMediator.GameScreen.Fridge;
            var isDroppedInFridge = fridge.IsInBounds(_lasMousePosition);

            if (isDroppedInFridge)
            {
                PlayDropSound();

                DropOnClosestShelf();
                return;
            }

            var isDroppedInTrash = trashBin.IsInBounds(_lasMousePosition);

            if (isDroppedInTrash)
            {
                ItemsContainer.ThrowInTrash(this);
                return;
            }

            ReturnToStart();
        }

        private void PlayDropSound()
        {
            switch (Key)
            {
                case ItemKey.Cola:
                case ItemKey.EnergyDrink:
                    AudioPlayer.PlaySound(SoundKey.DropEnergyDrink);
                    break;
                case ItemKey.MeetBeen:
                    AudioPlayer.PlaySound(SoundKey.DropMeenBeens);
                    break;
                case ItemKey.Yogurt:
                    AudioPlayer.PlaySound(SoundKey.DropMilk);
                    break;
                case ItemKey.Unknown:
                default:
                    throw new ArgumentOutOfRangeException();
            }
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