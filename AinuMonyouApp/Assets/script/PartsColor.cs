using UnityEngine;
using System.Collections;

public class PartsColor : MonoBehaviour {
    [SerializeField]
    private GameObject RedSlider;
    private GameObject GreenSlider;
    private GameObject BlueSlider;
    private ColorSlider rcs;
    private ColorSlider gcs;
    private ColorSlider bcs;
    private SpriteRenderer sp;

    [SerializeField]
    private float red;
    [SerializeField]
    private float blue;
    [SerializeField]
    private float green;

    void Awake(){
        RedSlider = GameObject.Find("RedSlider");
        rcs = RedSlider.GetComponent<ColorSlider>();
        GreenSlider = GameObject.Find("GreenSlider");
        gcs = GreenSlider.GetComponent<ColorSlider>();
        BlueSlider = GameObject.Find("BlueSlider");
        bcs = BlueSlider.GetComponent<ColorSlider>();
        sp = GetComponent<SpriteRenderer>();
    }


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        red = rcs.Level;
        green = gcs.Level;
        blue = bcs.Level;
        sp.color = new Color(red/255, green/255, blue/255);
	
	}
}
