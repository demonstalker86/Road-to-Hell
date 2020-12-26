using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ImageColor : MonoBehaviour
{
    public Image img;

    private void Start()
    {
        img = GetComponent<Image>();
        StartCoroutine(nameof(RandomColor));
    }



    IEnumerator RandomColor()
    {
        img.color = this.GetComponent<Image>().color;

        if (img.color != Color.black && img.color != Color.yellow)
        {
            img.color = new Color(Random.value, Random.value, Random.value, 1);
            yield return null;

        }

    }
}
