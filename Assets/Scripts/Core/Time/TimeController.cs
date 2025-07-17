using UnityEngine;
using Zenject;

public class TimeController : IInitializable
{
    public void Initialize()
    {
        Debug.Log("TimeController инициализирован");
    }

    public void Resume() => Time.timeScale = 1f;

    public void Pause() => Time.timeScale = 0f;

    public void SetTimeScale(float scale) => Time.timeScale = scale;
}   