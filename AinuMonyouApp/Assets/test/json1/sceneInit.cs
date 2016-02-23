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

        /*DirectoryInfo dir = new DirectoryInfo(Application.persistentDataPath);
        FileInfo[] info = dir.GetFiles("*.json");
        foreach (FileInfo f in info)
        {
            print(f.Name);
        }*/
        //_appParam.statusList

        //_appParam.statusList = new objectParam[_objects.Length];


        //param.BackGroundRGB = ここでRGB指定する予定
        //param.PartsRGB=
        /*
        for (int i = 0; i < _objects.Length; i++)
        {
            _objectParam = new objectParam();
            _objectParam.Number = i;
            _objectParam.Position = _objects[i].transform.localPosition;
            _objectParam.Scale = _objects[i].transform.localScale;
            _objectParam.Rotate = _objects[i].transform.localRotation;

            _appParam.statusList[i] = _objectParam;

            _appParam.link.AddLast(_objectParam);
        }*/
    }

    public string Name
    {
        get { return _appParam.designName; }
        set { _appParam.designName = value; }
    }
}
