using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Move : MonoBehaviour
    {
    public float speed = 50f;
    public GameObject player;
    private Rigidbody rb;
    private float screen;
    // Start is called before the first frame update
    void Start()
        {
        screen = Screen.width;
        rb = player.GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {
        int i = 0;
        while (i<Input.touchCount)
        {
            if (Input.GetTouch(i).position.x>screen/2)
            {
                Movement(1.0f);
            }
            if (Input.GetTouch(i).position.x<screen/2)
            {
                Movement(-1.0f);
            }
            ++i;
        }
        float hor = Input.GetAxisRaw("Horizontal");
         Vector3 dir = new Vector3(hor, 0, 0);
         transform.Translate(dir.normalized * Time.deltaTime * speed);
    }
    private void Movement(float horizontalInput)
    {
        rb.AddForce(new Vector2(horizontalInput*speed*Time.deltaTime,0));
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Car"))
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Game Over");

        }
    }
    
    }
