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
    [Header("Объекты")]
    public List<GameObject> objects;
    [Space]
    private GameObject Object1;
    [Space]
    private GameObject Object2;
    [Header("Позиции")]
    public List<Transform> pos;
    [Space]
    private Transform Pos1;
    [Space]
    private Transform Pos2;


    void Start()
    {
        wrb = GetComponent<Rigidbody2D>();
        if (StartRoad == true)
        {
            RandomObjects();
            RandomPosition();
            Instations();
        }
        Destroy(gameObject, 8);
    }

    void Instations()
    {
        GameObject prefab1 = Instantiate(Object1, Pos1.position, Quaternion.Euler(0, 0, 180), gameObject.transform);
        prefab1.name = "NPC_ship1";
        prefab1.transform.localScale = new Vector3(Random.Range(1.6f, 2.8f), Random.Range(0.8f, 1.6f), 1f);
        GameObject prefab2 = Instantiate(Object2, Pos2.position, Quaternion.Euler(0, 0, 180), gameObject.transform);
        prefab2.name = "NPC_ship2";
        prefab2.transform.localScale = new Vector3(Random.Range(1.6f, 2.8f), Random.Range(0.8f, 1.6f), 1f);
    }

    void RandomObjects()
    {
        int o;
        o = Random.Range(0, objects.Count);
        Object1 = objects[o];
        o = Random.Range(0, objects.Count);
        while (Object1 == objects[o])
        {
            o = Random.Range(0, objects.Count);
        }
        Object2 = objects[o];
    }
    void RandomPosition()
    {
        int p;
        p = Random.Range(0, pos.Count);
        Pos1 = pos[p];
        p = Random.Range(0, pos.Count);
        while (Pos1 == pos[p])
        {
            p = Random.Range(0, pos.Count);
        }
        Pos2 = pos[p];
    }

    void FixedUpdate()
    {
        wrb.velocity = -wrb.transform.up * speed;
        
    }
}
