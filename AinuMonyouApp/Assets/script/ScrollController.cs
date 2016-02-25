using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;
using System;

public class ScrollController : MonoBehaviour
{
    public Image deleteButton;
    public GameObject dontDestroyObject;
    public GameObject DeleteCheckUI;

    private bool deleteOrEdit;
    [SerializeField]
    RectTransform prefab;
    private DirectoryInfo dir;
    private FileInfo[] info;
    private RectTransform item;
    private LoadButtonParam _loadButtonParam;
    private AsyncOperation op;

    private string ImagePath;

    void Start()
    {
        deleteOrEdit = true;
        dir = new DirectoryInfo(Application.persistentDataPath);
        info = dir.GetFiles("*.json");
        StartCoroutine("LoadCoroutine");

        op = SceneManager.LoadSceneAsync("title");
        op.allowSceneActivation = false;

        DeleteCheckUI.SetActive(false);

    }

    private IEnumerator LoadCoroutine()
    {
        int i = 0;
        foreach (FileInfo f in info)
        {
            item = Instantiate(prefab) as RectTransform;
            item.SetParent(transform, false);
            Text titleText = item.GetComponentInChildren<Text>();
            titleText.text = f.Name.Substring(0, f.Name.Length - 5);

            item.gameObject.GetComponent<LoadButtonParam>().Number = i++;
            _loadButtonParam = item.gameObject.GetComponent<LoadButtonParam>();



            string folderPath = "";
            try
            {
                
                if (Application.platform != RuntimePlatform.WindowsEditor)
                {
                    folderPath = Application.persistentDataPath + "/" + titleText.text + ".png";
                }
				else if(Application.platform == RuntimePlatform.OSXEditor)
				{
					folderPath = Application.dataPath + "/../" + titleText.text + ".png";
				}else
                {
                    folderPath = Application.dataPath + "/../" + titleText.text + ".png";
                }
                byte[] by = File.ReadAllBytes(folderPath);

                Texture2D tex = new Texture2D(0, 0);
                tex.LoadImage(by);

                GameObject sun = item.transform.FindChild("ScreenShot").gameObject;
                Image image = sun.GetComponent<Image>();
                image.sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height),Vector2.zero);
            }
            catch (Exception e)
            {
                print(e.Message);
            }

            yield return null;
        }
    }

    public void LoadAinu(int i)
    {
        string str = info[i].Name;
        string st = str.Substring(0, str.Length - 5);
        Instantiate(dontDestroyObject);
        appParam _appParam = jsonSystem.Load(st);
        print("アプリ情報:::名前:" + _appParam.designName + " パーツRGB:" + _appParam.PartsRGB + "背景RGB:" + _appParam.BackGroundRGB);
        PatternRetention pr = FindObjectOfType<PatternRetention>();

        pr.designName = _appParam.designName;
        pr.BackGroundRGB = _appParam.BackGroundRGB;
        pr.PartsRGB = _appParam.PartsRGB;
        print("pr.designName:" + pr.designName + " pr.BackGroundRGB:" + pr.BackGroundRGB + "pr.PartsRGB:" + pr.PartsRGB);
        pr._objectParam = new objectParam[_appParam.link.Length];
        try
        {
            for (int j = 0; j < _appParam.link.Length; j++)
            {
                pr._objectParam[j] = _appParam.link[j];
                print("パーツ情報:::パーツ番号:" + pr._objectParam[j].PartsNumber + " position:" + pr._objectParam[j].Position + " scale:" + pr._objectParam[j].Scale + " rotate:" + pr._objectParam[j].Rotate);

            }
        }
        catch (Exception e)
        {
            print("オブジェクトがひとつもなかったよ");
            print(e.Message);
        }
        finally
        {
            SceneManager.LoadScene("make");
        }
    }

    public void DeleteEnterButton()
    {
        if (deleteOrEdit)
        {
            //deleteButton.color = new Color(0, 96, 96);
            
        }
        else {
           // deleteButton.color = new Color(255f / 255f, 96f / 255f, 96f / 255f);
        }
        DeleteCheckUI.SetActive(true);
        deleteOrEdit = !deleteOrEdit;
    }

    public void BackSceneButton()
    {
        op.allowSceneActivation = true;
    }

    public void CancelButton()
    {
        DeleteCheckUI.SetActive(false);

    }

	public void EnterDelete(){
		GameObject[] dlt = GameObject.FindGameObjectsWithTag ("Node");
		int i = 0;
		foreach (GameObject g in dlt) {
			if (!g.GetComponentInChildren<Toggle> ().isOn) {
				print ("コンティニュー");
				i++;
				continue;
			} 
			else 
			{
				print ("デリート:::" + info [i]);
				//File.Delete (info [dlt.Length].Name);
				if (info[i].Exists){
					if ((info [i].Attributes&FileAttributes.ReadOnly) == FileAttributes.ReadOnly) {
						info [i].Attributes = FileAttributes.Normal;
					}
                    if (Application.platform != RuntimePlatform.WindowsEditor)
                    {

                        //folderPath = Application.persistentDataPath + "/" + titleText.text + ".png";
                        ImagePath = Application.persistentDataPath + "/" + info[i].Name.Substring(0, info[i].Name.Length - 5);
                    }
                    else
                    {
                        ImagePath = Application.dataPath + "/" + info[i].Name.Substring(0, info[i].Name.Length - 5);
                        print("persistent" + Application.dataPath + "/" + info[i].Name.Substring(0, info[i].Name.Length - 5));
                    }
                    File.Delete(ImagePath + ".png");
                    info [i].Delete ();
				}
			}
			i++;
		}
		op.allowSceneActivation = true;
	}
}
