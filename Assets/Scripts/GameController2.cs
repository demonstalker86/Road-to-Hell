using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameController2 : MonoBehaviour
{
    [Header("Параметры")]
    public float speed;
    [Space]
    public float hp;
    [Space]
    int damage;
    [Space]
    public Text hpText;
    [Space]
    bool triger;
    [Header("Физика")]
    public Rigidbody2D rb;
    [Space]
    [Header("Анимация")]
    public Animator animat;

    public Joystick joystick;
    public Joystick joystick2;
    [SerializeField] GameObject gameObj;
    [SerializeField] GameObject backobj;

    void Start()
    {
        StartCoroutine(Regenerate());
        hpText.text = ((int)hp).ToString();
        rb = GetComponent<Rigidbody2D>();
        damage = FindObjectOfType<NPC_shipController>().damage;
        animat = GetComponent<Animator>();
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

    void TakeDamage()
    {
        hp -= damage * Time.deltaTime;

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
        Repeat();
    }

    void Repeat()
    {
        StartCoroutine(Regenerate());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ship"))
        {
            Destroy(collision.gameObject);
            triger = true;
            TakeDamage();
            animat.SetBool("EnemyDamage", true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        triger = false;
        animat.SetBool("EnemyDamage", false);

    }
}
