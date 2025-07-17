using Zenject;

public class GameplaySceneInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<Timer>().FromComponentsInHierarchy().AsTransient();        
    }
}
