using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public class jsonSystem : MonoBehaviour
{

    public static void Save(appParam param)
    {
        string json = JsonUtility.ToJson(param);

        BinaryFormatter bf = new BinaryFormatter();
        //print("save:::" + Application.persistentDataPath + "/JsonSerializerTest.json");
        print("save:::" + Application.persistentDataPath + "/" + param.designName + ".json");
        //FileStream file = File.Create(Application.persistentDataPath + "/JsonSerializerTest.json");
        FileStream file = File.Create(Application.persistentDataPath + "/" + param.designName + ".json");
        bf.Serialize(file, json);
        file.Close();
    }

	public static appParam Load(string name)
    {
        BinaryFormatter bf = new BinaryFormatter();
        //if (!File.Exists(Application.persistentDataPath + "/JsonSerializerTest.json"))
		if (!File.Exists (Application.persistentDataPath + "/" + name + ".json")) 
		{
			return null;
		}
		FileStream file = File.Open (Application.persistentDataPath + "/" + name + ".json", FileMode.Open);

        if (file.Length == 0)
        {
            return null;
        }

        string json = (string)bf.Deserialize(file);
        file.Close();

        if (json.Length > 0)
        {
            return JsonUtility.FromJson<appParam>(json);
        }
        return null;
    }
}
