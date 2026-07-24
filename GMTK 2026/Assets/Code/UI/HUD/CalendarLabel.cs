using System.Globalization;
using TMPro;
using UnityEngine;

namespace Core
{
    public class CalendarLabel : MonoBehaviour
    {
        [SerializeField] private TMP_Text _clockText;

        private static CalendarSystem CalendarSystem => ServiceLocator.Get<CalendarSystem>();

        private readonly CultureInfo _english = new("en-US");
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
            _clockText.SetText(CalendarSystem.CurrentDate.ToString("HH:00 MMMM dd yyyy", _english));
        }
    }
}