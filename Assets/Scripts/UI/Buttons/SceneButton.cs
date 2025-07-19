using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class SceneButton : MonoBehaviour
{   
    private ISceneLoader _sceneLoader;
    private Button _button;   

    [Inject]
    public void Construct(ISceneLoader sceneLoader)
    {
        _sceneLoader = sceneLoader;        
    }

    [field: SerializeField] public SceneType SceneType { get; private set; }

    public void OnClick()
    {
        if (_sceneLoader == null)
        {
            _sceneLoader = ProjectContext.Instance.Container.Resolve<ISceneLoader>();
        }

        Debug.Log($"������ ������: {gameObject.name}");

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

    private void Awake()
    {
        _button = GetComponent<Button>();

        _button.onClick.AddListener(OnClick);
    }
}