using System;
using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    [SerializeField] private SceneConfig _sceneConfig;

    public override void InstallBindings()
    {
        Debug.Log("Installing bindings...");

        Container.Bind<TimeController>().AsSingle();

        try
        {
            Container.Bind<ISceneLoader>().To<SceneLoader>().FromNew().AsSingle();

            Debug.Log("SceneLoader �������� ������ �������");
        }
        catch (Exception e)
        {
            Debug.LogError($"������ �������� SceneLoader: {e}");
        }       

        Container.Bind<MenuController>().FromComponentInHierarchy().AsSingle();        
        
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
        #if UNITY_2023_1_OR_NEWER
        var buttons = FindObjectsByType<SceneButton>(
            FindObjectsInactive.Include,
            FindObjectsSortMode.None
        );
        #else
        var buttons = FindObjectsOfType<SceneButton>(true);
        #endif

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