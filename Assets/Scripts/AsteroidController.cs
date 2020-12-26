using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    [Header("Параметры")]
    public float speed;
    [Space]
    public int damage;
    [Header("Физика")]
    public Rigidbody2D arb;
    void Awake()
    {
        
        arb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 8);
    }

    void FixedUpdate()
    {
        arb.velocity = -arb.transform.right * speed;

    }
}
