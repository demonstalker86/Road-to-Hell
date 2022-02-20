using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class GameController2 : MonoBehaviour
{
    [Header("Параметры")]
    [SerializeField] private float _speed;
    [Space]
    [SerializeField] private float _hp;   
    [Space]
    [SerializeField] private Text _hpText;
    [Space]
    [Header("Физика")]
    [SerializeField] private Rigidbody2D _rb;
    [Space]
    private bool _triger;
    [Header("Анимация")]
    [SerializeField] private Animator _animat;
    [Header("Система управления")]
    [SerializeField] private Joystick _joystick;
    [SerializeField] private Joystick _joystick2;
    [Header("Объекты")]
    [SerializeField] private GameObject _gameObj;
    [Space]
    [SerializeField] private GameObject _backobj;

    void Start()
    {
        StartCoroutine(Regenerate());
        _hpText.text = ((int)_hp).ToString();
        _rb = GetComponent<Rigidbody2D>();       
        _animat = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (_triger)
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

    void TakeDamage()
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
        if (_hp > 0)
        {
            yield return new WaitForSeconds(1);
            _hp += 30 * Time.deltaTime;
            _hpText.text = ((int)_hp).ToString();
        }
        if (_hp > 80)
            _hp = 80;
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
            _triger = true;
            TakeDamage();
            _animat.SetBool("EnemyDamage", true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ship"))
        {
            Destroy(collision.gameObject);
            _triger = false;
            _animat.SetBool("EnemyDamage", false);
        }      
    }
}
