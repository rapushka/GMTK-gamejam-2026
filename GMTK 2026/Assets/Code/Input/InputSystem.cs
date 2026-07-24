using UnityEngine;
using UnityEngine.InputSystem;

namespace Core
{
    public class InputSystem : IService
    {
        private Item _draggedItem;
        private Vector2 _mouseWorldPosition;

        private static CameraSystem CameraSystem => ServiceLocator.Get<CameraSystem>();

        public void OnUpdate()
        {
            var mouse = Mouse.current;
            _mouseWorldPosition = CameraSystem.ScreenToWorld(mouse.position.ReadValue());

            if (mouse.leftButton.wasPressedThisFrame)
                OnMouseDown();
        }

        private void OnMouseDown()
        {
            var mouse = Mouse.current;

            var hit = Physics2D.OverlapPoint(_mouseWorldPosition);

            if (hit != null && hit.TryGetComponent(out Item item))
            {
                _draggedItem = item;
                _draggedItem.StartDrag(_mouseWorldPosition);
            }

            // var screen = mouse.position.ReadValue();
            // var pressed = mouse.leftButton.isPressed;
            // var justPressed = mouse.leftButton.wasPressedThisFrame;
            // var justReleased = mouse.leftButton.wasReleasedThisFrame;
        }
    }
}