using UnityEngine;

public class NPCcontroller2 : MonoBehaviour
{
    public float speed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Car"))
        {
            Destroy(gameObject);

        }
    }

    void FixedUpdate()
    {
        transform.position += transform.up * speed * Time.fixedDeltaTime;
    }
    
}
