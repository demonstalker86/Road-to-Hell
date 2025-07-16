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
            Debug.LogError("������� ������������� �� ��������!");

            return;
        }

        Debug.Log($"�������� ������: {gameObject.name}");

        if (_sceneLoader == null)
        {
            Debug.LogError("SceneLoader ��� ��� null!");

            return;
        }

        if (SceneType == SceneType.None)
        {
            Debug.LogError("��� ����� �� �������� � ����������!", this);

            return;
        }       

        Debug.Log($"�������� �����: {SceneType}");

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