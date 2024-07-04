using MothDIed.GameObjects;
using UnityEngine;

namespace MothDIed.Scenes
{
    public class CommonScene : Scene
    {
        public override string GetSceneName()
            => "Scene1";

        public override Camera GetCamera()
            => null;

        protected override void SetupModules()
        {
            Modules.AddModule(new DestroyDelayGameFabricModule());
        }
    }
}