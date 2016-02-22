using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

[Serializable]
public class appParam
{
    //public LinkedList<objectParam> link;

    public objectParam[] link;
    public Vector3 BackGroundRGB;
    public Vector3 PartsRGB;
    public string designName;
    public appParam(int i){
        //link = new LinkedList<objectParam>();
        link = new objectParam[i];

    }

}
