using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DebugText : MonoBehaviour {

    [SerializeField]
    private GameObject partsSpawner;
    private PartsSpawner ps;
    private bool moveMode;
    [SerializeField]
    private GameObject modeManegerObj;
    private ModeManegr mm;
    [SerializeField]
    private bool isMove;
    private Text text;
    [SerializeField]
    private GameObject textObj;
    
    void Awake(){
        text = textObj.GetComponent<Text>();
        partsSpawner = GameObject.Find("PartsSpawner");
        ps = partsSpawner.GetComponent<PartsSpawner>();
        modeManegerObj = GameObject.Find("ModeManeger");
        mm = modeManegerObj.GetComponent<ModeManegr>();
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        text.text = ps.MoveMode.ToString() + ":" + mm.IsMove.ToString(); ;
    }
}
