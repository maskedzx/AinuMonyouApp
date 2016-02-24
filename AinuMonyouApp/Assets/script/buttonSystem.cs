using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class buttonSystem : MonoBehaviour
{
    public Text _textField;

    public void EnterSaveButton()
    {//セーブ確定ボタン
        sceneInit _sceneInit = GameObject.FindWithTag("GameController").GetComponent<sceneInit>();
        _sceneInit.SaveInit();
        if (_textField.text.Length > 0 || !(string.IsNullOrEmpty(_textField.text)))
        {
            _sceneInit.Name = _textField.text;
        }
        jsonSystem.Save(_sceneInit._appParam);

    }
}
