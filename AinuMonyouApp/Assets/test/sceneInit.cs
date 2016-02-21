using UnityEngine;
using System.Collections;

public class sceneInit : MonoBehaviour {

    public GameObject[] objects;
    public appParam param;

	void Start () {
        param = new appParam();
        param.statusList = new objectParam[objects.Length];
        param.designName = "JSON Serializer Test";


        //param.BackGroundRGB = ここでRGB指定する予定
        //param.PartsRGB=

        for(int i = 0; i < objects.Length; i++)
        {
            objectParam objParam = new objectParam();
            objParam.Number = i;
            objParam.Position = objects[i].transform.localPosition;
            objParam.Scale = objects[i].transform.localScale;
            objParam.Rotate = objects[i].transform.localRotation;

            param.statusList[i] = objParam;
        }
	}
}
