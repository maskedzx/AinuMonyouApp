using UnityEngine;
using System.Collections;

public class buttonSystem : MonoBehaviour {

	public void SaveButton()
    {
        sceneInit obj = GameObject.FindWithTag("GameController").GetComponent<sceneInit>();
        jsonSystem.Save(obj.param);
    }

    public void LoadButton()
    {
        appParam param = jsonSystem.Load();
        print(param);
    }
}
