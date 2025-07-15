using UnityEngine;

public class TimeController
{
    public void Reset() => Time.timeScale = 1f;

    public void Pause() => Time.timeScale = 0f;

    public void SetTimeScale(float scale) => Time.timeScale = scale;
}
