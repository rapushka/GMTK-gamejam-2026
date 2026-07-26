using System;
using UnityEngine;
using UnityEngine.UI;

namespace Core
{
    public class LosePopup : MonoBehaviour
    {
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _backToMenuButton;
        
        public event Action OnRestartButtonClicked;
        public event Action OnMenuButtonClicked;

        private void Awake()
        {
            _restartButton.onClick.AddListener(RestartButtonClicked);
            _backToMenuButton.onClick.AddListener(MenuButtonClicked);
        }
        private void OnDestroy()
        {
            _restartButton.onClick.RemoveListener(RestartButtonClicked);
            _backToMenuButton.onClick.RemoveListener(MenuButtonClicked);
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        private void MenuButtonClicked()
        { 
            OnMenuButtonClicked?.Invoke();
        }
        
        private void RestartButtonClicked()
        {
            OnRestartButtonClicked?.Invoke();
        }

    }
}