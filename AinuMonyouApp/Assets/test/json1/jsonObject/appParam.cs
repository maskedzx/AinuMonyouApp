using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

[Serializable]
public class appParam
{

    public objectParam[] link;
    public Vector3 BackGroundRGB;
    public Vector3 PartsRGB;
    public string designName;
 
	public appParam(int i){
        link = new objectParam[i];

    }

}
