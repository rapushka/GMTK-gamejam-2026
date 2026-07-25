using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Core
{
    [Serializable]
    public class AssetsProvider : IService
    {
        [field: SerializeField] public GameScreen  GameScreenPrefab  { get; private set; }
        [field: SerializeField] public GameplayHUD GameplayHUDPrefab { get; private set; }

        [field: SerializeField] public ItemsCollection Items { get; private set; }
        [field: SerializeField] public MainMenu MainMenuPrefab { get; private set; }
    }
}