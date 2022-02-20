using UnityEngine;

public class WaterController : MonoBehaviour
{
    [Header ("Параметры")]
    [SerializeField] private bool _startRoad;
    [Space]
    [SerializeField] private float _speed;
    [Header ("Физика")]
    [SerializeField] private Rigidbody2D _wrb;



    void Start()
    {
        _wrb = GetComponent<Rigidbody2D>();       
        Destroy(gameObject, 8);
    }
      

    void FixedUpdate()
    {
        _wrb.velocity = -_wrb.transform.up * _speed;        
    }
}
