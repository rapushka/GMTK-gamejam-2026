using System;
using UnityEngine;

namespace Core
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private AssetsProvider _assetsProvider;
        [SerializeField] private Camera _mainCamera;
        [SerializeField] private UiRoot _uiRoot;

        private Game _game;

        private void Awake()
        {
            ServiceLocator.Set(_assetsProvider);
            ServiceLocator.Set(new CameraSystem(_mainCamera));
            ServiceLocator.Set(new InputSystem());
            ServiceLocator.Set(new ScreensMediator());
            ServiceLocator.Set(new ItemSpawnSystem());
            ServiceLocator.Set(_uiRoot);

            _game = new();
        }

        private void Start()
        {
            _game.OnGameLoaded();
        }

        private void Update()
        {
            _game.OnUpdate();
        }
    }
}