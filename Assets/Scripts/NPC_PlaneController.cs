using System.Collections;
using UnityEngine;

public class NPC_PlaneController : MonoBehaviour
{
    [Header("Параметры")]
    [SerializeField] private float _speed;
    [Space]
    [SerializeField] private int _timeToDeath;    
    [Header("Физика")]
    [SerializeField] private Rigidbody2D _prb;
    void Start()
    {
        _prb = GetComponent<Rigidbody2D>();
        StartCoroutine(SelfDestroying());
    }

    private IEnumerator SelfDestroying()
    {
        yield return new WaitForSeconds(_timeToDeath); 
        Destroy(gameObject);
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
        _prb.linearVelocity = _prb.transform.up * _speed;
    }
}
