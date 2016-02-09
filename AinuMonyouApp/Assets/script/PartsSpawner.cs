using UnityEngine;
using System.Collections;

public class PartsSpawner : MonoBehaviour {

    [SerializeField]
    private GameObject[] parts;
    [SerializeField]
    private bool moveMode = true;
    public bool MoveMode{
        set { this.moveMode = value; }
        get {return this.moveMode;}
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void partsSpawn(int num){
        Instantiate(parts[num], transform.localPosition, transform.localRotation);
    }
}
