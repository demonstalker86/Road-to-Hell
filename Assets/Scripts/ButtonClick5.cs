
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonClick5 : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        if (gameObject.name == "Right")
            GameObject.Find("Player").GetComponent<GameController2>().move = 1;
        else if (gameObject.name == "Left")
            GameObject.Find("Player").GetComponent<GameController2>().move = -1;
        else if (gameObject.name == "Up")
            GameObject.Find("Player").GetComponent<GameController2>().move2 = 1;
        else if (gameObject.name == "Down")
            GameObject.Find("Player").GetComponent<GameController2>().move2 = -1;
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        GameObject.Find("Player").GetComponent<GameController2>().move = 0;
        GameObject.Find("Player").GetComponent<GameController2>().move2 = 0;

    }
}
