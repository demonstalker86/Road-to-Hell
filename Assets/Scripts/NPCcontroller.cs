using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCcontroller : MonoBehaviour
{
    public float speed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Car"))
        {
            Destroy(gameObject);
            
        }
    }

        void FixedUpdate()
    {
        transform.position += transform.right * speed * Time.fixedDeltaTime; 
    }
    //private void OnBecameInvisible()
    //{
    //    Destroy(gameObject);
    //}
}
