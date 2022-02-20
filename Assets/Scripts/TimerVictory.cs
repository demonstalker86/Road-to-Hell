
using UnityEngine;
using UnityEngine.UI;

public class TimerVictory : MonoBehaviour
{
    //[Header("Индикатор")]
    [SerializeField] private Text _timerText;
    [SerializeField] GameObject gmobj;
    [SerializeField] GameObject bcobj;
    //public Slider mySlider;


    [Header("Осталось времени")]
    [SerializeField] private int _timeLeft;
    private float _gameTime;
   

    void FixedUpdate()
    {
        _timerText.text = "Left" + " " + _timeLeft + " " + "sec.";


        _gameTime += 1 * Time.fixedDeltaTime;
        if (_gameTime >= 1)
        {
            _timeLeft -= 1;
            _gameTime = 0;
            if (_timeLeft <= 0)
            {
                _timerText.gameObject.SetActive(false);
                gmobj.SetActive(true);
                Time.timeScale = 0f;
                bcobj.SetActive(false);
               
            }
        }
    }
}
