using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System;
public class sceneInit : MonoBehaviour
{

    public GameObject[] _objects;
    public appParam _appParam;
	public static LinkedList<patternParam> _patternParam;

	void Start(){
		_patternParam = new LinkedList<patternParam>();
	}
    public void SaveInit()
    {
		
        _appParam = new appParam(_patternParam.Count);
		print(_patternParam.Count);

		BGColor bgColor = FindObjectOfType<BGColor> ();
		_appParam.BackGroundRGB = new Vector3 (bgColor.Bgred,bgColor.Bggreen,bgColor.Bgblue);
		_appParam.designName = "nonameDesign";

		try{
		PartsColor part = FindObjectOfType<PartsColor> ();
		_appParam.PartsRGB = new Vector3(part.Red,part.Green,part.Blue);

		}catch(Exception e){
			print(e.Message);
			_appParam.PartsRGB = Vector3.zero;
		}
        int i = 0;
        foreach(patternParam pp in _patternParam)
        { 
            _appParam.link[i++] = pp.PatternInfo();
        }
    }

    public string Name
    {
        get { return _appParam.designName; }
        set { _appParam.designName = value; }
    }
}
