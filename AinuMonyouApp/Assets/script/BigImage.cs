using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BigImage : MonoBehaviour {

    private Image bigImage;
    private GameObject ImageCanvasObj;
    private Canvas ImageCanvas;
    [SerializeField]
    private GameObject ShowCanvas;
    [SerializeField]
    private GameObject ImageObj;
    private Image screen;
   
    void Awake()
    {
        ImageCanvasObj = GameObject.Find("ImageCanvas");
        bigImage = ImageCanvasObj.GetComponent<Image>();
        screen = ImageObj.GetComponent<Image>();
    }

	public void ImageButton() {
        bigImage.sprite = screen.sprite;
        ImageCanvasObj.GetComponent<Canvas>().enabled = true;
        ShowCanvas.SetActive(false);
	}
}
