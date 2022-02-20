using System.Collections;
using UnityEngine;

public class NPC_shipController : MonoBehaviour
{
    [Header("Параметры")]
    [SerializeField] private float _speed;    
    [Space]
    [SerializeField] private int _timeToDeath;
    [Header("Физика")]
    [SerializeField] private Rigidbody2D _srb;
    void Start()
    {
        _srb = GetComponent<Rigidbody2D>();       
        StartCoroutine(SelfDestroying());
    }

    private IEnumerator SelfDestroying()
    {
        yield return new WaitForSeconds(_timeToDeath);
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.CompareTag("Ship"))
        {
            Destroy(gameObject);
        }
    }
    
    void FixedUpdate()
    {
        _srb.velocity=_srb.transform.up * _speed;
    }
}
