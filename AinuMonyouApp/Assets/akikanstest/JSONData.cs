using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class JSONData : MonoBehaviour
{

    public GraphPositionData[] gpd;

    public Canvas dialogCanvas;

    public Canvas mainCanvas;

    void Awake()
    {
        dialogCanvas.enabled = false;
    }

    public void SaveButton()//保存をおした時
    {
        //保存ダイアログを表示する
        //その際に他のボタンを押せないようにする

        dialogCanvas.enabled = true;
    }

    public void SaveDialog()//保存ダイアログ
    {

    }
    public void NoSaveDialog()
    {
        dialogCanvas.enabled = false;
    }
}