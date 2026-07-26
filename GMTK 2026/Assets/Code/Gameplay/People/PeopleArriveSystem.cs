using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Core
{
    public class PeopleArriveSystem : IService
    {
        private static BalanceConfig  BalanceConfig  => ServiceLocator.Get<BalanceConfig>();
        private static ItemsContainer ItemsContainer => ServiceLocator.Get<ItemsContainer>();
        private static AudioPlayer     AudioPlayer     => ServiceLocator.Get<AudioPlayer>();
        
        private float _timeLeft;
        private bool _isFridgeOccupied = false;
        private readonly PersonArriveAnimationMixin _animationMixin = new();
        private readonly PersonSpawnerMixin _spawnerMixin = new();
        private readonly PersonEatItemsMixin _eatItemsMixin = new();
        private readonly BringNewGroceriesMixin _newGroceriesMixin = new();

        public void OnGameStart()
        {
            ResetTimer();

            _isFridgeOccupied = false;

            _spawnerMixin.Init();
        }

        public void OnUpdate(float deltaTime)
        {
            if (_isFridgeOccupied)
                return;

            _timeLeft -= deltaTime;

            if (_timeLeft > 0)
                return;

            _isFridgeOccupied = true;

            if (ItemsContainer.NeedsNewFood)
            {
                BringNewFood().Forget();
            }
            else
            {
                var person = _spawnerMixin.PickRandom();
                ArrivePersonToEat(person).Forget();
            }
        }

        private async UniTask BringNewFood()
        {
            await _animationMixin.PlayArrive(_spawnerMixin.HandWithGroceries);
            AudioPlayer.PlaySound(SoundKey.GroceriesBag_1);
            await _newGroceriesMixin.UnpackNewFood(_spawnerMixin.HandWithGroceries);
            await _animationMixin.PlayHide(_spawnerMixin.HandWithGroceries);

            OnPersonLeft();
        }

        private async UniTask ArrivePersonToEat(PersonComponent person)
        {
            await _animationMixin.PlayArrive(person);
            await _eatItemsMixin.EatItems();
            await _animationMixin.PlayHide(person);

            OnPersonLeft();
        }

        private void OnPersonLeft()
        {
            ResetTimer();
            _isFridgeOccupied = false;
        }

        private void ResetTimer()
        {
            _timeLeft = BalanceConfig.PeopleArriveS.GetRandom();
        }
    }
}