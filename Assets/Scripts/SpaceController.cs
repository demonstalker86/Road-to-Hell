using UnityEngine;

public class SpaceController : MonoBehaviour
{
    [Header("Параметры")]
    public float speed;
    
    [Header("Физика")]
    public Rigidbody2D srb;
    void Awake()
    {
        srb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 8);
        
    }

    void FixedUpdate()
    {
        srb.velocity = -srb.transform.up * speed;
    }
}
