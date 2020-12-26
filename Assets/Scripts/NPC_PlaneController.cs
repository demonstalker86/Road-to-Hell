using System.Collections;
using UnityEngine;

public class NPC_PlaneController : MonoBehaviour
{
    [Header("Параметры")]
    public float speed;
    [Space]
    public int timeToDeath;
    [Space]
    public int damage;
    [Header("Физика")]
    public Rigidbody2D prb;
    void Start()
    {
        prb = GetComponent<Rigidbody2D>();
        StartCoroutine(selfDestroying());
    }

    private IEnumerator selfDestroying()
    {
        yield return new WaitForSeconds(timeToDeath); 
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
        prb.velocity = prb.transform.up * speed;
    }
}
