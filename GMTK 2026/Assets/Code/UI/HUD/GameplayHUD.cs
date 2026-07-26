using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Core
{
    public class GameplayHUD : MonoBehaviour
    {
        [field: SerializeField] public LivesCounterUI LivesCounter { get; private set; } 
        [SerializeField] private Button _tutorialButton;
        public event Action OnTutorialButtonClicked;

        private void Awake()
        {
            _tutorialButton.onClick.AddListener(TutorialButtonClicked);
        }

        private void OnDestroy()
        {
            _tutorialButton.onClick.RemoveListener(TutorialButtonClicked);
        }

        private void TutorialButtonClicked()
        {
            OnTutorialButtonClicked?.Invoke();
        }
    }
}