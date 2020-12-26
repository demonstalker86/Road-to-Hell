using UnityEngine;
using UnityEngine.EventSystems;

public class ShellPCreator : MonoBehaviour, IPointerDownHandler
{
    [Header("Префабы")]
    public GameObject ShellPprefab;
    [Header("Физика")]
    public float ShellPvelosity;
   

    public void OnPointerDown(PointerEventData eventData)
    {
        
        OnShoot();
    } 
    void OnShoot()
    {
        GameObject newShellP = Instantiate(ShellPprefab, transform.position, Quaternion.Euler(0, 0, -90));
        newShellP.GetComponent<Rigidbody2D>().velocity = transform.up * ShellPvelosity;
       
    }


    //void FixedUpdate()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        GameObject newShellP = Instantiate(ShellPprefab, transform.position, Quaternion.Euler(0, 0, -90));
    //        newShellP.GetComponent<Rigidbody2D>().velocity = transform.up* ShellPvelosity;

    //    }

    //}
}
