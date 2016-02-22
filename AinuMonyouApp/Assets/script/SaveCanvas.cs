using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;

public class SaveCanvas : MonoBehaviour {
    [SerializeField]
    private GameObject canvasObj;
    [SerializeField]
    private GameObject saveCanvasObj;
    [SerializeField]
    private GameObject saveButtonObj1;
    [SerializeField]
    private GameObject cancelButtonObj1;
    [SerializeField]
    private GameObject saveButtonObj2;
    [SerializeField]
    private GameObject cancelButtonObj2;
    [SerializeField]
    private InputField inputfield;
    [SerializeField]
    private GameObject inputfieldObj;
    [SerializeField]
    private GameObject TextObj;  


    private string path = "";
    private string fileName = "screenshot";
    public Text text;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void checkName(){
        fileName = inputfield.text;
        if(fileName == ""){
            fileName = "screenshot";
        }

        if (System.IO.File.Exists(fileName+".png")){
            Debug.Log("上書き");
            inputfieldObj.SetActive(false);
            TextObj.SetActive(true);
            saveButtonObj1.SetActive(false);
            saveButtonObj2.SetActive(true);
            cancelButtonObj1.SetActive(false);
            cancelButtonObj2.SetActive(true);
        } else {
            screenshot();
        }

    }

    public void saveButton(){
        screenshot();
    }

    public void cancelButton()
    {
        TextObj.SetActive(false);
        inputfieldObj.SetActive(true);
        saveButtonObj1.SetActive(true);
        saveButtonObj2.SetActive(false);
        cancelButtonObj1.SetActive(true);
        cancelButtonObj2.SetActive(false);
        inputfield.text = "";
    }

    void screenshot() {
        saveCanvasObj.GetComponent<Canvas>().enabled = false;
        Application.CaptureScreenshot("storage/emulated/0/Pictures/Screenshots/"+fileName + ".png");

        switch (Application.platform)
        {
            case RuntimePlatform.IPhonePlayer:
                path = Application.persistentDataPath + "/" + fileName + ".png";
                break;

            case RuntimePlatform.Android:
                path = Application.persistentDataPath + "/" + fileName + ".png";
                break;

            default:
                path = "/" + fileName + ".png";
                break;
        }

        Debug.Log("path:" + path);
        saveCanvasObj.GetComponent<Canvas>().enabled = true;
        text.text = path;

        

        //byte[] image = File.ReadAllBytes(path);

        //Texture2D tex = new Texture2D(0, 0);
        //tex.LoadImage(image);



        //canvasObj.SetActive(true);
        //saveCanvasObj.GetComponent<Canvas>().enabled = false;
    }
}
