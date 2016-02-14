using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RotateButton : MonoBehaviour {
    [SerializeField]
    private GameObject partsSpawner;
    private PartsSpawner ps;
    [SerializeField]
    private GameObject changeModeTextObj;
    private Text changeModeText;

    void Awake(){
        ps = partsSpawner.GetComponent<PartsSpawner>();
        changeModeText = changeModeTextObj.GetComponent<Text>();
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void changeMode()
    {
        if (ps.MoveMode == true)
        {
            ps.MoveMode = false;
            changeModeText.text = ("サイズ");
        }
        else {
            ps.MoveMode = true;
            changeModeText.text = ("回転");
        }
    }
}
