using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using System.Linq;
public class ScrollController : MonoBehaviour {
	public Image deleteButton;
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

	public void LoadAinu(){
		string str = info[_loadButtonParam.Number].Name;
		appParam _appParam = jsonSystem.Load (info [item.gameObject.GetComponent<LoadButtonParam> ().Number].Name);
		print (_appParam);
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
