using System.Collections;
using UnityEngine;


public class CloudSpawn : MonoBehaviour
{
    public GameObject[] cloud;
    private float[] position = { -1.51f, -0.54f, 0.75f, 2.28f };
    void Start()
    {
        StartCoroutine(spawn());

        IEnumerator spawn()
        {
            while (true)
            {
                Instantiate(
                    cloud[Random.Range(0, cloud.Length)],
                    new Vector3(position[Random.Range(0, 4)], Random.Range(5.4f, 10f), -2),
                    Quaternion.Euler(new Vector3(0, 0, 90)));
                yield return new WaitForSeconds(4f);

            }
        }
    }
}
