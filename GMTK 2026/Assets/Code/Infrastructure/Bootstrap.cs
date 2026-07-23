using UnityEngine;

namespace Core
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private AssetsProvider _assetsProvider;

        private Game _game;

        private void Awake()
        {
            ServiceLocator.Set(_assetsProvider);

            _game = new();
        }

        private void Start()
        {
            _game.OnGameLoaded();
        }
    }
}