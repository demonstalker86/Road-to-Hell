using UnityEngine;
using Zenject;

public class InfoPanelController : MonoBehaviour
{
    [SerializeField, Tooltip("���������� ������ InfoPanel ����")]
    private GameObject _infoPanel;

    [Inject] private TimeController _timeController;    

    private void Start()
    {           
        if (_infoPanel == null)
        {
            Debug.LogError("InfoPanel �� ���������!", this);

            enabled = false;
            return;
        }       

        _infoPanel.SetActive(true);
    }    

    public void ToggleInfoPanel()
    {
        if (isActiveAndEnabled == false || _infoPanel == false)
        {
            return;
        }

        bool isActive = _infoPanel.activeSelf == false;

        _infoPanel.SetActive(isActive);       

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