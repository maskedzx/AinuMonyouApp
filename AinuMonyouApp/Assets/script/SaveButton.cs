using UnityEngine;
using System.Collections;

public class SaveButton : MonoBehaviour {

    [SerializeField]
    private GameObject canvasObj;
    [SerializeField]
    private GameObject saveCanvasObj;
    [SerializeField]
    private GameObject modeManegerObj;
    private ModeManegr mm;

    void Awake()
    {
        mm = modeManegerObj.GetComponent<ModeManegr>();
    }


    public void modeSave()
    {
        canvasObj.SetActive(false);
        saveCanvasObj.GetComponent<Canvas>().enabled = true;
        mm.IsMove = false;
    }

    public void saveCancel()
    {
        canvasObj.SetActive(true);
        saveCanvasObj.GetComponent<Canvas>().enabled = false;
        mm.IsMove = true;
    }

}
