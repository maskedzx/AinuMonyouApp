using UnityEngine;
using System.Collections;

public class ButtonTap : MonoBehaviour {
    [SerializeField]
    private int buttonNo = 0;
    [SerializeField]
    private GameObject partsSpawner;
    private PartsSpawner ps;

    void Awake(){
        ps = partsSpawner.GetComponent<PartsSpawner>();
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

}
