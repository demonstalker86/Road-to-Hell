using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [Header("Индикатор")]
    [SerializeField] private Text _timerText;   
    //public Slider mySlider;


    [Header("Осталось времени")]
    [SerializeField] private int _timeLeft;
    private float _gameTime;
    [Header("Индекс сцены")]
    [SerializeField] private int _sceneIndex;


    void FixedUpdate()
    {
        _timerText.text = "Left" +" "+ _timeLeft +" "+ "sec.";
       
        
        _gameTime += 1 * Time.fixedDeltaTime;
        if (_gameTime >= 1)
        {
            _timeLeft -= 1;
            _gameTime = 0;
            if (_timeLeft <= 0)
            {           
                SceneManager.LoadScene(_sceneIndex);
            }
        }
    }
}