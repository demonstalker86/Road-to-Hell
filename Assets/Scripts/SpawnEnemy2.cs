using System.Collections;
using UnityEngine;

public class SpawnEnemy2 : MonoBehaviour
{
    public GameObject[] obj;
    private float[] position = { -2.58f, -0.83f, 0.92f, 2.49f };
    void Start()
    {
        StartCoroutine(spawn());

        IEnumerator spawn()
        {
            while (true)
            {
                Instantiate(
                    obj[Random.Range(0, obj.Length)],
                    new Vector3(position[Random.Range(0, 4)], Random.Range(8f, 10f), -1),
                    Quaternion.Euler(new Vector3(0, 0, -90)));
                yield return new WaitForSeconds(5f);

            }
        }
    }
}
