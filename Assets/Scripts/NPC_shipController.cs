using UnityEngine;

public class NPC_shipController : MonoBehaviour
{
    [Header("Параметры")]
    public float speed;
    [Header("Физика")]
    public Rigidbody2D srb;
    void Start()
    {
        srb = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ship"))
        {
            Destroy(gameObject);

        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        srb.velocity=srb.transform.up * speed;
    }
}
