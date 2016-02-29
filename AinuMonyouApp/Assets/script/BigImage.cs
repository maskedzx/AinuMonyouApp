using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BigImage : MonoBehaviour
{

    private Image bigImage;
    private GameObject ImageCanvasObj;
    private Image screen;

    public GameObject ShowCanvas;
    public GameObject ImageObj;

    void Awake()
    {
        ImageCanvasObj = GameObject.Find("ImageCanvas");
        bigImage = ImageCanvasObj.GetComponent<Image>();
        screen = ImageObj.GetComponent<Image>();
    }

    public void ImageButton()
    {
        bigImage.sprite = screen.sprite;
        ImageCanvasObj.GetComponent<Canvas>().enabled = true;
        ShowCanvas.SetActive(false);
    }
}
