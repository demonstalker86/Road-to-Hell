using System.Collections.Generic;
using UnityEngine;

public class WaterController : MonoBehaviour
{
    [Header ("Параметры")]
    public bool StartRoad;
    [Space]
    public float speed;
    [Header ("Физика")]
    public Rigidbody2D wrb;



    void Start()
    {
        wrb = GetComponent<Rigidbody2D>();       
        Destroy(gameObject, 8);
    }
      

    void FixedUpdate()
    {
        wrb.velocity = -wrb.transform.up * speed;        
    }
}
