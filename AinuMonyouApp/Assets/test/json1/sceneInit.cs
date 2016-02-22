using UnityEngine;
using System.Collections;

public class sceneInit : MonoBehaviour {

    public GameObject[] objects;
    public appParam param;
	public objectParam objParam;
	void Start () {
		string str = "ainuDesign"; 

        param = new appParam();
        param.statusList = new objectParam[objects.Length];
        param.designName = str;

        //param.BackGroundRGB = ここでRGB指定する予定
        //param.PartsRGB=

        for(int i = 0; i < objects.Length; i++)
        {
            objParam = new objectParam();
            objParam.Number = i;
            objParam.Position = objects[i].transform.localPosition;
            objParam.Scale = objects[i].transform.localScale;
            objParam.Rotate = objects[i].transform.localRotation;

            param.statusList[i] = objParam;

			param.link.AddLast (objParam);
        }
	}

	public string Name{
		get{return null;}
		set{param.designName = value; }
	}
}
