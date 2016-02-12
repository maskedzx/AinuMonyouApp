using UnityEngine;
using System.Collections;

public class ModeManegr : MonoBehaviour {
    private bool isMove = true;
    public bool IsMove{
        set { this.isMove = value; }
        get { return this.isMove; }
    }
    [SerializeField]
    private GameObject colorCanvasObj;



	// Use this for initialization
	void Start () {
        colorCanvasObj.GetComponent<Canvas>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
