using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class buttonSystem : MonoBehaviour
{
    public Text _textField;
	private sceneInit _sceneInit;
	void Start(){
	_sceneInit= GameObject.FindWithTag("GameController").GetComponent<sceneInit>();

	}
    public void EnterSaveButton()
    {//セーブ確定ボタン
        _sceneInit.SaveInit();
        if (_textField.text.Length > 0 || !(string.IsNullOrEmpty(_textField.text)))
        {
            _sceneInit.Name = _textField.text;
        }
		if (Application.persistentDataPath != _sceneInit._appParam.designName) {
			jsonSystem.Save (_sceneInit._appParam);
		} else {

		}
    }
}
