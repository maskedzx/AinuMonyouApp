using UnityEngine;
using System.Collections;

public class DustCanvas : MonoBehaviour {

    [SerializeField]
    private GameObject canvasObj;
    [SerializeField]
    private GameObject dustCanvasObj;
    [SerializeField]
    private GameObject dustObj;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void EndDust()
    {
        canvasObj.SetActive(true);
        dustCanvasObj.GetComponent<Canvas>().enabled = false;
        dustObj.SetActive(false);
    }
}
