using UnityEngine;
using UnityEditor;

public class MoveAndSpawnRoad : MonoBehaviour
{
    public float speed = 1.5f;
    public GameObject road;
    void FixedUpdate()
    {
        transform.Translate(Vector3.down * speed*Time.deltaTime);

        if (transform.position.y < -8f)
        {

            Instantiate(road, new Vector3(-0.41f, 15.67f,0),Quaternion.identity);
                Destroy(gameObject);
        }
    }
}
