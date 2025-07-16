using UnityEngine;
using Zenject;

public class SceneButton : MonoBehaviour
{   
    private ISceneLoader _sceneLoader;
    private bool _isInjected = false;

    [field: SerializeField] public SceneType SceneType { get; private set; }

    [Inject]
    public void Construct(ISceneLoader sceneLoader)
    {
        _sceneLoader = sceneLoader;
        _isInjected = true;
    }

    public void OnClick()
    {
        if (!_isInjected)
        {
            Debug.LogError("Попытка использования до инъекции!");

            return;
        }

        Debug.Log($"Щелкнула кнопка: {gameObject.name}");

        if (_sceneLoader == null)
        {
            Debug.LogError("SceneLoader все еще null!");

            return;
        }

        if (SceneType == SceneType.None)
        {
            Debug.LogError("Тип сцены не назначен в инспекторе!", this);

            return;
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