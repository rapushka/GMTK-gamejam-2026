using System;
using UnityEngine;
using UnityEngine.UI;

namespace Core
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private Button _playButton;
        
        public event Action OnPlayButtonPressed;

        private void Awake()
        {
            _playButton.onClick.AddListener(PlayButtonPressed);
        }

        private void OnDestroy()
        {
            _playButton.onClick.RemoveListener(PlayButtonPressed);
        }

        private void PlayButtonPressed()
        {
            OnPlayButtonPressed?.Invoke();
        }
    }
}