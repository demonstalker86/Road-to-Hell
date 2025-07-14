using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyController : MonoBehaviour
{
    [Header("Параметры")]
    [SerializeField] private float _speed;
    [Header("Физика")]
    [SerializeField] private Rigidbody2D _srb;
    void Awake()
    {
        _srb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 8);
    }

    void FixedUpdate()
    {
        _srb.linearVelocity = -_srb.transform.up * _speed;

    }

}
