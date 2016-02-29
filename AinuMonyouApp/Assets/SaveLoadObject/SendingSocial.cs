using UnityEngine;
using System.Collections;
using System.IO;
public class SendingSocial : MonoBehaviour
{

    private string Message;
    private string URL;
    private string ImagePath;
    private DirectoryInfo dir;
    private FileInfo[] info;
    private ScrollController scroll;
    private int Number;

    public GameObject NodePrefab;

    void Start()
    {

        dir = new DirectoryInfo(Application.persistentDataPath);
        info = dir.GetFiles("*.json");
        Message = "アイヌ文様つくったよ！ #AinuMonyouDesign";
        URL = "";

        this.Number = NodePrefab.GetComponent<LoadButtonParam>().Number;
        scroll = FindObjectOfType<ScrollController>();

    }

    public void SnsButton()
    {
        print("共有ボタン");
        print(ImagePath);
        if (Application.platform != RuntimePlatform.WindowsEditor)
        {
            ImagePath = Application.persistentDataPath + "/" + info[Number].Name.Substring(0, info[Number].Name.Length - 5);
        }
        else
        {
            ImagePath = Application.dataPath + "/" + info[Number].Name.Substring(0, info[Number].Name.Length - 5);
            print("WindowsEditor時のアクセス場所:::" + Application.dataPath + "/" + info[Number].Name.Substring(0, info[Number].Name.Length - 5));
        }
        SWorker.SocialWorker.CreateChooser(Message, ImagePath + ".png");
    }
}
