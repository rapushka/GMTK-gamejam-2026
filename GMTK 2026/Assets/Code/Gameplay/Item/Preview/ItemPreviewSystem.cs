using DG.Tweening;
using UnityEngine;

namespace Core
{
    public class ItemPreviewSystem : IService
    {
        private static AssetsProvider       AssetsProvider   => ServiceLocator.Get<AssetsProvider>();
        private static ItemPreviewContainer PreviewContainer => ServiceLocator.Get<ItemPreviewContainer>();
        private static CameraSystem         CameraSystem     => ServiceLocator.Get<CameraSystem>();

        private Item _sourceItem;
        private Item3DPreview _currentPreview;

        private Vector3 _appearFromPosition;
        private Vector3 _appearFromScale;
        private Quaternion _appearFromRotation;

        private Vector3 _appearToPosition;
        private Vector3 _appearToScale;
        private Quaternion _appearToRotation;

        private Tween _activeTween;
        private bool _isAnimating;
        private bool _isHiding;

        private Vector2 _lastMousePoint;
        private bool _isRotating;

        public bool IsShowing { get; private set; }

        public void Show(Item item)
        {
            KillTween();

            var itemBounds = item.Bounds;

            _sourceItem = item;
            item.gameObject.SetActive(false);

            var config = AssetsProvider.Items.GetItem(item.Key);
            _currentPreview = Object.Instantiate(config.ItemPrefab3D, PreviewContainer.transform);
            _currentPreview.Init(item);

            CaptureAppearToPose();
            CaptureAppearFromPose(itemBounds);

            var t = _currentPreview.transform;
            t.position = _appearFromPosition;
            t.localScale = _appearFromScale;
            t.rotation = _appearFromRotation;

            IsShowing = true;
            _isHiding = false;
            PlayAppear();
            PreviewContainer.Show();
        }

        public void StartRotate(Vector2 mouseScreenPoint)
        {
            if (_isAnimating)
                return;

            _isRotating = true;
            _lastMousePoint = mouseScreenPoint;
        }

        public void Rotate(Vector2 mouseScreenPoint)
        {
            if (!_isRotating || !IsShowing || _isAnimating)
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
            if (!IsShowing || _isHiding)
                return;

            EndRotate();
            _isHiding = true;
            PlayHide();
            PreviewContainer.Hide();
        }

        public void HideInstantIfPreviewing(Item item)
        {
            if (!IsShowing || _sourceItem != item)
                return;

            Cleanup(restoreSource: false);
        }

        private void CaptureAppearToPose()
        {
            var t = _currentPreview.transform;
            _appearToPosition = t.position;
            _appearToScale = t.localScale;
            _appearToRotation = Quaternion.Euler(
                Random.Range(-Constants.PreviewAppearRotationXZ, Constants.PreviewAppearRotationXZ),
                Random.Range(-Constants.PreviewAppearRotationY, Constants.PreviewAppearRotationY),
                Random.Range(-Constants.PreviewAppearRotationXZ, Constants.PreviewAppearRotationXZ)
            );
        }

        private void CaptureAppearFromPose(Bounds itemBounds)
        {
            var screenPoint = CameraSystem.WorldToScreen(itemBounds.center);
            _appearFromPosition = CameraSystem.ScreenToPreviewWorld(
                screenPoint,
                PreviewContainer.transform.position.z
            );
            _appearFromRotation = Quaternion.identity;
            _appearFromScale = Vector3.one * ComputeStartScale(itemBounds);
        }

        private float ComputeStartScale(Bounds itemBounds)
        {
            var itemScreenHeight = CameraSystem.GetScreenHeight(itemBounds, usePreviewCamera: false);

            var col = _currentPreview.GetComponent<BoxCollider>();
            var previewBounds = new Bounds(
                _appearFromPosition + col.center,
                col.size
            );
            var previewScreenHeight = CameraSystem.GetScreenHeight(previewBounds, usePreviewCamera: true);

            return itemScreenHeight / previewScreenHeight;
        }

        private void PlayAppear()
        {
            KillTween();
            _isAnimating = true;

            var t = _currentPreview.transform;
            _activeTween = DOTween.Sequence()
                .Join(t.DOMove(_appearToPosition, Constants.PreviewAppearDuration).SetEase(Ease.OutCubic))
                .Join(t.DOScale(_appearToScale, Constants.PreviewAppearDuration).SetEase(Ease.OutCubic))
                .Join(t.DORotateQuaternion(_appearToRotation, Constants.PreviewAppearDuration).SetEase(Ease.OutCubic))
                .OnComplete(() => _isAnimating = false);
        }

        private void PlayHide()
        {
            KillTween();
            _isAnimating = true;

            var t = _currentPreview.transform;
            _activeTween = DOTween.Sequence()
                .Join(t.DOMove(_appearFromPosition, Constants.PreviewAppearDuration).SetEase(Ease.InCubic))
                .Join(t.DOScale(_appearFromScale, Constants.PreviewAppearDuration).SetEase(Ease.InCubic))
                .Join(t.DORotateQuaternion(_appearFromRotation, Constants.PreviewAppearDuration).SetEase(Ease.InCubic))
                .OnComplete(() => Cleanup(restoreSource: true));
        }

        private void Cleanup(bool restoreSource)
        {
            KillTween();
            EndRotate();
            _isAnimating = false;
            _isHiding = false;

            if (_currentPreview != null)
            {
                Object.Destroy(_currentPreview.gameObject);
                _currentPreview = null;
            }

            if (restoreSource)
                _sourceItem.gameObject.SetActive(true);

            _sourceItem = null;
            IsShowing = false;
        }

        private void KillTween()
        {
            _activeTween?.Kill();
            _activeTween = null;
        }
    }
}