/* 笹谷作成
 * アイヌ文様のパーツそれぞれをpartsNumberで区別する
 * 
 */
using UnityEngine;
using System.Collections;

public class patternParam : MonoBehaviour {
    [SerializeField]
    private int partsNumber;
    public objectParam _objectParam;

    void Start()
    {
        _objectParam = new objectParam();

    }

    public objectParam PatternInfo()
    {
        
        _objectParam.Position = this.gameObject.transform.localPosition;
        _objectParam.Scale = this.gameObject.transform.localScale;
        _objectParam.Rotate = this.gameObject.transform.localRotation;

        return _objectParam;
    }
}
