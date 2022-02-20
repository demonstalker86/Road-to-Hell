using UnityEngine;
using UnityEngine.UI;

public class InfoUpdate : MonoBehaviour
{
    [SerializeField] private GameObject _panel;

    // Start is called before the first frame update
    public void Awake()
    {
        _panel.SetActive(true);
    }

    
}
