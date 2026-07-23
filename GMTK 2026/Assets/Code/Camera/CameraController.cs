using UnityEngine;

namespace Core
{
    public class CameraController : IService
    {
        private readonly Camera _mainCamera;

        public CameraController(Camera mainCamera)
        {
            _mainCamera = mainCamera;
        }

        public Collider2D OverlapScreenPoint(Vector3 screenPoint)
        {
            var worldPoint = _mainCamera.ScreenToWorldPoint(screenPoint);
            var hit = Physics2D.OverlapPoint(worldPoint);
            return hit;
        }
    }
}