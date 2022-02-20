using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    [Header("Параметры")]
    [SerializeField] private float _speed;
    
    [Header("Физика")]
    [SerializeField] private Rigidbody2D _arb;
    void Awake()
    {        
        _arb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 8);
    }

    void FixedUpdate()
    {
        _arb.velocity = -_arb.transform.right * _speed;
    }
}
