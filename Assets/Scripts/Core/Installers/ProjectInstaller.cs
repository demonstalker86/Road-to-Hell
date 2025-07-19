using System;
using UnityEngine;
using Zenject;

public class ProjectInstaller : MonoInstaller
{
    [SerializeField] private SceneConfig _sceneConfig;    

    public override void InstallBindings()
    {     
        Debug.Log("Installing bindings...");

        Container.Bind<TimeController>().AsSingle().NonLazy();

        Container.Bind<InfoPanelController>().FromComponentInHierarchy().AsSingle();

        try
        {
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();

            Debug.Log("SceneLoader привязка прошла успешно");
        }
        catch (Exception e)
        {
            Debug.LogError($"Ошибка привязки SceneLoader: {e}");
        }

        Container.Bind<MenuController>()
        .FromComponentInNewPrefabResource("Prefabs/UI/MenuController") // Укажите путь к префабу
        .AsSingle()
        .NonLazy();

        Container.Bind<SceneConfig>().FromInstance(_sceneConfig).AsSingle();
       
        if (_sceneConfig == null)
        {
            Debug.LogError("SceneConfig не присвоен в GameInstaller! Это вызовет ошибки при загрузке сцен.");
            #if UNITY_EDITOR            
            Debug.LogError("Пожалуйста, назначьте SceneConfig в инспекторе GameInstaller");
            UnityEditor.EditorGUIUtility.PingObject(this);
            #endif
        }        
    }   

    #if UNITY_EDITOR
    [ContextMenu("Find All Scene Buttons")]
    private void FindAllSceneButtonsEditor()
    {
        if (UnityEditor.EditorApplication.isPlaying == false)
        {
            #if UNITY_2023_1_OR_NEWER
            var buttons = FindObjectsByType<SceneButton>(
                FindObjectsInactive.Include,
                FindObjectsSortMode.None
            );
            #else
            var buttons = FindObjectsOfType<SceneButton>(true);
            #endif

            Debug.Log($"Найдены {buttons.Length} кнопки сцены в сцене");

            foreach (var button in buttons)
            {
                if (button.SceneType == SceneType.None)
                {
                    Debug.LogWarning($"Кнопка {button.name} не имеет назначенного типа сцены", button);
                }
            }
        }
    }
    #endif
}