using UnityEngine;
using System.Collections;

public class ColorButton : MonoBehaviour {
    [SerializeField]
    private GameObject modeManegerObj;
    private ModeManegr mm;
    [SerializeField]
    private GameObject canvasObj;
    [SerializeField]
    private GameObject colorCanvasObj;

    void Awake(){
        mm = modeManegerObj.GetComponent<ModeManegr>();
    }


    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ModePartsColor(){
        mm.IsMove = false;
        canvasObj.SetActive(false);
        colorCanvasObj.GetComponent<Canvas>().enabled = true;
    }
}
