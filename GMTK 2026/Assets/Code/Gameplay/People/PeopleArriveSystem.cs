using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Core
{
    public class PeopleArriveSystem : IService
    {
        private static BalanceConfig BalanceConfig => ServiceLocator.Get<BalanceConfig>();

        private float _timeLeft;
        private bool _isWaitingForPerson = false;
        private PersonArriveAnimationMixin _animationMixin;
        private PersonSpawnerMixin _spawnerMixin;
        private PersonEatItemsMixin _eatItemsMixin;

        public void OnGameStart()
        {
            ResetTimer();
            _animationMixin = new();
            _spawnerMixin = new();
            _eatItemsMixin = new();
            _isWaitingForPerson = true;

            _spawnerMixin.Init();
        }

        public void OnUpdate(float deltaTime)
        {
            if (!_isWaitingForPerson)
                return;

            _timeLeft -= deltaTime;

            if (_timeLeft > 0)
                return;

            var person = _spawnerMixin.PickRandom();

            _isWaitingForPerson = false;
            ArrivePerson(person).Forget();
        }

        private async UniTask ArrivePerson(PersonComponent person)
        {
            await _animationMixin.PlayArrive(person);
            await _eatItemsMixin.EatItems();
            await _animationMixin.PlayHide(person);

            OnPersonLeft();
        }

        private void OnPersonLeft()
        {
            ResetTimer();
            _isWaitingForPerson = true;
        }

        private void ResetTimer()
        {
            _timeLeft = Random.Range(BalanceConfig.PeopleArriveMinS, BalanceConfig.PeopleArriveMaxS);
        }
    }
}