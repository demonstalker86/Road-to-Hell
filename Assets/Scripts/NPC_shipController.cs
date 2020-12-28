using System.Collections;
using UnityEngine;

public class NPC_shipController : MonoBehaviour
{
    [Header("Параметры")]
    public float speed;
    [Space]
    //public int damage;
    [Space]
    public int timeToDeath;
    [Header("Физика")]
    public Rigidbody2D srb;
    void Start()
    {
        srb = GetComponent<Rigidbody2D>();
        StartCoroutine(selfDestroying());
    }

    private IEnumerator selfDestroying()
    {
        yield return new WaitForSeconds(timeToDeath);
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
        srb.velocity=srb.transform.up * speed;
    }
}
