using UnityEngine;
using UnityEngine.SceneManagement;

public class MyMenu : MonoBehaviour
{
    public void TripleThreat()
    {
        SceneManager.LoadScene("Level 1");
        Time.timeScale = 1f;
    }
    public void LastJourney()
    {
        SceneManager.LoadScene("TankParade");
        Time.timeScale = 1f;
    }
    public void DoomsDay()
    {
        SceneManager.LoadScene("DoomsDay 1");
        Time.timeScale = 1f;
    }
    public void WaterWorld()
    {
        SceneManager.LoadScene("WaterWorld");
        Time.timeScale = 1f;
    }

    public void AirWorld()
    {
        SceneManager.LoadScene("AirWorld");
        Time.timeScale = 1f;
    }

    public void SpaceWorld()
    {
        SceneManager.LoadScene("SpaceWorld");
        Time.timeScale = 1f;
    }
    public void Play()
    {
        SceneManager.LoadScene("GameMode");
    }
      
    public void Menu()
    {
        SceneManager.LoadScene("MyMenu");

    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void Pause()
    {
        Time.timeScale = 0f;
    }
    public void PlayPause ()
    {
        Time.timeScale = 1f;
    }

    public void InfoPanel()
    {
        gameObject.GetComponent<InfoUpdate>().panel.SetActive(false);
    }
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
