using UnityEngine;

public class SkyWorldController : MonoBehaviour
{
    [Header("Префабы")]
    public GameObject[] prefabSky;
    
    [Header("Точки и место появления неба, объектов")]
    public GameObject point;
    [Space]
    public GameObject parentSky;
   

 

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.CompareTag("Sky"))
        {
            GameObject Sky = Instantiate(prefabSky[Random.Range(0, prefabSky.Length)], point.transform.position, Quaternion.identity, parentSky.transform);
            Sky.name = "Sky";

        }
    }
}
