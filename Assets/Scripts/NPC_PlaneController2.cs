using UnityEngine;

public class NPC_PlaneController2 : MonoBehaviour
{
    [Header("Параметры")]
    public float speed;
    [Header("Физика")]
    public Rigidbody2D prb;
    void Start()
    {
        prb = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("AirPlane"))
        {
            Destroy(gameObject);

        }
    }

    void FixedUpdate()
    {
        prb.linearVelocity = -prb.transform.right * speed;
    }
}
