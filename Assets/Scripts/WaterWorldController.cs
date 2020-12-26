using UnityEngine;

public class WaterWorldController : MonoBehaviour
{
    [Header("Префабы")]
    public GameObject[] prefabWater;
    [Header("Точки и место появления воды")]
    public GameObject point;
    [Space]
    public GameObject parentWater;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Water"))
        {
            GameObject Water = Instantiate(prefabWater[Random.Range(0,prefabWater.Length)], point.transform.position, Quaternion.identity, parentWater.transform);
            Water.name = "water";               
         
        }
    }
}
