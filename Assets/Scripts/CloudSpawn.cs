using System.Collections;
using UnityEngine;


public class CloudSpawn : MonoBehaviour
{
    [SerializeField] private GameObject[] _cloud;
    private readonly float[] _position = { -1.51f, -0.54f, 0.75f, 2.28f };
    void Start()
    {
        StartCoroutine(Spawn());

        IEnumerator Spawn()
        {
            while (true)
            {
                Instantiate(
                    _cloud[Random.Range(0, _cloud.Length)],
                    new Vector3(_position[Random.Range(0, 4)], Random.Range(5.4f, 10f), -2),
                    Quaternion.Euler(new Vector3(0, 0, 90)));
                yield return new WaitForSeconds(4f);
            }
        }
    }
}
