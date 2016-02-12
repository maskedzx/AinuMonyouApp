using UnityEngine;
using System.Collections;

public class ButtonTap : MonoBehaviour {
    [SerializeField]
    private int buttonNo = 0;
    [SerializeField]
    private GameObject partsSpawner;
    private PartsSpawner ps;
    [SerializeField]
    private GameObject modeManegerObj;
    private ModeManegr mm;
    [SerializeField]
    private GameObject canvasObj;
    [SerializeField]
    private GameObject colorCanvasObj;
    [SerializeField]
    private GameObject RedSlider;
    [SerializeField]
    private GameObject GreenSlider;
    [SerializeField]
    private GameObject BlueSlider;
    private ColorSlider rcs;
    private ColorSlider gcs;
    private ColorSlider bcs;

    void Awake(){
        ps = partsSpawner.GetComponent<PartsSpawner>();
        mm = modeManegerObj.GetComponent<ModeManegr>();
        rcs = RedSlider.GetComponent<ColorSlider>();
        gcs = GreenSlider.GetComponent<ColorSlider>();
        bcs = BlueSlider.GetComponent<ColorSlider>();

    }

	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void partsSet(){
        ps.partsSpawn(buttonNo);
    }

    public void changeMode(){
        if (ps.MoveMode == true){
            ps.MoveMode = false;
        } else {
            ps.MoveMode = true;
        }
    }

    public void ModePartsColor(){
        mm.IsMove = false;
        canvasObj.SetActive(false);
        colorCanvasObj.GetComponent<Canvas>().enabled = true;
    }

    public void AddColor(){
        mm.IsMove = true;
        canvasObj.SetActive(true);
        colorCanvasObj.GetComponent<Canvas>().enabled = false;
        rcs.TmpLevel = rcs.Level;
        gcs.TmpLevel = gcs.Level;
        bcs.TmpLevel = bcs.Level;
    }

    public void CancelColor(){
        mm.IsMove = true;
        canvasObj.SetActive(true);
        colorCanvasObj.GetComponent<Canvas>().enabled = false;
        rcs.Level = rcs.TmpLevel;
        gcs.Level = gcs.TmpLevel;
        bcs.Level = bcs.TmpLevel;
        rcs.CanselColor();
        gcs.CanselColor();
        bcs.CanselColor();
    }

}
