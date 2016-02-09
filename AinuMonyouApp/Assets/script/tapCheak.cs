using UnityEngine;
using System.Collections;

public class tapCheak : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 tapPoint2 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D colition2d2 = Physics2D.OverlapPoint(tapPoint2);
            if (colition2d2)
            {
                GameObject obj = colition2d2.transform.gameObject;
                Debug.Log(obj.name);
            }
        }

	}
}
