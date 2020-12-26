using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    //[Header("Индикатор")]
    public Text timerText;
    [SerializeField] GameObject gmobj;
    [SerializeField] GameObject bcobj;
    //public Slider mySlider;


    [Header("Осталось времени")]
    public int timeLeft;
    private float gameTime;
    [Header("Индекс сцены")]
    public int sceneIndex;


    void FixedUpdate()
    {
        timerText.text = "Left" +" "+ timeLeft +" "+ "sec.";
       
        
        gameTime += 1 * Time.fixedDeltaTime;
        if (gameTime >= 1)
        {
            timeLeft -= 1;
            gameTime = 0;
            if (timeLeft <= 0)
            {           
                SceneManager.LoadScene(sceneIndex);
            }
        }
    }
}