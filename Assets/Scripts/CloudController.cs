using UnityEngine;

public class CloudController : MonoBehaviour
{
    [Header("Параметры")]
    public float speed;
    [Header("Физика")]
    public Rigidbody2D crb;
    void Awake()
    {
        crb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 8);
    }

    void FixedUpdate()
    {
        crb.velocity = -crb.transform.right * speed;

    }
}
