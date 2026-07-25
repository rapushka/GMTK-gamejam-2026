using UnityEngine.InputSystem;

namespace Core
{
    public class PreviewInputMixin
    {
        private static ItemPreviewSystem ItemPreview  => ServiceLocator.Get<ItemPreviewSystem>();
        private static CameraSystem      CameraSystem => ServiceLocator.Get<CameraSystem>();

        public void HandleInput(Mouse mouse)
        {
            var mouseScreenPoint = mouse.position.ReadValue();

            if (mouse.leftButton.wasPressedThisFrame)
            {
                if (CameraSystem.IsPointerOnPreview(mouseScreenPoint))
                    ItemPreview.StartRotate(mouseScreenPoint);
                else
                    ItemPreview.Hide();

                return;
            }

            if (mouse.leftButton.isPressed)
            {
                ItemPreview.Rotate(mouseScreenPoint);
                return;
            }

            ItemPreview.EndRotate();
        }
    }
}