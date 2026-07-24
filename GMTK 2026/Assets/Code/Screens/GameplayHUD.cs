using System;
using Core;
using TMPro;
using UnityEngine;
using System.Globalization;
using UnityEngine.Serialization;

namespace Core
{
    public class GameplayHUD : MonoBehaviour
    {
        [SerializeField] private TMP_Text _clockText;
        [SerializeField] private float _hourTickIntervalS = 0.25f;
        private float _currentTickLeftS;
        private DateTime date = DateTime.Now;
        private CultureInfo _culture = new CultureInfo("en-US"); 
        
        void Start()
        {
            _currentTickLeftS = _hourTickIntervalS;
            _clockText.SetText(date.ToString("HH:00 MMMM dd yyyy", _culture));
        }
        void Update()           
        {
            _currentTickLeftS -= Time.deltaTime;
            if (_currentTickLeftS <= 0f)
            {
                _currentTickLeftS = _hourTickIntervalS;
                date = date.AddHours(1);
                _clockText.SetText(date.ToString("HH:00 MMMM dd yyyy", _culture));
                Debug.Log(date.Hour);
            }
        }
    }
}
