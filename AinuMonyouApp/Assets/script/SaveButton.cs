using UnityEngine;
using System.Collections;

public class SaveButton : MonoBehaviour {

    [SerializeField]
    private GameObject canvasObj;
    [SerializeField]
    private GameObject saveCanvasObj;


    public void modeSave()
    {
        canvasObj.SetActive(false);
        saveCanvasObj.GetComponent<Canvas>().enabled = true;
    }

    public void saveCancel()
    {
        canvasObj.SetActive(true);
        saveCanvasObj.GetComponent<Canvas>().enabled = false;
    }

}
