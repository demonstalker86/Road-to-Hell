using UnityEngine;

public class CloudController : MonoBehaviour
{
    [Header("Параметры")]
    [SerializeField] private float _speed;
    [Header("Физика")]
    [SerializeField] private Rigidbody2D _crb;
    void Awake()
    {
        _crb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 8);
    }

    void FixedUpdate()
    {
        _crb.linearVelocity = -_crb.transform.right * _speed;
    }
}
