using UnityEngine;

public class SpaceController : MonoBehaviour
{
    [Header("Параметры")]
    [SerializeField] private float _speed;
    
    [Header("Физика")]
    [SerializeField] private Rigidbody2D _srb;
    private void Awake()
    {
        _srb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 8);
        
    }

    private void FixedUpdate()
    {
        _srb.linearVelocity = -_srb.transform.up * _speed;
    }
}
