using UnityEngine.InputSystem;

namespace Core
{
    public class InputController : IService
    {
        public void OnUpdate()
        {
            var screen = Mouse.current.position.ReadValue();
            var pressed = Mouse.current.leftButton.isPressed;
            var justPressed = Mouse.current.leftButton.wasPressedThisFrame;
            var justReleased = Mouse.current.leftButton.wasReleasedThisFrame;
        }
    }
}