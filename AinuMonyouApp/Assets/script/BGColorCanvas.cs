using UnityEngine;
using System.Collections;

public class BGColorCanvas : MonoBehaviour {
    [SerializeField]
    private GameObject modeManegerObj;
    private ModeManegr mm;
    [SerializeField]
    private GameObject canvasObj;
    [SerializeField]
    private GameObject bgcolorCanvasObj;
    [SerializeField]
    private GameObject BGRedSlider;
    [SerializeField]
    private GameObject BGGreenSlider;
    [SerializeField]
    private GameObject BGBlueSlider;
    private BGColorSlider bgrcs;
    private BGColorSlider bggcs;
    private BGColorSlider bgbcs;

    void Awake()
    {
        mm = modeManegerObj.GetComponent<ModeManegr>();
        bgrcs = BGRedSlider.GetComponent<BGColorSlider>();
        bggcs = BGGreenSlider.GetComponent<BGColorSlider>();
        bgbcs = BGBlueSlider.GetComponent<BGColorSlider>();

    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddColor()
    {
        mm.IsMove = true;
        canvasObj.SetActive(true);
        bgcolorCanvasObj.GetComponent<Canvas>().enabled = false;
        bgrcs.TmpLevel = bgrcs.Level;
        bggcs.TmpLevel = bggcs.Level;
        bgbcs.TmpLevel = bgbcs.Level;
    }

    public void CancelColor()
    {
        mm.IsMove = true;
        canvasObj.SetActive(true);
        bgcolorCanvasObj.GetComponent<Canvas>().enabled = false;
        bgrcs.Level = bgrcs.TmpLevel;
        bggcs.Level = bggcs.TmpLevel;
        bgbcs.Level = bgbcs.TmpLevel;
        bgrcs.CanselColor();
        bggcs.CanselColor();
        bgbcs.CanselColor();
    }
}
