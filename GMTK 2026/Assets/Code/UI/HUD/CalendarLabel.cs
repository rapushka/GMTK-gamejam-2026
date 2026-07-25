using System.Globalization;
using TMPro;
using UnityEngine;

namespace Core
{
    public class CalendarLabel : MonoBehaviour
    {
        [SerializeField] private TMP_Text _clockText;

        private static CalendarSystem CalendarSystem => ServiceLocator.Get<CalendarSystem>();

        private int _cashedHours;

        private void Start()
        {
            _cashedHours = CalendarSystem.CurrentDate.Hour;
            UpdateView();
        }

        private void Update()
        {
            var oldHours = _cashedHours;
            _cashedHours = CalendarSystem.CurrentDate.Hour;

            if (oldHours != _cashedHours)
                UpdateView();
        }

        private void UpdateView()
        {
            var dateString = ExpiryDateUtils.ToLongString(CalendarSystem.CurrentDate);
            _clockText.SetText(dateString);
        }
    }
}