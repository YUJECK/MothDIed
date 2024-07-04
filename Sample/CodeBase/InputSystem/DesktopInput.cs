using UnityEngine;

namespace Sample.InputSystem
{
    public sealed class DesktopInput : IInputService
    {
        public Vector2 GetMovement()
        {
            Vector2 movement;
            
            movement.x = Input.GetAxis("Horizontal");
            movement.y = Input.GetAxis("Vertical");

            return movement;
        }

        public bool RightClick()
        {
            return Input.GetMouseButtonDown(1);
        }
    }
}