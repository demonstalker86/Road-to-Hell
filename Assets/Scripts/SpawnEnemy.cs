

using System.Collections;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject[] _gmobj;
    private readonly float[] _position = { -2.58f, -0.83f, 0.92f, 2.49f };
    void Start()
    {
        StartCoroutine(Spawn());

        IEnumerator Spawn()
        {
            while (true)
            {
                Instantiate(
                    _gmobj[Random.Range(0, _gmobj.Length)],
                    new Vector3(_position[Random.Range(0, 4)], Random.Range(8f,10f), -1),
                    Quaternion.Euler(new Vector3(0, 0, 180)));
                    yield return new WaitForSeconds(5f);
            }
        }
    }
}
