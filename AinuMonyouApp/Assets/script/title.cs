using UnityEngine;
using System.Collections;

public class title : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(Application.platform == RuntimePlatform.Android){
            if(Input.GetKey(KeyCode.Home)|| Input.GetKey(KeyCode.Escape) || Input.GetKey(KeyCode.Menu))
            {
                Application.Quit();
                return;
            }
        }
	}

    public void makeButton()
    {
        Application.LoadLevel("make");
    }

    public void showButton()
    {
        Application.LoadLevel("show");
    }
}
