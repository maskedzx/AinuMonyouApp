using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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
        SceneInit sceneInit = GameObject.FindWithTag("GameController").GetComponent<SceneInit>();
        sceneInit.SaveInit();
        if (_textField.text.Length > 0 || !(string.IsNullOrEmpty(_textField.text)))
        {
            sceneInit.Name = _textField.text;
        }
        jsonSystem.Save(sceneInit._appParam);
    }

    public void CancelSaveButton()//セーブキャンセルボタン
    {
        _canvas.enabled = false;
    }

    public void LoadButton()//ロードボタン
    {
        appParam param = jsonSystem.Load();
        print(param);
    }
}
