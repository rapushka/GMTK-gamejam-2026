using UnityEngine.InputSystem;

namespace Core
{
    public class PreviewInputMixin
    {
        private static ItemPreviewSystem ItemPreview => ServiceLocator.Get<ItemPreviewSystem>();

        public void HandleInput(Mouse mouse)
        {
            if (mouse.leftButton.wasPressedThisFrame)
                ItemPreview.StartRotate(mouse.position.ReadValue());

            else if (mouse.leftButton.isPressed)
                ItemPreview.Rotate(mouse.position.ReadValue());

            else
                ItemPreview.EndRotate();
        }
    }
}