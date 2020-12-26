using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController2 : MonoBehaviour
{
    [Header("Параметры")]
    public float speed;

    [Header("Физика")]
    public Rigidbody2D rb;

    public Joystick joystick;
    public Joystick joystick2;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {       
        Controller();
        JoyController();
        JoyController2();
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

    public void JoyController()
    {
        if (joystick.Horizontal > 0.1f)
        {
            rb.AddForce(rb.transform.right * speed);
        }
        else if (joystick.Horizontal < -0.1f)
        {
            rb.AddForce(-rb.transform.right * speed);
        }
        else if (joystick.Vertical > 0.1f)
        {
            rb.AddForce(rb.transform.up * speed);
        }
        else if (joystick.Vertical < -0.1f)
        {
            rb.AddForce(-rb.transform.up * speed);
        }

    }

    public void JoyController2()
    {
        if (joystick2.Horizontal > 0.1f)
        {
            rb.AddForce(rb.transform.right * speed);
        }
        else if (joystick2.Horizontal < -0.1f)
        {
            rb.AddForce(-rb.transform.right * speed);
        }
        else if (joystick2.Vertical > 0.1f)
        {
            rb.AddForce(rb.transform.up * speed);
        }
        else if (joystick2.Vertical < -0.1f)
        {
            rb.AddForce(-rb.transform.up * speed);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ship"))
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Game Over");
        }
    }
}
