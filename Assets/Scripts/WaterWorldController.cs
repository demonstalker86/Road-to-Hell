using UnityEngine;

public class WaterWorldController : MonoBehaviour
{
    [Header("Префабы")]
    [SerializeField] private GameObject[] _prefabWater;
    [Header("Точки и место появления воды")]
    [SerializeField] private GameObject _point;
    [Space]
    [SerializeField] private GameObject _parentWater;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Water"))
        {
            GameObject Water = Instantiate(_prefabWater[Random.Range(0,_prefabWater.Length)], _point.transform.position, Quaternion.identity, _parentWater.transform);
            Water.name = "water";           
        }
    }
}
