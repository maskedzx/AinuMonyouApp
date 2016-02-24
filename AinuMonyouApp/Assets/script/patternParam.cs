/* 
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
        _objectParam.PartsNumber = this.partsNumber;
        _objectParam.Position = this.gameObject.transform.localPosition;
        _objectParam.Scale = this.gameObject.transform.localScale;
        _objectParam.Rotate = this.gameObject.transform.localRotation;

        return _objectParam;
    }
}
