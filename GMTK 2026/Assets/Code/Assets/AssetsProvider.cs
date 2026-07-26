using System;
using UnityEngine;

namespace Core
{
    [Serializable]
    public class AssetsProvider : IService
    {
        [field: SerializeField] public GameScreen  GameScreenPrefab  { get; private set; }
        [field: SerializeField] public GameplayHUD GameplayHUDPrefab { get; private set; }

        [field: SerializeField] public ItemsCollection Items { get; private set; }
        [field: SerializeField] public MainMenu MainMenuPrefab { get; private set; }
        [field: SerializeField] public LosePopup LosePopupPrefab { get; private set; }
        [field: SerializeField] public TutorialPopup TutorialPopupPrefab { get; private set; }

        [field: SerializeField] public PersonComponent[]    PersonPrefabs           { get; private set; }
        [field: SerializeField] public HandWithBagComponent HandWithGroceriesPrefab { get; private set; }
        [field: SerializeField] public BubbleComponent      BubblePrefab            { get; private set; }
    }
}