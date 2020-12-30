using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayerController2 : MonoBehaviour
{
    [Header("Параметры")]
    public float speed;
    [Space]
    public float hp;    
    [Space]
    int damage2;
    int damage1;
    [Space]
    public Text hpText;
    [Space]
    bool triger;
    [Header("Физика")]
    public Rigidbody2D rb;
    [Space]
    [Header("Анимация")]
    public Animator animat;



    [SerializeField] Joystick joystick;
    [SerializeField] Joystick joystick2;
    [SerializeField] GameObject gameObj;
    [SerializeField] GameObject backobj;

     void Start()
    {
        
       StartCoroutine(Regenerate());
       hpText.text = ((int)hp).ToString();
       rb = GetComponent<Rigidbody2D>();
       damage2 = FindObjectOfType<AsteroidController>().damage;
       damage1 = FindObjectOfType<NPC_SpaceController>().damage;
       animat = GetComponent<Animator>();
       
    }   

    void FixedUpdate()
    {
        if (triger)
        {
            UpdateText();
            TakeDamage();
            TakeDamage2();
        }        
        Controller();
        JoyController();
        JoyController2();        
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

    public void Controller()
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

    void TakeDamage()
    {
        hp -= damage2 * Time.deltaTime;

        if (hp < 0)
        {
            hp = 0;
            Destroy(gameObject);
            gameObj.SetActive(true);
            Time.timeScale = 0f;
            backobj.SetActive(false);
        }
    }
    void TakeDamage2()
    {
        hp -= damage1 * Time.deltaTime;

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
        if (hp > 0 )
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
       
        if (collision.gameObject.CompareTag("SpaceShip"))
        {
            
            triger = true;
            TakeDamage2();
            animat.SetBool("EnemyDamage",true);            
        }

        if (collision.gameObject.CompareTag("asteroid"))
        {
            
            triger = true;
            TakeDamage();
            animat.SetBool("EnemyDamage",true);
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
            if (collision.gameObject.CompareTag("SpaceShip"))
        {
            Destroy(collision.gameObject);
            triger = false;
            animat.SetBool("EnemyDamage", false);
        }
            if (collision.gameObject.CompareTag("asteroid"))
        {
            Destroy(collision.gameObject);
            triger = false;
            animat.SetBool("EnemyDamage", false);
        }
                
        
    }
}




