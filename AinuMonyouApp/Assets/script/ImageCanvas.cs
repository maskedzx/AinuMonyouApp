using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ImageCanvas : MonoBehaviour
{

    public Canvas ShowCanvas;

    void Start()
    {
        this.gameObject.GetComponent<Canvas>().enabled = false;
    }

    public void ImageButton()
    {

        this.gameObject.GetComponent<Canvas>().enabled = false;
        ShowCanvas.enabled = true;
    }
}
