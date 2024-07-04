using UnityEngine;

namespace Sample
{
    public abstract class MovementLogic
    {
        public abstract void Move(Vector2 movement, PlayerController playerController);
    }   
}