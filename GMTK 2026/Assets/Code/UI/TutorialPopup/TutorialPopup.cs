using System;
using UnityEngine;
using UnityEngine.UI;

namespace Core
{
    public class TutorialPopup : MonoBehaviour
    {
        [SerializeField] private Button _closeButton;
        [SerializeField] private Button _leftArrowButton;
        [SerializeField] private Button _rightArrowButton;

        [SerializeField] private CanvasGroup[] _pages;
        
        private int _currentPage;
        
        public event Action OnCloseButtonClicked;

        private void Awake()
        {
            _leftArrowButton.onClick.AddListener(LeftArrowClicked);
            _rightArrowButton.onClick.AddListener(RightArrowClicked);
            _closeButton.onClick.AddListener(CloseButtonClicked);
        }

        private void OnDestroy()
        {
            _leftArrowButton.onClick.RemoveListener(LeftArrowClicked);
            _rightArrowButton.onClick.RemoveListener(RightArrowClicked);
            _closeButton.onClick.RemoveListener(CloseButtonClicked);
        }

        public void ShowInitial()
        {
            foreach (var page in _pages)
            {
                page.gameObject.SetActive(false);
            }
            
            _currentPage = 0;
            _pages[_currentPage].gameObject.SetActive(true);
            Show();
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
        
        private void CloseButtonClicked()
        {
            OnCloseButtonClicked?.Invoke();
        }

        private void LeftArrowClicked()
        {
            if(_currentPage == 0)
                return;
            
            TurnPage(_currentPage - 1);
        }
        
        private void RightArrowClicked()
        {
            if(_currentPage == _pages.Length - 1)
                return;
            
            TurnPage(_currentPage + 1);
        }

        private void TurnPage(int nextPage)
        {
            _pages[_currentPage].gameObject.SetActive(false);
            _currentPage = nextPage;
            _pages[_currentPage].gameObject.SetActive(true);
            
            UpdateButtonsAvailability();
        }

        private void UpdateButtonsAvailability()
        {
            _leftArrowButton.interactable = _currentPage > 0;
            _rightArrowButton.interactable = _currentPage < _pages.Length - 1;
        }
    }
}