using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelInfo : MonoBehaviour {

	//ボタンのテキスト
	private Text levelText;

	//レベル番号プロパティ
	private int _levelNo;
	public int levelNo{
		set{//レベル番号設定時に、ボタンのテキストも更新 
			this._levelNo = value;
			levelText.text = value+"";
		}
		get{ return this._levelNo;}
	}
	void Awake () {
		levelText = transform.FindChild ("Text").GetComponent<Text>();
	}
}
