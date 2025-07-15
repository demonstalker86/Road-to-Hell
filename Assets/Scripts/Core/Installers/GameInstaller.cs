using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private SceneConfig _sceneConfig;

    public override void InstallBindings()
    {
        Container.Bind<TimeController>().AsSingle();

        Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();

        if (_sceneConfig != null)
        {
            Container.BindInstance(_sceneConfig);
        }
    }
}
