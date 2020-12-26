using UnityEngine;

public class WorldController : MonoBehaviour
{
    public GameObject prefabRoad;
    public GameObject point;
    public GameObject parentRoad;
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Road"))
        {
            GameObject Road = Instantiate(prefabRoad, point.transform.position, Quaternion.identity,parentRoad.transform);
            Road.name = "road";
        }
    }
}
