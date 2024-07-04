using MothDIed.DI;
using UnityEngine;

namespace Sample
{
    public sealed class DefaultMovement : MovementLogic
    {
        [Inject] private PlayerAnimatorsContainer animatorsContainer;
        
        public override void Move(Vector2 movement, PlayerController playerController)
        {
            if(playerController.CachedComponents.Get<Animator>().runtimeAnimatorController != animatorsContainer.DefaultAnimator)
            {
                playerController.CachedComponents.Get<Animator>().runtimeAnimatorController =
                    animatorsContainer.DefaultAnimator;
            }

            playerController.CachedComponents.Get<Rigidbody2D>().velocity = movement;
            playerController.CachedComponents.Get<Animator>().SetBool("Move", IsMoving());

            bool IsMoving()
            {
                return playerController.CachedComponents.Get<Rigidbody2D>().velocity != Vector2.zero;
            }
        }
    }
}