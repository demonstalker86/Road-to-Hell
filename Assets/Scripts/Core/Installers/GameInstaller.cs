using System;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private SceneConfig _sceneConfig;

    public override void InstallBindings()
    {
        Debug.Log("Installing bindings...");

        Container.Bind<TimeController>().AsSingle();

        try
        {
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();

            Debug.Log("SceneLoader �������� ������ �������");
        }
        catch (Exception e)
        {
            Debug.LogError($"������ �������� SceneLoader: {e}");
        }       

        Container.Bind<MenuController>().FromComponentInHierarchy().AsSingle();

        Container.Bind<SceneButton>().FromComponentsInHierarchy().AsTransient();
        
        Container.Bind<SceneConfig>().FromInstance(_sceneConfig).AsSingle();
       
        if (_sceneConfig == null)
        {
            Debug.LogError("SceneConfig �� �������� � GameInstaller! ��� ������� ������ ��� �������� ����.");
#if UNITY_EDITOR            
            Debug.LogError("����������, ��������� SceneConfig � ���������� GameInstaller");
            UnityEditor.EditorGUIUtility.PingObject(this);
#endif
        }
    }

#if UNITY_EDITOR
    [ContextMenu("Find All Scene Buttons")]
    private void FindAllSceneButtonsEditor()
    {
        var buttons = FindObjectsByType<SceneButton>(
            FindObjectsInactive.Include,
            FindObjectsSortMode.None
        );

        Debug.Log($"������� {buttons.Length} ������ ����� � �����");
        
        foreach (var button in buttons)
        {
            if (button.SceneType == SceneType.None) 
            {
                Debug.LogWarning($"������ {button.name} �� ����� ������������ ���� �����", button);
            }
        }
    }
#endif
}