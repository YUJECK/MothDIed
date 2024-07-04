using MothDIed.DI;
using MothDIed;
using Sample.InputSystem;
using UnityEngine;

namespace Sample
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Animator))]
    public class PlayerController : DepressedBehaviour
    {
        [Inject] private MovementLogic movementLogic;
        [Inject] private IInputService input;

        private void Awake()
        {
            CachedComponents.Register(GetComponent<Rigidbody2D>());
            CachedComponents.Register(GetComponent<Animator>());
        }

        private void Update()
        {
            movementLogic.Move(input.GetMovement(), this);
        }
    }
}
