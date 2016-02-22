using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class buttonSystem : MonoBehaviour {
	public Canvas ui;
	public Text field;

	void Start(){
		ui.enabled = false;//saveのときにキャンバスを表示させるため
	}
	public void SaveButton()//セーブボタン
    {
		ui.enabled = true;
    }

	public void EnterSaveButton(){//セーブ確定ボタン
		sceneInit obj = GameObject.FindWithTag("GameController").GetComponent<sceneInit>();
		if (field.text.Length > 0)
		{
			obj.Name = field.text;
		}
		jsonSystem.Save(obj.param);
	}

	public void CancelSaveButton(){//セーブキャンセルボタン
		ui.enabled = false;
	}

    public void LoadButton()//ロードボタン
    {
        appParam param = jsonSystem.Load();
        print(param);
    }
}
