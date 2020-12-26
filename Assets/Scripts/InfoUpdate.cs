using UnityEngine;
using UnityEngine.UI;

public class InfoUpdate : MonoBehaviour
{
    public GameObject panel;

    // Start is called before the first frame update
    private void Awake()
    {
        panel.SetActive(true);
    }

    
}
