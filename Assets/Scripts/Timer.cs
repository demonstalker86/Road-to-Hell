using UnityEngine;
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
    private bool _isInitialized = false;


    [Inject]
    public void Construct(ISceneLoader sceneLoader)
    {
        _sceneLoader = sceneLoader;
        _currentTime = _initialTime;
        _isInitialized = true;

        UpdateTimerText();
    }


    void Update()
    {
        if (!_isInitialized) 
        {
            return;
        }

        _currentTime -= Time.deltaTime;

        UpdateTimerText();

        if (_currentTime <= 0)
        {
            LoadNextScene();
        }
    }

    private void UpdateTimerText()
    {
        if (_timerText != null)
        {
            _timerText.text = $"Осталось {Mathf.CeilToInt(_currentTime)} сек.";
        }
    }

    private void LoadNextScene()
    {
        if (!_isInitialized)
        {
            Debug.LogWarning("Попытка загрузки сцены до инициализации таймера");

            return;
        }

        if (_nextSceneType == SceneType.None)
        {
            Debug.LogError("Тип следующей сцены не назначен в таймере!", this);

            return;
        }

        if (_sceneLoader == null)
        {
            Debug.LogError("SceneLoader не был инъектирован!");
            #if UNITY_EDITOR
           
            if (ProjectContext.HasInstance)
            {
                _sceneLoader = ProjectContext.Instance.Container.Resolve<ISceneLoader>();
            }
            #endif
        }

        if (_sceneLoader != null)
        {
            Debug.Log($"Загрузка сцены: {_nextSceneType}");

            _sceneLoader.LoadScene(_nextSceneType);
        }
        else
        {
            Debug.LogError("Не удалось получить SceneLoader!");
        }
    }

    private void OnValidate()
    {
        if (_timerText != null)
        {
            _timerText.text = $"Осталось {_initialTime} сек.";
        }
    }
}