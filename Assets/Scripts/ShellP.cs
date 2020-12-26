using UnityEngine;

public class ShellP : MonoBehaviour
{
    [Header("Пораметры")]
    private bool isActive = true;
  



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isActive) return;
        
        isActive = false;
        if (collision.gameObject.CompareTag("Tank"))
        {

        }
    }

    void FixedUpdate()

    {
        Destroy(gameObject, 3);
        
    }
}