using UnityEngine;
using System.Collections;

public class GraphPositionData : MonoBehaviour
{

    /*画面上の画像1つにつきこのクラスが呼び出されるようにする*/
    public int Number { get; set; }//何番目に生成されたか
    public int GraphType { get; set; }//模様の種類はなにか
    public int Sort { get; set; }//手前に表示される順番はなにか
    public float PositionX { get; set; }//X位置はいくつか
    public float PositionY { get; set; }//Y位置はいくつか
    public float Rotation { get; set; }//角度はいくつか（２Dだから２つ以上考えなくてもいい）
    public float ScaleX { get; set; }//Xのスケールはいくつか
    public float ScaleY { get; set; }//Yのスケールはいくつか
    public float ScalePlusTheta { get; set; }//右上左下方向へのスケールはいくつか
    public float ScaleMinusTheta { get; set; }//左上右下方向へのスケールはいくつか

    void Awake()
    {
        Number = 0;
        GraphType = 0;
        Sort = 0;
        PositionX = 0;
        PositionY = 0;
        Rotation = 0;
        ScaleX = 0;
        ScaleY = 0;
        ScalePlusTheta = 0;
        ScaleMinusTheta = 0;
    }
}
