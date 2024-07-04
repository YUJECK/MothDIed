using Cysharp.Threading.Tasks;
using MothDIed.Core.GameObjects;
using UnityEngine;

namespace MothDIed.GameObjects
{
    public sealed class DestroyDelayGameFabricModule : GameFabricSceneModule
    {
        public override async UniTask OnWillBeDestroyed(Object toDestroy)
        {
            GameObject gameObject = toDestroy as GameObject;

            if (gameObject == null)
            {
                return;
            }

            if (gameObject.TryGetComponent(out DestroyDelay destroyDelay))
            {
                var behaviours = gameObject.GetComponentsInChildren<IWillBeDestroyed>();
                
                foreach (var behaviour in behaviours)
                {
                    behaviour.WillBeDestroyed();
                }
                
                await destroyDelay.Destroy();
            }
        }
    }
}