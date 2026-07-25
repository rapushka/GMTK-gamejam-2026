using UnityEngine;
using UnityEngine.InputSystem;

namespace Core
{
    public class InputSystem : IService
    {
        private static CameraSystem      CameraSystem => ServiceLocator.Get<CameraSystem>();
        private static ItemPreviewSystem ItemPreview  => ServiceLocator.Get<ItemPreviewSystem>();

        private readonly DragAndDropInputMixin _dragAndDrop = new();
        private readonly DoubleClickInputMixin _itemDoubleClick = new();
        private readonly PreviewInputMixin _preview = new();

        private Vector2 _mouseWorldPosition;

        public void OnUpdate()
        {
            var mouse = Mouse.current;
            _mouseWorldPosition = CameraSystem.ScreenToWorld(mouse.position.ReadValue());

            if (ItemPreview.IsShowing)
            {
                _preview.HandleInput(mouse);
                return;
            }

            if (mouse.leftButton.wasPressedThisFrame)
                OnMouseDown();

            else if (_dragAndDrop.IsDragging && mouse.leftButton.isPressed)
                _dragAndDrop.Update(_mouseWorldPosition);

            else if (mouse.leftButton.wasReleasedThisFrame)
                _dragAndDrop.End();
        }

        private void OnMouseDown()
        {
            if (!PhysicsUtils.TryGetComponentAtPoint(_mouseWorldPosition, out Item item))
                return;

            if (_itemDoubleClick.TryHandle(item))
                return;

            _dragAndDrop.Begin(item, _mouseWorldPosition);
        }
    }
}