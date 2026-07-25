using System;
using UnityEngine;
using UnityEngine.UI;

namespace Core
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _exitButton;
        
        public event Action OnPlayButtonPressed;
        public event Action OnExitButtonPressed;

        private void Awake()
        {
            _playButton.onClick.AddListener(PlayButtonPressed);
            _exitButton.onClick.AddListener(ExitButtonPressed);
        }

        private void OnDestroy()
        {
            _playButton.onClick.RemoveListener(PlayButtonPressed);
            _exitButton.onClick.RemoveListener(ExitButtonPressed);
        }

        public void Initialize()
        {
#if UNITY_WEBGL
            _exitButton.gameObject.SetActive(false);
#endif
        }

        private void PlayButtonPressed()
        {
            OnPlayButtonPressed?.Invoke();
        }

        private void ExitButtonPressed()
        {
            OnExitButtonPressed?.Invoke();
        }
    }
}