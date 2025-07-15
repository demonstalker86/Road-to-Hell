using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class SceneLoader : ISceneLoader
{
    private readonly TimeController _timeController;
    private readonly SceneConfig _sceneConfig;

    [Inject]
    public SceneLoader(TimeController timeController, SceneConfig sceneConfig)
    {
        _timeController = timeController;
        _sceneConfig = sceneConfig;
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);

        ResetTime();
    }

    public void LoadScene(SceneType sceneType)
    {
        string sceneName = _sceneConfig.GetSceneName(sceneType);

        if (string.IsNullOrEmpty(sceneName))
        {
            Debug.LogError($"Название сцены для типа {sceneType} не обанружено!");

            return;
        }

        LoadScene(sceneName);        
    }    

    public void RestartCurrent()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        ResetTime();
    }

    private void ResetTime() => _timeController.Reset();
}
