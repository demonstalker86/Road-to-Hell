using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePlayerController : MonoBehaviour
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

    [HideInInspector] public float move;
    [HideInInspector] public float move2;

    [SerializeField] Joystick  joystick;
    [SerializeField] Joystick joystick2;
    [SerializeField] GameObject gameObj;
    [SerializeField] GameObject backobj;
    void Start()
    {
        hpText.text = ((int)hp).ToString();
        rb = GetComponent<Rigidbody2D>();
        damage = FindObjectOfType<NPC_PlaneController>().damage;
        animat = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (triger)
        {
            UpdateText();
            TakeDamage();           
        }
        //move = Input.GetAxisRaw("Horizontal");
        rb.AddForce(rb.transform.up * move * speed);
        //move2 = Input.GetAxisRaw("Vertical");
        rb.AddForce(rb.transform.right * move2 * speed);
        Controller();
        JoyController();
        JoyController2();
    }

    void JoyController()
    {
        if (joystick.Horizontal > 0.1f)
        {
            rb.AddForce(-rb.transform.up * speed);
        }
        else if (joystick.Horizontal < -0.1f)
        {
            rb.AddForce(rb.transform.up * speed);
        }
        else if (joystick.Vertical > 0.1f)
        {
            rb.AddForce(rb.transform.right * speed);
        }
        else if (joystick.Vertical < -0.1f)
        {
            rb.AddForce(-rb.transform.right * speed);
        }

    }

    void JoyController2()
    {
        if (joystick2.Horizontal > 0.1f)
        {
            rb.AddForce(-rb.transform.up * speed);
        }
        else if (joystick2.Horizontal < -0.1f)
        {
            rb.AddForce(rb.transform.up * speed);
        }
        else if (joystick2.Vertical > 0.1f)
        {
            rb.AddForce(rb.transform.right * speed);
        }
        else if (joystick2.Vertical < -0.1f)
        {
            rb.AddForce(-rb.transform.right * speed);
        }

    }
    void Controller()
    {
        if (Input.GetKey(KeyCode.W))
        {

            rb.AddForce(rb.transform.right * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {

            rb.AddForce(-rb.transform.right * speed);
        }
        if (Input.GetKey(KeyCode.A))
        {

            rb.AddForce(rb.transform.up * speed);
        }
        if (Input.GetKey(KeyCode.D))
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


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("AirPlane"))
        {
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
