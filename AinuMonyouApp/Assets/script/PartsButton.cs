using UnityEngine;
using System.Collections;

public class PartsButton : MonoBehaviour {
    [SerializeField]
    private int buttonNo = 0;
    [SerializeField]
    private GameObject partsSpawner;
    private PartsSpawner ps;

    void Awake(){
        ps = partsSpawner.GetComponent<PartsSpawner>();
    }

    public void partsSet()
    {
        ps.partsSpawn(buttonNo);
    }
}
