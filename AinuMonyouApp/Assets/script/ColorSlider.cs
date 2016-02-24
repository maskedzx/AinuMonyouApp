using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ColorSlider : MonoBehaviour {
    private Slider slider;
    private float level;
    public float Level{
        set { this.level = value; }
        get { return this.level; }
    }
    private float tmpLevel = 0;
    public float TmpLevel{
        set { this.tmpLevel = value; }
        get { return this.tmpLevel; }
    }

	// Use this for initialization
	void Start () {
        slider = GetComponent<Slider>();
        slider.value = tmpLevel;

	}
	
	// Update is called once per frame
	void Update () {
        level = slider.value;
	}

    public void CanselColor(){
        slider.value = tmpLevel;
    }

    public void LoadParts(float f)
    {
        slider.value = f;
        tmpLevel = f;
    }
}
