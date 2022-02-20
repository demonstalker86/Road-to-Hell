using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayerController2 : MonoBehaviour
{
    [Header("Параметры")]
    [SerializeField] private float _speed;
    [Space]
    [SerializeField] private float _hp;    
    [Space]
    //int damage2;
    //int damage1;
    [Space]
    [SerializeField] private Text _hpText;
    [Space]
    private bool _triger;
    [Header("Физика")]
    [SerializeField] private Rigidbody2D _rb;
    [Space]
    [Header("Анимация")]
    [SerializeField] private Animator animat;



    [SerializeField] private Joystick _joystick;
    [SerializeField] private Joystick _joystick2;
    [SerializeField] private GameObject _gameObj;
    [SerializeField] private GameObject _backobj;

     void Start()
    {
        
       StartCoroutine(Regenerate());
       _hpText.text = ((int)_hp).ToString();
       _rb = GetComponent<Rigidbody2D>();
        //damage2 = GameObject.FindWithTag("asteroid").GetComponent<AsteroidController>().damage;
        //damage1 = GameObject.FindWithTag("SpaceShip").GetComponent<NPC_SpaceController>().damage;
       animat = GetComponent<Animator>();
       
    }   

    void FixedUpdate()
    {
        if (_triger)
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
        if (_joystick.Horizontal > 0.1f)
        {
            _rb.AddForce(_rb.transform.right * _speed);
        }
        else if (_joystick.Horizontal < -0.1f)
        {
            _rb.AddForce(-_rb.transform.right * _speed);
        }
        else if (_joystick.Vertical > 0.1f)
        {
            _rb.AddForce(_rb.transform.up * _speed);
        }
        else if (_joystick.Vertical < -0.1f)
        {
            _rb.AddForce(-_rb.transform.up * _speed);
        }

    }

    public void JoyController2()
    {
        if (_joystick2.Horizontal > 0.1f)
        {
            _rb.AddForce(_rb.transform.right * _speed);
        }
        else if (_joystick2.Horizontal < -0.1f)
        {
            _rb.AddForce(-_rb.transform.right * _speed);
        }
        else if (_joystick2.Vertical > 0.1f)
        {
            _rb.AddForce(_rb.transform.up * _speed);
        }
        else if (_joystick2.Vertical < -0.1f)
        {
            _rb.AddForce(-_rb.transform.up * _speed);
        }

    }

    public void Controller()
    {
        if (Input.GetKey(KeyCode.W))
        {

            _rb.AddForce(_rb.transform.up * _speed);
        }
        if (Input.GetKey(KeyCode.S))
        {

            _rb.AddForce(-_rb.transform.up * _speed);
        }
        if (Input.GetKey(KeyCode.A))
        {

            _rb.AddForce(-_rb.transform.right * _speed);
        }
        if (Input.GetKey(KeyCode.D))
        {

            _rb.AddForce(_rb.transform.right * _speed);
        }

    }

    void TakeDamage()
    {
        _hp -= 12 * Time.deltaTime;

        if (_hp < 0)
        {
            _hp = 0;
            Destroy(gameObject);
            _gameObj.SetActive(true);
            Time.timeScale = 0f;
            _backobj.SetActive(false);
        }
    }
    void TakeDamage2()
    {
        _hp -= 10 * Time.deltaTime;

        if (_hp < 0)
        {
            _hp = 0;
            Destroy(gameObject);
            _gameObj.SetActive(true);
            Time.timeScale = 0f;
            _backobj.SetActive(false);
        }
    }
    void UpdateText()
    {
        _hpText.text = ((int)_hp).ToString();
    }
      IEnumerator Regenerate()
    {
        if (_hp > 0 )
        {          
           yield return new WaitForSeconds(1);
           _hp += 30 * Time.deltaTime;
           _hpText.text = ((int)_hp).ToString();           
        }
        if (_hp > 50)
            _hp = 50;
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
            
            _triger = true;
            TakeDamage2();
            animat.SetBool("EnemyDamage",true);            
        }

        if (collision.gameObject.CompareTag("asteroid"))
        {
            
            _triger = true;
            TakeDamage();
            animat.SetBool("EnemyDamage",true);
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
            if (collision.gameObject.CompareTag("SpaceShip"))
        {
            Destroy(collision.gameObject);
            _triger = false;
            animat.SetBool("EnemyDamage", false);
        }
            if (collision.gameObject.CompareTag("asteroid"))
        {
            Destroy(collision.gameObject);
            _triger = false;
            animat.SetBool("EnemyDamage", false);
        }
                
        
    }
}




