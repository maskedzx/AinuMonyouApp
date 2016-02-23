using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class buttonSystem : MonoBehaviour
{
    public Canvas _canvas;
    public Text _textField;

    void Start()
    {
        _canvas.enabled = false;//saveのときにキャンバスを表示させるため
    }
    public void SaveButton()//セーブボタン
    {
        _canvas.enabled = true;
    }

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

    public void CancelSaveButton()//セーブキャンセルボタン
    {
        _canvas.enabled = false;
    }

    public void LoadButton()//ロードボタン
    {
        //appParam param = jsonSystem.Load();

    }
}
