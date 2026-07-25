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
            _cashedHours = CalendarSystem.CurrentDateTime.Hour;
            UpdateView();
        }

        private void Update()
        {
            var oldHours = _cashedHours;
            _cashedHours = CalendarSystem.CurrentDateTime.Hour;

            if (oldHours != _cashedHours)
                UpdateView();
        }

        private void UpdateView()
        {
            var dateString = ExpiryDateUtils.ToLongString(CalendarSystem.CurrentDateTime);
            _clockText.SetText(dateString);
        }
    }
}