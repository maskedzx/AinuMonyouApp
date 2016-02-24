using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PatternRetention : MonoBehaviour
{

    public GameObject moreu1;
    public GameObject moreu2;
    public GameObject shiku;
    public GameObject aiushi;
    private PartsColor _moreu1;
    private PartsColor _moreu2;
    private PartsColor _shiku;
    private PartsColor _aiushi;

    public Vector3 BackGroundRGB;
    public Vector3 PartsRGB;
    public string designName;
    public objectParam[] _objectParam;

    private appParam _appParam;
    private static PatternRetention mInstar;

    private bool flag = false;

    private GameObject BGRedSlider;
    private GameObject BGGreenSlider;
    private GameObject BGBlueSlider;
    private BGColorSlider bgrcs;
    private BGColorSlider bggcs;
    private BGColorSlider bgbcs;

    private PatternRetention()
    {
        print("Create singleton gameobject instance");
    }
    public static PatternRetention Instance
    {
        get
        {
            if (mInstar == null)
            {
                GameObject go = new GameObject("PatternRetention");
                mInstar = go.AddComponent<PatternRetention>();
            }
            return mInstar;
        }
    }

    void Start()
    {
        DontDestroyOnLoad(this);
        flag = false;
        _moreu1 = moreu1.GetComponent<PartsColor>();
        _moreu2 = moreu2.GetComponent<PartsColor>();
        _shiku = shiku.GetComponent<PartsColor>();
        _aiushi = shiku.GetComponent<PartsColor>();
    }
    void Update()
    {
        if (!flag && Application.loadedLevelName == "make")
        {
            flag = true;
            StartCoroutine("InstanceObjectCoroutine");
            print("シーンがmakeに切り替わった");
        }
    }

    private IEnumerator InstanceObjectCoroutine()
    {
        BGRedSlider = GameObject.Find("BGRedSlider");
        bgrcs = BGRedSlider.GetComponent<BGColorSlider>();
        BGGreenSlider = GameObject.Find("BGGreenSlider");
        bggcs = BGGreenSlider.GetComponent<BGColorSlider>();
        BGBlueSlider = GameObject.Find("BGBlueSlider");
        bgbcs = BGBlueSlider.GetComponent<BGColorSlider>();

        bgrcs.LoadColor(BackGroundRGB.x);
        bggcs.LoadColor(BackGroundRGB.y);
        bgbcs.LoadColor(BackGroundRGB.z);

        yield return null;
        PartsColor[] partsColor = FindObjectsOfType<PartsColor>();
        if (_objectParam.Length > 0)
        {
            ColorSlider partsRed = GameObject.Find("RedSlider").GetComponent<ColorSlider>();
            ColorSlider partsGreen = GameObject.Find("RedSlider").GetComponent<ColorSlider>();
            ColorSlider partsBlue = GameObject.Find("RedSlider").GetComponent<ColorSlider>();
            partsRed.LoadParts(PartsRGB.x);
            partsGreen.LoadParts(PartsRGB.y);
            partsBlue.LoadParts(PartsRGB.z);
            print(partsRed);
            yield return null;
            print(_objectParam.Length + "_objectParam.lengthの数");
            for (int i = 0; i < _objectParam.Length; i++)
            {
                
                //partsColor[i].Red = PartsRGB.x;
                //partsColor[i].Green = PartsRGB.y;
                //partsColor[i].Blue = PartsRGB.z;
                //print ("partsColor:::" + partsColor [i].Red + " " + partsColor [i].Green + " " + partsColor [i].Blue);
                switch (_objectParam[i].PartsNumber)
                {
                    case 0:
                        moreu1.transform.localScale = _objectParam[i].Scale;
                        //_moreu1.Red = PartsRGB.x;
                       // _moreu1.Green = PartsRGB.y;
                       // _moreu1.Blue = PartsRGB.z;
                        Instantiate(moreu1, _objectParam[i].Position, _objectParam[i].Rotate);
                        break;
                    case 1:
                        moreu2.transform.localScale = _objectParam[i].Scale;
                        _moreu2.Red = PartsRGB.x;
                        _moreu2.Green = PartsRGB.y;
                        _moreu2.Blue = PartsRGB.z;
                        Instantiate(moreu2, _objectParam[i].Position, _objectParam[i].Rotate);
                        break;
                    case 2:
                        shiku.transform.localScale = _objectParam[i].Scale;
                        _shiku.Red = PartsRGB.x;
                        _shiku.Green = PartsRGB.y;
                        _shiku.Blue = PartsRGB.z;
                        Instantiate(shiku, _objectParam[i].Position, _objectParam[i].Rotate);
                        break;
                    case 3:
                        aiushi.transform.localScale = _objectParam[i].Scale;
                        _aiushi.Red = PartsRGB.x;
                        _aiushi.Green = PartsRGB.y;
                        _aiushi.Blue = PartsRGB.z;
                        Instantiate(aiushi, _objectParam[i].Position, _objectParam[i].Rotate);
                        break;
                    default:
                        print("error発生：本来選択できるパーツ以外の番号がしてされた");
                        break;
                }
                moreu1.transform.localScale = Vector3.one;
                moreu2.transform.localScale = Vector3.one;
                shiku.transform.localScale = Vector3.one;
                aiushi.transform.localScale = Vector3.one;
                yield return null;
            }
        }
        Destroy(this.gameObject);
    }

}
