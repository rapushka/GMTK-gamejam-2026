using UnityEngine;

namespace Core
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private AssetsProvider _assetsProvider;
        [SerializeField] private Camera _mainCamera;

        private Game _game;

        private void Awake()
        {
            ServiceLocator.Set(_assetsProvider);
            ServiceLocator.Set(new CameraController(_mainCamera));
            ServiceLocator.Set(new InputController());

            _game = new();
        }

        private void Start()
        {
            _game.OnGameLoaded();
        }
    }
}