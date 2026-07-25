using UnityEngine;

namespace Core
{
    public class CameraSystem : IService
    {
        private readonly Camera _mainCamera;
        private readonly Camera _previewCamera;

        public CameraSystem(Camera mainCamera, Camera previewCamera)
        {
            _mainCamera = mainCamera;
            _previewCamera = previewCamera;
        }

        public Vector2 ScreenToWorld(Vector2 screenPoint)
        {
            return _mainCamera.ScreenToWorldPoint(screenPoint);
        }

        public bool IsPointerOnPreview(Vector2 screenPoint)
        {
            var ray = _previewCamera.ScreenPointToRay(screenPoint);

            return Physics.Raycast(ray, out var hit)
                && hit.collider.TryGetComponent<Item3DPreview>(out _);
        }
    }
}