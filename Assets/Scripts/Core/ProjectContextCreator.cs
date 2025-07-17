using UnityEngine;
using Zenject;

public class ProjectContextCreator : MonoBehaviour
{
    [SerializeField] private GameObject _projectContextPrefab;

    private void Awake()
    {        
        if (FindAnyObjectByType<ProjectContext>(FindObjectsInactive.Include) != null)
            return;

        if (_projectContextPrefab == null)
        {
            Debug.LogError("Префаб ProjectContext не назначен!");
            return;
        }
        
        var instance = Instantiate(_projectContextPrefab);
        instance.transform.SetParent(null);
        DontDestroyOnLoad(instance);

        Debug.Log("ProjectContext успешно создан как корневой объект");
    }
}
