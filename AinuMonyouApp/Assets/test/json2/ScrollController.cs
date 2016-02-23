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

	void Start () {
		deleteOrEdit = true;
		/*for (int i = 0; i < 15; i++) {
			var item = GameObject.Instantiate (prefab) as RectTransform;
			item.SetParent (transform, false);

			var text = item.GetComponentInChildren<Text> ();
			text.text = "item:" + i.ToString ();
		}*/

		dir = new DirectoryInfo(Application.persistentDataPath);
		info = dir.GetFiles("*.json");
		StartCoroutine ("LoadCoroutine");
	}

	private IEnumerator LoadCoroutine(){
		foreach (FileInfo f in info)
		{
			RectTransform item = GameObject.Instantiate (prefab) as RectTransform;
			item.SetParent (transform, false);
			print(f.Name);
			Text titleText = item.GetComponentInChildren<Text> ();
			titleText.text = f.Name;
			yield return null;
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
