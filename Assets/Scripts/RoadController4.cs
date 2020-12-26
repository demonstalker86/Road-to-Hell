using System.Collections.Generic;
using UnityEngine;

public class RoadController4 : MonoBehaviour
{
    public bool StartRoad;
    public float speed;
    public List<GameObject> objects;
    public List<Transform> pos;
    private GameObject Object1;
    private GameObject Object2;
    private Transform Pos1;
    private Transform Pos2;
    void Start()
    {
        if (StartRoad == true)
        {
            RandomObjects();
            RandomPosition();
            Instations();
        }

        Destroy(gameObject, 10);
    }
    void Instations()
    {
        GameObject prefab1 = Instantiate(Object1, Pos1.position,Quaternion.Euler(0,0,90), gameObject.transform);
        prefab1.name = "NPC_tank1";
        GameObject prefab2 = Instantiate(Object2, Pos2.position, Quaternion.Euler(0,0,90), gameObject.transform);
        prefab2.name = "NPC_tank2";
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
        transform.position -= transform.up * speed * Time.fixedDeltaTime;
    }
}
