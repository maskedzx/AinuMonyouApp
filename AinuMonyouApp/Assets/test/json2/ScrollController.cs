using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;
using System;

public class ScrollController : MonoBehaviour {
	public Image deleteButton;
	public GameObject dontDestroyObject;
	private bool deleteOrEdit;
	[SerializeField]
	RectTransform prefab;
	private DirectoryInfo dir;
	private FileInfo[] info;
	private RectTransform item;
	private LoadButtonParam _loadButtonParam;

	void Start () {
		deleteOrEdit = true;
		dir = new DirectoryInfo(Application.persistentDataPath);
		info = dir.GetFiles("*.json");
		StartCoroutine ("LoadCoroutine");
	}

	private IEnumerator LoadCoroutine(){
		int i = 0;
		foreach (FileInfo f in info)
		{
			item = GameObject.Instantiate (prefab) as RectTransform;
			item.SetParent (transform, false);
			print(f.Name);
			Text titleText = item.GetComponentInChildren<Text> ();
			titleText.text = f.Name;

			item.gameObject.GetComponent<LoadButtonParam> ().Number=i++;
			_loadButtonParam = item.gameObject.GetComponent<LoadButtonParam> ();
			yield return null;
		}
	}

	public void LoadAinu(int i){
		string str = info[i].Name;
		Instantiate (dontDestroyObject);
		appParam _appParam = jsonSystem.Load (info [i].Name);
		print ("アプリ情報:::名前:"+_appParam.designName + " パーツRGB:" + _appParam.PartsRGB + "背景RGB:" + _appParam.BackGroundRGB);
		PatternRetention pr = dontDestroyObject.GetComponent<PatternRetention> ();


		pr.designName = _appParam.designName;
		pr.BackGroundRGB = _appParam.BackGroundRGB;
		pr.PartsRGB = _appParam.PartsRGB;
		print ("pr.designName:" + pr.designName + " pr.BackGroundRGB:" + pr.BackGroundRGB + "pr.PartsRGB:" + pr.PartsRGB);
		pr._objectParam = new objectParam[_appParam.link.Length];
		try{
			for (int j = 0; j < _appParam.link.Length; j++) {
				pr._objectParam[j] = _appParam.link [j];
				print ("パーツ情報:::パーツ番号:"+pr._objectParam[j].PartsNumber + " position:" + pr._objectParam[j].Position + " scale:" + pr._objectParam[j].Scale + " rotate:" + pr._objectParam[j].Rotate);				
			}
		}catch(Exception e){
			print("オブジェクトがひとつもなかったよ");
			print (e.Message);
		}finally{
			SceneManager.LoadScene ("make");
		}
	}

	public void DeleteEnterButton(){
		if (deleteOrEdit) {
			deleteButton.color = new Color (0, 96, 96);

		} else {
			deleteButton.color = new Color (255f/255f, 96f/255f, 96f/255f);
		}
		deleteOrEdit = !deleteOrEdit;
	}
}
