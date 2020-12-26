using UnityEngine;
using UnityEngine.SceneManagement;


public class TestGame : MonoBehaviour
{
    public void DoomsDay()
    {
        SceneManager.LoadScene("DoomsDay 1");
    }
    public void TankParade()
    {
        SceneManager.LoadScene("TankParade");
    }

    public void Motorcycle()
    {
        SceneManager.LoadScene("Motorcycle");
    }
    public void Moonlight()
    {
        SceneManager.LoadScene("Moonlight");
    }
    public void Poligon()
    {
        SceneManager.LoadScene("Poligon");
    }

    public void WaterWorld()
    {
        SceneManager.LoadScene("WaterWorld");
    }
    public void AirWorld()
    {
        SceneManager.LoadScene("AirWorld");
    }
    public void SpaceWorld()
    {
        SceneManager.LoadScene("SpaceWorld");
    }
}
