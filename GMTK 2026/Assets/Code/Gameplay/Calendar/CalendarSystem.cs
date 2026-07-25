using System;
using UnityEngine;

namespace Core
{
    public class CalendarSystem : IService
    {
        private static BalanceConfig Balance => ServiceLocator.Get<BalanceConfig>();

        private int _currentDay;
        private DateTime _currentDateTime;
        private float _currentTickLeftS;

        public DateTime CurrentDateTime => _currentDateTime;

        public int CurrentDay => _currentDay;

        public void Init()
        {
            // Game starts at Today's Day 12:00
            _currentDateTime = DateTime.Today.AddHours(12);
            _currentDay = 0;

            ResetTimer();
        }

        public bool IsSpoiled(Item item) => item.ExpiresOnDate.Date < CurrentDateTime.Date;

        public void OnUpdate()
        {
            _currentTickLeftS -= Time.deltaTime;

            if (_currentTickLeftS > 0f)
                return;

            ResetTimer();

            var oldDate = _currentDateTime.Date;

            _currentDateTime = _currentDateTime.AddHours(1);

            // Date doesn't care about time.
            // So if they aren't equal, then the hour increment changed the day to the next one.
            var isDayPassed = oldDate != _currentDateTime;
            if (isDayPassed)
                _currentDay = CurrentDay + 1;
        }

        private void ResetTimer()
        {
            _currentTickLeftS = Balance.HourTickIntervalS;
        }
    }
}