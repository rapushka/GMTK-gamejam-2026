using UnityEngine;

namespace Core
{
    public class CameraSystem : IService
    {
        private readonly Camera _mainCamera;

        public CameraSystem(Camera mainCamera)
        {
            _mainCamera = mainCamera;
        }

        public Vector2 ScreenToWorld(Vector2 screenPoint)
        {
            return _mainCamera.ScreenToWorldPoint(screenPoint);
        }
    }
}