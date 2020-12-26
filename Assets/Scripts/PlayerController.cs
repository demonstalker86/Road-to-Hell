
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    [Header("Параметры")]
    public float speed;
    [Space]
    public float move;
    [Space]
    public float move2;
    [Space]
    [Header("Физика")]
    public Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }




    void FixedUpdate()
    {
        // move = Input.GetAxisRaw("Horizontal");
        rb.AddForce(rb.transform.right * move * speed);
        //move2 = Input.GetAxisRaw("Vertical");
        rb.AddForce(rb.transform.up * move2 * speed);

        Controller();
    }

    void Controller()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(rb.transform.up * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(-rb.transform.up * speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(-rb.transform.right * speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(rb.transform.right * speed);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Car"))
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Game Over2");
        }
        
    }
      
}