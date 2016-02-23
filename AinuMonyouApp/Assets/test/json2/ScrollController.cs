using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using System.Linq;
public class ScrollController : MonoBehaviour {

	[SerializeField]
	RectTransform prefab;
	void Start () {
		/*for (int i = 0; i < 15; i++) {
			var item = GameObject.Instantiate (prefab) as RectTransform;
			item.SetParent (transform, false);

			var text = item.GetComponentInChildren<Text> ();
			text.text = "item:" + i.ToString ();
		}*/

		DirectoryInfo dir = new DirectoryInfo(Application.persistentDataPath);
		FileInfo[] info = dir.GetFiles("*.json");
		foreach (FileInfo f in info)
		{
			RectTransform item = GameObject.Instantiate (prefab) as RectTransform;
			item.SetParent (transform, false);
			print(f.Name);
			Text titleText = item.GetComponentInChildren<Text> ();
			titleText.text = f.Name;
		}

	}
}
