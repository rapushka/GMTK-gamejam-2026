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

            else if (_draggedItem != null && Mouse.current.leftButton.isPressed)
                Drag();

            else if (mouse.leftButton.wasReleasedThisFrame)
                OnMouseUp();
        }

        private void OnMouseDown()
        {
            if (!PhysicsUtils.TryGetComponentAtPoint(_mouseWorldPosition, out Item item))
                return;

            _draggedItem = item;
            _draggedItem.StartDrag(_mouseWorldPosition);
        }

        private void Drag()
        {
            _draggedItem.Drag(_mouseWorldPosition);
        }

        private void OnMouseUp()
        {
            if (_draggedItem != null)
            {
                _draggedItem.EndDrag();
                _draggedItem = null;
            }
        }
    }
}