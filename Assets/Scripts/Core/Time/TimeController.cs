using UnityEngine;

public class TimeController
{ 
    public void Resume() => Time.timeScale = 1f;

    public void Pause() => Time.timeScale = 0f;

    public void SetTimeScale(float scale) => Time.timeScale = scale;

    private void Awake()
    {
        Debug.Log("TimeController создан");
    }
}