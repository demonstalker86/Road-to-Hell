using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour
{
    [Header("Параметры")]
    public float speed;
    [Space]
    public float hp;
    [Space]
    public Text hpText;
    [Space]
    bool triger;
    [Space]
    [Header("Физика")]
    public Rigidbody2D rb;

    [SerializeField] Joystick joystick;
    [SerializeField] Joystick joystick2;
    [SerializeField] GameObject gameObj;
    [SerializeField] GameObject backobj;


    void Start()
    {
        StartCoroutine(Regenerate());
        rb = GetComponent<Rigidbody2D>();
        hpText.text = ((int)hp).ToString();
    }

    void FixedUpdate()
    {
        if (triger)
        {
            UpdateText();
            TakeDamage();            
        }
        Controller();
        JoyController();
        JoyController2();
    }

    public void JoyController()
    {
        if (joystick.Horizontal > 0.1f)
        {
            rb.AddForce(-rb.transform.right * speed);
        }
        else if (joystick.Horizontal < -0.1f)
        {
            rb.AddForce(rb.transform.right * speed);
        }
        else if (joystick.Vertical > 0.1f)
        {
            rb.AddForce(-rb.transform.up * speed);
        }
        else if (joystick.Vertical < -0.1f)
        {
            rb.AddForce(rb.transform.up * speed);
        }

    }

    public void JoyController2()
    {
        if (joystick2.Horizontal > 0.1f)
        {
            rb.AddForce(-rb.transform.right * speed);
        }
        else if (joystick2.Horizontal < -0.1f)
        {
            rb.AddForce(rb.transform.right * speed);
        }
        else if (joystick2.Vertical > 0.1f)
        {
            rb.AddForce(-rb.transform.up * speed);
        }
        else if (joystick2.Vertical < -0.1f)
        {
            rb.AddForce(rb.transform.up * speed);
        }

    }

    void Controller()
    {
        if (Input.GetKey(KeyCode.W))
        {
            
            rb.AddForce(-rb.transform.right * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            
            rb.AddForce(rb.transform.right * speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            
            rb.AddForce(-rb.transform.up * speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            
            rb.AddForce(rb.transform.up * speed);
        }
        
    }

    void TakeDamage()
    {
        hp -= 10 * Time.deltaTime;

        if (hp < 0)
        {
            hp = 0;
            Destroy(gameObject);
            gameObj.SetActive(true);
            Time.timeScale = 0f;
            backobj.SetActive(false);
        }
    }

    void UpdateText()
    {
        hpText.text = ((int)hp).ToString();
    }

    IEnumerator Regenerate()
    {
        if (hp > 0)
        {
            yield return new WaitForSeconds(1);
            hp += 30 * Time.deltaTime;
            hpText.text = ((int)hp).ToString();
        }
        if (hp > 60)
            hp = 60;
        Repeat();
    }

    void Repeat()
    {
        StartCoroutine(Regenerate());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Tank"))
        {
            triger = true;
            TakeDamage();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Tank"))
        {
            Destroy(collision.gameObject);
            triger = false;            
        }
    }
}
