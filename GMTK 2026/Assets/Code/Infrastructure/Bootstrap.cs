using UnityEngine;

namespace Core
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private AssetsProvider _assetsProvider;
        [SerializeField] private Camera _mainCamera;
        [SerializeField] private Camera _previewCamera;
        [SerializeField] private UiRoot _uiRoot;
        [SerializeField] private BalanceConfig _balanceConfig;
        [SerializeField] private ItemPreviewContainer _previewContainer;
        [SerializeField] private AudioPlayer _audioPlayer;

        private Game _game;

        private void Awake()
        {
            ServiceLocator.Set(_assetsProvider);
            ServiceLocator.Set(new CameraSystem(_mainCamera, _previewCamera));
            ServiceLocator.Set(new InputSystem());
            ServiceLocator.Set(new ScreensMediator());
            ServiceLocator.Set(new ItemSpawnSystem());
            ServiceLocator.Set(new UIMediator());
            ServiceLocator.Set(_uiRoot);
            ServiceLocator.Set(new CalendarSystem());
            ServiceLocator.Set(_balanceConfig);
            ServiceLocator.Set(new ItemPreviewSystem());
            ServiceLocator.Set(_previewContainer);
            ServiceLocator.Set(new LivesSystem());
            ServiceLocator.Set(new PeopleArriveSystem());
            ServiceLocator.Set(new ItemsContainer());
            ServiceLocator.Set(_audioPlayer);

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