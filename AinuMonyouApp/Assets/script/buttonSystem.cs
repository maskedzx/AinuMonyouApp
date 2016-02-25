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
    public void SaveButton()
    {//セーブ確定ボタン
        _sceneInit.SaveInit();
        if (_textField.text.Length > 0 || !(string.IsNullOrEmpty(_textField.text)))
        {
            _sceneInit.Name = _textField.text;
        }
		print ("あぷりけーしょん"+Application.persistentDataPath+"  ::: _sceneInit"+_sceneInit._appParam.designName);
		if (Application.persistentDataPath != _sceneInit._appParam.designName) {
			jsonSystem.Save (_sceneInit._appParam);
		} else {

		}
    }
		
}
