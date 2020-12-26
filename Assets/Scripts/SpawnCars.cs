using UnityEngine;
using System.Collections;

public class SpawnCars : MonoBehaviour
{
    public GameObject[] cars;
    private float[] position = { -1.49f,-0.8f,-0.02f,0.68f };
    void Start()
    {
        StartCoroutine(spawn());

        IEnumerator spawn ()
        {
            while (true)
            {
                Instantiate(
                    cars[Random.Range(0, cars.Length)],
                    new Vector3(position[Random.Range(0, 4)], 6f, 0),
                    Quaternion.Euler(new Vector3(90,180,0)) 
                    ) ;
                yield return new WaitForSeconds(2.5f);
                                                           
            }
        }
    }

    
}
