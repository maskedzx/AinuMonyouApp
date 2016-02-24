using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
public class sceneInit : MonoBehaviour
{

    public GameObject[] _objects;
    public appParam _appParam;
    public static LinkedList<patternParam> _patternParam = new LinkedList<patternParam>();

    public void SaveInit()
    {
		
        _appParam = new appParam(_patternParam.Count);
        print(_patternParam.Count+"test");

		BGColor bgColor = FindObjectOfType<BGColor> ();
		_appParam.BackGroundRGB = new Vector3 (bgColor.Bgred,bgColor.Bggreen,bgColor.Bgblue);
		PartsColor part = FindObjectOfType<PartsColor> ();
		_appParam.PartsRGB = new Vector3(part.Red,part.Green,part.Blue);

        _appParam.designName = "nonameDesign";
        int i = 0;
        foreach(patternParam pp in _patternParam)
        { 
            _appParam.link[i++] = pp.PatternInfo();
        }
        //_appParam.statusList

        //_appParam.statusList = new objectParam[_objects.Length];


        //_appParam.BackGroundRGB = ここでRGB指定する予定
        //_appParam.PartsRGB=
    }

    public string Name
    {
        get { return _appParam.designName; }
        set { _appParam.designName = value; }
    }
}
