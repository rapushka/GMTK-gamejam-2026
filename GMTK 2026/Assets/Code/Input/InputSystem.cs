using UnityEngine;
using UnityEngine.InputSystem;

namespace Core
{
    public class InputSystem : IService
    {
        private static CameraSystem      CameraSystem      => ServiceLocator.Get<CameraSystem>();
        private static ItemPreviewSystem ItemPreviewSystem => ServiceLocator.Get<ItemPreviewSystem>();

        private Item _draggedItem;
        private Item _lastClickedItem;
        private Vector2 _mouseWorldPosition;

        private float _lastClickTime;

        private bool IsUnderDoubleClickThreshold => Time.time - _lastClickTime < Constants.DoubleClickThreshold;

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

            if (item == _lastClickedItem && IsUnderDoubleClickThreshold)
            {
                OnItemDoubleClicked();
                return;
            }

            _lastClickTime = Time.time;
            _lastClickedItem = item;
            _draggedItem = item;
            _draggedItem.StartDrag(_mouseWorldPosition);
        }

        private void OnItemDoubleClicked()
        {
            ItemPreviewSystem.Show(_lastClickedItem);
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