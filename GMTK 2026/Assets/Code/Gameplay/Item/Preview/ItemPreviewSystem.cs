using UnityEngine;

namespace Core
{
    public class ItemPreviewSystem : IService
    {
        private static AssetsProvider       AssetsProvider   => ServiceLocator.Get<AssetsProvider>();
        private static ItemPreviewContainer PreviewContainer => ServiceLocator.Get<ItemPreviewContainer>();

        private Item3DPreview _currentPreview;

        private Vector2 _lastMousePoint;
        private bool _isRotating;

        public bool IsShowing { get; private set; }

        public void Show(Item item)
        {
            var config = AssetsProvider.Items.GetItem(item.Key);
            _currentPreview = Object.Instantiate(config.ItemPrefab3D, PreviewContainer.transform);
            IsShowing = true;
        }

        public void StartRotate(Vector2 mouseScreenPoint)
        {
            _isRotating = true;
            _lastMousePoint = mouseScreenPoint;
        }

        public void Rotate(Vector2 mouseScreenPoint)
        {
            if (!_isRotating || !IsShowing)
                return;

            var delta = mouseScreenPoint - _lastMousePoint;
            _lastMousePoint = mouseScreenPoint;

            const float sense = Constants.PreviewRotateSensitivity;
            _currentPreview.transform.Rotate(Vector3.up, -delta.x * sense, Space.World);
            _currentPreview.transform.Rotate(Vector3.right, delta.y * sense, Space.World);
        }

        public void EndRotate()
        {
            _isRotating = false;
        }

        public void Hide()
        {
            IsShowing = false;
            EndRotate();
            if (_currentPreview == null)
                return;

            Object.Destroy(_currentPreview.gameObject);
            _currentPreview = null;
        }
    }
}