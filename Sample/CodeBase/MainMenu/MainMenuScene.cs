using MothDIed.GUI;
using MothDIed.Scenes;

namespace Sample
{
    public sealed class MainMenuScene : Scene 
    {
        public override string GetSceneName()
            => "MainMenu";

        protected override void SetupModules()
        { 
            Modules.AddModule(new SceneGUIModule(true));
        }
    }
}