using UnityEngine;

namespace Sample.InputSystem
{
    public interface IInputService
    {
        Vector2 GetMovement();
        bool RightClick();
    }
}