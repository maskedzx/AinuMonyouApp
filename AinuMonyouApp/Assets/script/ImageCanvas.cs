using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ImageCanvas : MonoBehaviour {

    private Image bigImage;
    [SerializeField]
    private GameObject ShowCanvas;

    void Start()
    {
        this.gameObject.GetComponent<Canvas>().enabled = false;
    }

    public void ImageButton()
    {

        this.gameObject.GetComponent<Canvas>().enabled = false;
        ShowCanvas.SetActive(true);
    }
}
