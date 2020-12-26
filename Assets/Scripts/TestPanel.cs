using UnityEngine;

public class TestPanel : MonoBehaviour
{
    [SerializeField] GameObject testPanel;
    [SerializeField] GameObject[] gameObjects;

    private void Awake()
    {
        testPanel.SetActive(true);
        gameObject.SetActive(false);
    }
}
