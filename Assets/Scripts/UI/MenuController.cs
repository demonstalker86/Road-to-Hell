using UnityEngine;
using Zenject;

public class MenuController : MonoBehaviour
{
    private  ISceneLoader _sceneLoader;
    private  TimeController _timeController;

    [Inject]
    private void Construct(ISceneLoader sceneLoader, TimeController timeController)
    {
        _sceneLoader = sceneLoader ?? throw new System.ArgumentNullException(nameof(sceneLoader));
        _timeController = timeController ?? throw new System.ArgumentNullException(nameof(timeController));
    }

    public void LoadScene(string sceneName)
    {
        _timeController.Resume(); 
        _sceneLoader.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Debug.Log("Выход из приложения...");

        Application.Quit();

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    public void Restart() => _sceneLoader.RestartCurrent();

    public void TogglePause(bool isPaused)
    {
        if (isPaused)
        {
            _timeController.Pause();
        }
        else
        { 
            _timeController.Resume();
        }
    }
}