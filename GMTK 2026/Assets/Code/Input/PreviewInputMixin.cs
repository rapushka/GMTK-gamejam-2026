using UnityEngine;
using UnityEngine.InputSystem;

namespace Core
{
    public class PreviewInputMixin
    {
        private const float ClickMoveThreshold = 4f;

        private static ItemPreviewSystem ItemPreview  => ServiceLocator.Get<ItemPreviewSystem>();
        private static CameraSystem      CameraSystem => ServiceLocator.Get<CameraSystem>();

        private Vector2 _pressPoint;
        private bool _pressOffModel;
        private bool _dragStarted;

        public void HandleInput(Mouse mouse)
        {
            var mouseScreenPoint = mouse.position.ReadValue();

            if (mouse.leftButton.wasPressedThisFrame)
            {
                _pressPoint = mouseScreenPoint;
                _dragStarted = false;
                _pressOffModel = !CameraSystem.IsPointerOnPreview(mouseScreenPoint);

                if (!_pressOffModel)
                    ItemPreview.StartRotate(mouseScreenPoint);

                return;
            }

            if (mouse.leftButton.isPressed)
            {
                if (!_dragStarted && Vector2.Distance(_pressPoint, mouseScreenPoint) > ClickMoveThreshold)
                {
                    _dragStarted = true;

                    if (_pressOffModel)
                        ItemPreview.StartRotate(_pressPoint);
                }

                ItemPreview.Rotate(mouseScreenPoint);
                return;
            }

            if (mouse.leftButton.wasReleasedThisFrame
                && _pressOffModel
                && !_dragStarted)
            {
                ItemPreview.Hide();
                return;
            }

            ItemPreview.EndRotate();
        }
    }
}
