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


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        bgred = bgrcs.Level;
        bggreen = bggcs.Level;
        bgblue = bgbcs.Level;
        sp.color = new Color(bgred / 255, bggreen / 255, bgblue / 255);

    }
}
