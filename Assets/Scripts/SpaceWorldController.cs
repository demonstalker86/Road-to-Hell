using UnityEngine;

public class SpaceWorldController : MonoBehaviour
{
    [Header("Префабы")]
    public GameObject[] prefabSpace;

    [Header("Точки и место появления неба, объектов")]
    public GameObject point;
    [Space]
    public GameObject parentSpace;




    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Space"))
        {
            GameObject Space = Instantiate(prefabSpace[Random.Range(0, prefabSpace.Length)], point.transform.position, Quaternion.identity, parentSpace.transform);
            Space.name = "Space";

        }
    }
}
