using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController3 : MonoBehaviour
{

    public float speed;
    public float move;
    public float move2;





    void FixedUpdate()
    {
        //move = Input.GetAxisRaw("Horizontal");
        transform.Translate(transform.right * move * speed * Time.fixedDeltaTime);
        //move2 = Input.GetAxisRaw("Vertical");
        transform.Translate(transform.up * move2 * speed * Time.fixedDeltaTime);

        Controller();
    }

    void Controller()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position -= transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.up * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.up * speed * Time.deltaTime;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Tank"))
        {
            Destroy(gameObject);
            SceneManager.LoadScene("GameOver3");
        }
    }
}