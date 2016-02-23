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
        _appParam.designName = "nonameDesign";
        int i = 0;
        foreach(patternParam pp in _patternParam)
        { 
            _appParam.link[i++] = pp.PatternInfo();
        }
        //_appParam.statusList

        //_appParam.statusList = new objectParam[_objects.Length];


        //param.BackGroundRGB = ここでRGB指定する予定
        //param.PartsRGB=
    }

    public string Name
    {
        get { return _appParam.designName; }
        set { _appParam.designName = value; }
    }
}
