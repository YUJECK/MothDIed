using MothDIed;
using MothDIed.DI;
using Sample;
using UnityEngine;

public class GameStartPoint : MonoBehaviour
{
    public IDependenciesProvider[] DependenciesProviders = {};

    private void Start()
    {
        Game.Injector.RegisterDependenciesToCore(this);
        
        Game.SwitchTo(new MainMenuScene());
    }
}