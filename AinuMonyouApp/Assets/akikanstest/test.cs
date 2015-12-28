using UnityEngine;
using System.Collections;
using LitJson;
using System.IO;
using System.Collections.Generic;

public class test : MonoBehaviour
{

    public static readonly string NAME = "data";

    private object obj;

    private List<GraphPositionData> DataList;

    /// <summary>
    /// 1体のデータを書き出す。
    /// </summary>
    public void Write(GraphPositionData graphPositionData)
    {
        DataList.Add(graphPositionData);
    }

    /// <summary>
    /// ファイルに書き出す
    /// </summary>
    public void FileWrite(string name)
    {
        string json = JsonMapper.ToJson(DataList);
        string path;
        print(json);

        try {
            if (Application.platform == RuntimePlatform.WindowsEditor)
            {
                path = Application.persistentDataPath + "/Database/";
            }
            else if (Application.platform == RuntimePlatform.WindowsPlayer)
            {
                path = Application.persistentDataPath + "/Database/";
            }
            else if (Application.platform == RuntimePlatform.IPhonePlayer)
            {
                path = Application.persistentDataPath + "/Database/";
            }
            else if (Application.platform == RuntimePlatform.Android)
            {
                path = Application.persistentDataPath + "/Database/";
            }
            else
            {
                path = null;
            }

            File.WriteAllText(path + name + ".json", json);
            DataList.Clear();
        }
        catch (IOException e)
        {
            path = null;
            print("例外処理発生");
            print(e.Message);
        }
            
    }

    void Start()
    {
        DataList = new List<GraphPositionData>();


        att();//debug

        FileWrite(NAME);

    }

    void att()
    {
        GraphPositionData te = new GraphPositionData();
        te.Number = 1;
        te.GraphType = 1;
        te.Sort = 2;
        te.PositionX = 40;
        te.PositionY = 32;
        te.Rotation = 200;
        te.ScaleX = 1;
        te.ScaleY = 1;
        te.ScalePlusTheta = 1;
        te.ScaleMinusTheta = 1;
    }
}
