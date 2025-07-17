using UnityEngine;
using UnityEngine.UI;
using Zenject;
using TMPro;

public class Timer : MonoBehaviour
{
    [Header("UI элемент")]
    [SerializeField] private TMP_Text _timerText;    

    [Header("Настройки")]
    [SerializeField] private int _initialTime = 60;
    [SerializeField] private SceneType _nextSceneType = SceneType.None;

    private float _currentTime;
    private ISceneLoader _sceneLoader;


    [Inject]
    public void Construct(ISceneLoader sceneLoader)
    {
        _sceneLoader = sceneLoader;
        _currentTime = _initialTime;
    }


    void Update()
    {
        _currentTime -= Time.deltaTime;
        _timerText.text = $"Left: {Mathf.CeilToInt(_currentTime)} sec.";

        if (_currentTime <= 0)
        {
            LoadNextScene();
        }
    }

    private void LoadNextScene()
    {
        if (_nextSceneType == SceneType.None)
        {
            Debug.LogError("Тип следующей сцены не назначен в таймере!", this);

            return;
        }

        Debug.Log($"Загрузка сцены: {_nextSceneType}");

        _sceneLoader.LoadScene(_nextSceneType);
    }

    private void OnValidate()
    {
        if (_timerText != null && Application.isPlaying == false)
        {
            _timerText.text = $"Осталось {Mathf.CeilToInt(_currentTime)} сек.";
        }
    }
}