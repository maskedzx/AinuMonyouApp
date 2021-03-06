﻿/* 
 * アイヌ文様のパーツそれぞれをpartsNumberで区別する
 * そのためにこのクラスはアイヌ文様に入れておく必要がある
 */
using UnityEngine;
using System.Collections;

public class patternParam : MonoBehaviour {
    public int partsNumber;
    private objectParam _objectParam;

    void Start()
    {
        _objectParam = new objectParam();

        sceneInit._patternParam.AddLast(this);
    }

    public objectParam PatternInfo()
    {
		try{
        _objectParam.PartsNumber = this.partsNumber;

			print("なぜか塗る"+this.gameObject.transform.localPosition);
		_objectParam.Position = this.gameObject.transform.localPosition;
			print(_objectParam.Position);
        _objectParam.Scale = this.gameObject.transform.localScale;
        _objectParam.Rotate = this.gameObject.transform.localRotation;
		}catch (MissingReferenceException e){
			print (e.Message);
			Debug.LogError (e.Message);
		}
        return _objectParam;
    }
}
