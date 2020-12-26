
using UnityEngine;

public class NPC_TankController : MonoBehaviour
{ 
    public float speed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Tank"))
        {
            Destroy(gameObject);

        }
    }

    void FixedUpdate()
    {
        transform.position -= transform.up * speed * Time.fixedDeltaTime;
    }
}
