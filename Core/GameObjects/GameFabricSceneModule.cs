using Cysharp.Threading.Tasks;
using MothDIed.Scenes;
using MothDIed.Scenes.SceneModules;
using UnityEngine;

namespace MothDIed.Core.GameObjects
{
    public class GameFabricSceneModule : SceneModule
    {
        public override void StartModule(Scene scene)
            => scene.Fabric.RefreshModules();

        public virtual async UniTask OnInstantiated<TObject>(TObject instance) where TObject : Object { }
        public virtual async UniTask OnWillBeDestroyed(Object toDestroy) { }
    }
}
