
using UnityEngine;
using UnityEngine.UI;

public class TimerVictory : MonoBehaviour
{
    //[Header("Индикатор")]
    public Text timerText;
    [SerializeField] GameObject gmobj;
    [SerializeField] GameObject bcobj;
    //public Slider mySlider;


    [Header("Осталось времени")]
    public int timeLeft;
    private float gameTime;
   

    void FixedUpdate()
    {
        timerText.text = "Left" + " " + timeLeft + " " + "sec.";


        gameTime += 1 * Time.fixedDeltaTime;
        if (gameTime >= 1)
        {
            timeLeft -= 1;
            gameTime = 0;
            if (timeLeft <= 0)
            {
                timerText.gameObject.SetActive(false);
                gmobj.SetActive(true);
                Time.timeScale = 0f;
                bcobj.SetActive(false);
               
            }
        }
    }
}
