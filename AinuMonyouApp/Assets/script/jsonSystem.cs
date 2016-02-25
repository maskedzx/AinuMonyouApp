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
        print("save:::" + Application.persistentDataPath + "/" + param.designName + ".json");

		FileStream file = File.Open (Application.persistentDataPath + "/" + param.designName + ".json",FileMode.Open);
		bf.Serialize(file, json);
		file.Close();
		/*if (File.Exists( Application.persistentDataPath + "/" + param.designName + ".json")) {
			FileStream file = File.Create (Application.persistentDataPath + "/" + param.designName + ".json");
			bf.Serialize(file, json);
			file.Close();
		} else {
			FileStream overFile = File.Open(Application.persistentDataPath + "/" + param.designName + ".json",FileMode.);
			bf.Serialize (overFile, json);
			overFile.Close();
		}*/
        
    }

	public static appParam Load(string name)
    {
        BinaryFormatter bf = new BinaryFormatter();
		if (!File.Exists (Application.persistentDataPath + "/" + name+".json")) 
		{
			return null;
		}
		FileStream file = File.Open (Application.persistentDataPath + "/" + name+".json", FileMode.Open);

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
