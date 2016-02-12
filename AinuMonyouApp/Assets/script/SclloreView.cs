using UnityEngine;
using System.Collections;

public class SclloreView : MonoBehaviour {
    private bool isClicked = false;
    private Vector2 currentPoint;
    [SerializeField]
    private bool operation = false;
    [SerializeField]
    private GameObject menu;
    private float tmp_x;
    private float maxps = 220.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0) && operation == true)
        {
            OnMouseDown();
        }
        if (Input.GetMouseButton(0) && operation == true)
        {
            OnMouseDrag();
        }
        if (Input.GetMouseButtonUp(0) && operation == true)
        {
            OnMouseUp();
        }
	}

    void OnMouseDown()
    {
        Debug.Log("OnMouseDown");
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(menu.transform.position);
        Vector3 newVecter = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

        Vector2 tapPoint = new Vector2(newVecter.x, newVecter.y);
        Collider2D colition2d = Physics2D.OverlapPoint(tapPoint);

        if (colition2d)
        {
            RaycastHit2D hitObject = Physics2D.Raycast(tapPoint, -Vector2.up);
            if (hitObject)
            {
                currentPoint = new Vector2(tapPoint.x, tapPoint.y);
                isClicked = true;
            }
        }
    }

    void OnMouseDrag()
    {
        Debug.Log("OnMouseDrag");
        if (!isClicked){
            return;
        }

        Vector3 screenPoint = Camera.main.ScreenToWorldPoint(menu.transform.position);
        Vector3 newVecter = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

        Vector2 tapPoint = new Vector2(newVecter.x, newVecter.y);
        tmp_x = menu.transform.position.x;
        //if (tmp_x < maxps){
            menu.transform.position = new Vector2(menu.transform.position.x + 20 * (tapPoint.x - currentPoint.x), menu.transform.position.y);
        //}
        //else if (tmp_x >= maxps){
        //    menu.transform.position = new Vector2(maxps-1, menu.transform.position.y);
        //}
        currentPoint = tapPoint;
    }

    void OnMouseUp(){
        Debug.Log("OnMouseUp");
        isClicked = false;
    }
}
