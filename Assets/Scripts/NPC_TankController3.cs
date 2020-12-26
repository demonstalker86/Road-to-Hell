using UnityEngine;

public class NPC_TankController3 : MonoBehaviour
{
    public float speed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Tank"))
        {
            Destroy(gameObject);

        }
        if (collision.gameObject.CompareTag("ShellP"))
        {

            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }

    void FixedUpdate()
    {
        transform.position -= transform.right * speed * Time.fixedDeltaTime;
    }
}
