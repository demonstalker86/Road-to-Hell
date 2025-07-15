using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;
using System.Collections.Generic;

public class SceneLoader : ISceneLoader
{
    private readonly TimeController _timeController;
    private readonly SceneConfig _sceneConfig;
    private readonly Dictionary<string, bool> _sceneValidityCache = new();

    [Inject]
    public SceneLoader(TimeController timeController, SceneConfig sceneConfig)
    {
        _timeController = timeController;
        _sceneConfig = sceneConfig;
    }

    public void LoadScene(string sceneName)
    {
        if (!IsSceneValid(sceneName))
        {
            LogSceneError(sceneName);

            return;
        }

        SceneManager.LoadScene(sceneName);

        ResetTime();
    }

    public void LoadScene(SceneType sceneType)
    {
        string sceneName = _sceneConfig.GetSceneName(sceneType);

        if (sceneType == 0) 
        {
            Debug.LogError("Попытка загрузить сцену с типом None!");

            return;
        }

        LoadScene(sceneName);
    }

    public void RestartCurrent()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentIndex);

        ResetTime();
    }

    private void ResetTime() => _timeController.Resume();

    private bool IsSceneValid(string sceneName)
    {        
        if (_sceneValidityCache.TryGetValue(sceneName, out bool isValid))
        {
            return isValid;
        }
       
        isValid = Application.CanStreamedLevelBeLoaded(sceneName);
#if UNITY_EDITOR        
        if (!isValid)
        {
            isValid = SceneManager.sceneCountInBuildSettings > 0 &&
                      GetBuildScenes().Contains(sceneName);
        }
#endif

        _sceneValidityCache[sceneName] = isValid;
        return isValid;
    }

    private void LogSceneError(string invalidScene)
    {
        var buildScenes = GetBuildScenes();
        string errorMessage = $"Сцена \"{{invalidScene}}\" не найдена в настройках сборки!\n" +
                              "Доступные сцены:\n" +
                              string.Join("\n", buildScenes);

        Debug.LogError(errorMessage);

#if UNITY_EDITOR
        if (Application.isPlaying == false)
        {
            UnityEditor.EditorUtility.DisplayDialog(
                "Ошибка загрузки сцены",
                errorMessage,
                "OK"
            );
        }
#endif
    }

    private HashSet<string> GetBuildScenes()
    {
        var scenes = new HashSet<string>();

        for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            string path = SceneUtility.GetScenePathByBuildIndex(i);

            scenes.Add(System.IO.Path.GetFileNameWithoutExtension(path));
        }

        return scenes;
    }
}