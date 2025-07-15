using UnityEngine;
using Zenject;

public class SceneButton : MonoBehaviour
{   
    private ISceneLoader _sceneLoader;

    [Inject]
    public SceneButton(ISceneLoader sceneLoader)
    {
        _sceneLoader = sceneLoader;
        Debug.Log("SceneLoader ������������");
    }

    [field: SerializeField] public SceneType SceneType { get; private set; }

    public void OnClick()
    {
        Debug.Log($"�������� ������: {gameObject.name}");

        if (SceneType == SceneType.None)
        {
            Debug.LogError("��� ����� �� �������� � ����������!", this);

            return;
        }

        if (_sceneLoader == null)
        {
            throw new System.NullReferenceException("SceneLoader �� ������������");
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