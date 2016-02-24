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
    public GameObject Parent;
    void Start()
    {

        dir = new DirectoryInfo(Application.persistentDataPath);
        info = dir.GetFiles("*.json");
        Message = "アイヌ文様つくったよ！";
        URL = "";

        this.Number = Parent.GetComponent<LoadButtonParam>().Number;
        scroll = FindObjectOfType<ScrollController>();
        
    }

    public void TwitterButton()
    {
        print("ツイッターボタン");
        print(ImagePath);
        if (Application.platform != RuntimePlatform.WindowsEditor)
        {
            
            //folderPath = Application.persistentDataPath + "/" + titleText.text + ".png";
            ImagePath = Application.persistentDataPath + "/" + info[Number].Name.Substring(0, info[Number].Name.Length - 5);
        }
        else
        {
            ImagePath = Application.dataPath + "/" + info[Number].Name.Substring(0, info[Number].Name.Length - 5);
            print("persistent"+Application.dataPath+"/"+ info[Number].Name.Substring(0, info[Number].Name.Length - 5));
        }
        SWorker.SocialWorker.PostTwitter(Message, URL, ImagePath + ".png");
    }
}
