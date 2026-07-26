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

        public Vector3 WorldToScreen(Vector3 worldPoint)
        {
            return _mainCamera.WorldToScreenPoint(worldPoint);
        }

        public Vector3 ScreenToPreviewWorld(Vector2 screenPoint, float worldZ)
        {
            var ray = _previewCamera.ScreenPointToRay(screenPoint);
            var plane = new Plane(Vector3.forward, new Vector3(0f, 0f, worldZ));
            plane.Raycast(ray, out var enter);
            return ray.GetPoint(enter);
        }

        public float GetScreenHeight(Bounds worldBounds, bool usePreviewCamera)
        {
            var cam = usePreviewCamera ? _previewCamera : _mainCamera;
            var top = cam.WorldToScreenPoint(worldBounds.center + Vector3.up * worldBounds.extents.y);
            var bottom = cam.WorldToScreenPoint(worldBounds.center - Vector3.up * worldBounds.extents.y);
            return Mathf.Abs(top.y - bottom.y);
        }

        public bool IsPointerOnPreview(Vector2 screenPoint)
        {
            var ray = _previewCamera.ScreenPointToRay(screenPoint);

            return Physics.Raycast(ray, out var hit)
                && hit.collider.TryGetComponent<Item3DPreview>(out _);
        }
    }
}
