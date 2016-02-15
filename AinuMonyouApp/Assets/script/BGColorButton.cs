using UnityEngine;
using System.Collections;

public class BGColorButton : MonoBehaviour {
    [SerializeField]
    private GameObject modeManegerObj;
    private ModeManegr mm;
    [SerializeField]
    private GameObject canvasObj;
    [SerializeField]
    private GameObject bgcolorCanvasObj;

    void Awake()
    {
        mm = modeManegerObj.GetComponent<ModeManegr>();
    }


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ModeBGColor()
    {
        mm.IsMove = false;
        canvasObj.SetActive(false);
        bgcolorCanvasObj.GetComponent<Canvas>().enabled = true;
    }
}
