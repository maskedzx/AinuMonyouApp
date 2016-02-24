using UnityEngine;
using System.Collections;

public class BGColor : MonoBehaviour {
    [SerializeField]
    private GameObject BGRedSlider;
    private GameObject BGGreenSlider;
    private GameObject BGBlueSlider;
    private BGColorSlider bgrcs;
    private BGColorSlider bggcs;
    private BGColorSlider bgbcs;
    private SpriteRenderer sp;

    [SerializeField]
    private float bgred;
    [SerializeField]
    private float bgblue;
    [SerializeField]
    private float bggreen;

    public float Bgred{
        set { this.bgred = value;}
        get { return this.bgred; }
    }
    public float Bggreen{
        set { this.bggreen = value; }
        get { return this.bggreen; }
    }
    public float Bgblue{
        set { this.bgblue = value; }
        get { return this.bgblue; }
    }

    void Awake()
    {
        BGRedSlider = GameObject.Find("BGRedSlider");
        bgrcs = BGRedSlider.GetComponent<BGColorSlider>();
        BGGreenSlider = GameObject.Find("BGGreenSlider");
        bggcs = BGGreenSlider.GetComponent<BGColorSlider>();
        BGBlueSlider = GameObject.Find("BGBlueSlider");
        bgbcs = BGBlueSlider.GetComponent<BGColorSlider>();
        sp = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        bgred = bgrcs.Level;
        bggreen = bggcs.Level;
        bgblue = bgbcs.Level;
        sp.color = new Color(bgred / 255, bggreen / 255, bgblue / 255);

    }
}
