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

        public void OnGameStart()
        {
            ResetTimer();
            _animationMixin = new(this);
            _spawnerMixin = new();
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
            _animationMixin.PlayArrive(person);
        }

        public void OnPersonLeft()
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