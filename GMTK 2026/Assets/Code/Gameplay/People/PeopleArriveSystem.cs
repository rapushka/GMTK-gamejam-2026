using UnityEngine;

namespace Core
{
    public class PeopleArriveSystem : IService
    {
        private static BalanceConfig BalanceConfig => ServiceLocator.Get<BalanceConfig>();

        private float _timeLeft;

        public void OnGameStart()
        {
            ResetTimer();
        }

        public void OnUpdate(float deltaTime)
        {
            _timeLeft -= deltaTime;

            if (_timeLeft > 0)
                return;

            ResetTimer();
            // TODO: Person Arrives
            Debug.Log("PERSON ARRIVE");
        }

        private void ResetTimer()
        {
            _timeLeft = Random.Range(BalanceConfig.PeopleArriveMinS, BalanceConfig.PeopleArriveMaxS);
        }
    }
}