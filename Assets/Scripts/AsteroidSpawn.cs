using System.Collections;
using UnityEngine;

public class AsteroidSpawn : MonoBehaviour
{
    [SerializeField] private GameObject[] _asteroid;
    private readonly float[] _position = { -1.87f, -0.64f, 0.6f, 1.8f };
    void Start()
    {
        StartCoroutine(Spawn());

        IEnumerator Spawn()
        {
            while (true)
            {
                Instantiate(
                    _asteroid[Random.Range(0, _asteroid.Length)],
                    new Vector3(_position[Random.Range(0, 4)], Random.Range(5.4f, 10f), -1),
                    Quaternion.Euler(new Vector3(0, 0, 90)));
                yield return new WaitForSeconds(4f);
            }
        }
    }
}
