using System.Collections;
using UnityEngine;

public class AsteroidSpawn : MonoBehaviour
{
    public GameObject[] asteroid;
    private float[] position = { -1.87f, -0.64f, 0.6f, 1.8f };
    void Start()
    {
        StartCoroutine(spawn());

        IEnumerator spawn()
        {
            while (true)
            {
                Instantiate(
                    asteroid[Random.Range(0, asteroid.Length)],
                    new Vector3(position[Random.Range(0, 4)], Random.Range(5.4f, 10f), -1),
                    Quaternion.Euler(new Vector3(0, 0, 90)));
                yield return new WaitForSeconds(4f);

            }
        }
    }
}
