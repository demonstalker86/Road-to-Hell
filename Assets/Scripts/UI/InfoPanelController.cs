using UnityEngine;
using Zenject;

public class InfoPanelController : MonoBehaviour
{
    [SerializeField] private GameObject _infoPanel;

    private TimeController _timeController;

    [Inject]
    private void Construct(TimeController timeController)
    {
        _timeController = timeController;

        Debug.Log("TimeController ��������");
    }

    private void Start()
    {        
        if (_infoPanel == null)
        {
            Debug.LogError("Info Panel �� ��������� � ����������!", this);

            return;
        }
        
        _infoPanel.SetActive(true);
    }

    public void ToggleInfoPanel()
    {        
        if (_infoPanel == null)
        {
            Debug.LogError("Info Panel �� ��������� � ����������!", this);

            return;
        }

        bool isActive = _infoPanel.activeSelf == false;

        _infoPanel.SetActive(isActive);
        
        if (_timeController == null)
        {
            Debug.LogError("TimeController �� ������������!", this);

            return;
        }

        if (isActive)
        {
            _timeController.Pause();
        }
        else
        {
            _timeController.Resume();
        }            
    }
}