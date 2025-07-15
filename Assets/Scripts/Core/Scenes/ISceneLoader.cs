using UnityEngine;

public interface ISceneLoader
{
    void LoadScene(string name);

    void LoadScene(SceneType sceneType);

    void RestartCurrent();
}