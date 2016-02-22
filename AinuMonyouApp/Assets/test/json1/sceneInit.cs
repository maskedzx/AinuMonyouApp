using UnityEngine;
using System.Collections;
using System.IO;
public class SceneInit : MonoBehaviour
{

    public GameObject[] _objects;
    public appParam _appParam;
    public static objectParam[] _objectParam;

    public void SaveInit()
    {
        _appParam = new appParam();
        _appParam.designName = "ainuDesign";


        foreach(objectParam op in _objectParam)
        {

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
        get { return null; }
        set { _appParam.designName = value; }
    }
}
