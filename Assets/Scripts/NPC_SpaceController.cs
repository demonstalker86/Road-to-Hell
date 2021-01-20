using System.Collections;
using UnityEngine;

public class NPC_SpaceController : MonoBehaviour
{
    [Header("Параметры")]
    public float speed;
    [Space]
    public int timeToDeath;
    [Space]
    //public int damage;

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
        if (collision.gameObject.CompareTag("SpaceShip"))
        {
            Destroy(gameObject);

        }
        if (collision.gameObject.CompareTag("asteroid"))
        {
            Destroy(gameObject);          
        }
    }

    void FixedUpdate()
    {
        srb.velocity = srb.transform.right * speed;
    }
}
