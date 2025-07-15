using UnityEngine;
using Zenject;

public class SceneButton : MonoBehaviour
{   
    private ISceneLoader _sceneLoader;

    [Inject]
    public SceneButton(ISceneLoader sceneLoader)
    {
        _sceneLoader = sceneLoader;
        Debug.Log("SceneLoader инжектирован");
    }

    [field: SerializeField] public SceneType SceneType { get; private set; }

    public void OnClick()
    {
        Debug.Log($"Щелкнула кнопка: {gameObject.name}");

        if (SceneType == SceneType.None)
        {
            Debug.LogError("Тип сцены не назначен в инспекторе!", this);

            return;
        }

        if (_sceneLoader == null)
        {
            throw new System.NullReferenceException("SceneLoader не инжектирован");
        }

        Debug.Log($"Загрузка сцены: {SceneType}");

        _sceneLoader.LoadScene(SceneType);
    }

    private void OnValidate()
    {
        if (TryGetComponent<UnityEngine.UI.Button>(out var button) && Application.isPlaying == false)
        {            
            button.onClick.RemoveAllListeners();
           
            button.onClick.AddListener(OnClick);
        }
    }
}