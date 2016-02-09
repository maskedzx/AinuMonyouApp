using UnityEngine;
using System.Collections;

public class PartsMove : MonoBehaviour {
    const float ROATTION_SPEED = 5.0f;
    const float ZOOM_SPEED = 200.0f;
    const float ROTA_SPEED = 10.0f;

    private Vector3 position;
    private float scale_x = 0.0f;
    private float scale_y = 0.0f;
    private float position_x = 0.0f;
    private float position_y = 0.0f;
    private float rotation_z = 0.0f;
    private float tmp_rotation = 0.0f; 

    private bool isDragging = false;
    private bool isDragged = false;
    private bool isPinched = false;
    private float interval = 0.0f;

    private bool isClicked = false;
    private Vector2 currentPoint;

    [SerializeField]
    private bool operation = false;

    [SerializeField]
    private GameObject partsSpawner;
    private PartsSpawner ps;

    private bool moveMode;

    void Awake(){
        partsSpawner = GameObject.Find("PartsSpawner");
        ps = partsSpawner.GetComponent<PartsSpawner>();
    }


    // Use this for initialization
    void Start()
    {
        Vector3 scale = transform.localScale;
        Quaternion rotation = transform.localRotation;
        scale_x = scale.x;
        scale_y = scale.y;
        position = transform.position;
        position_x = position.x;
        position_y = position.y;
        rotation_z = rotation.z;

    }

    void TapParts(){
        if (Input.touchCount == 1 && isPinched && operation == true )
        {
            if (Event.current.type == EventType.MouseDrag){
                isDragging = true;
                isDragged = true;
            } else {
                isDragging = false;
                if (Event.current.type == EventType.MouseUp){
                    if (!isDragged) Tap(Input.mousePosition);
                    else isDragged = false;
                }
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
        moveMode = ps.MoveMode;
        if (Input.touchCount == 2 && operation == true && moveMode == true) {
            if (Input.touches[0].phase == TouchPhase.Began || Input.touches[1].phase == TouchPhase.Began){
                interval = Vector2.Distance(Input.touches[0].position, Input.touches[1].position);
            }
            float tmpInterval = Vector2.Distance(Input.touches[0].position, Input.touches[1].position);
            scale_x -= (tmpInterval - interval) / ZOOM_SPEED;
            scale_y -= (tmpInterval - interval) / ZOOM_SPEED;
            if (scale_x > 0 || scale_y > 0){
                scale_x = 0;
                scale_y = 0;
            }
            interval = tmpInterval;
            this.transform.localScale = new Vector3(-1*(scale_x), -1*(scale_y), 1);
            isPinched = true;

        } else if (Input.touchCount == 2 && operation == true && moveMode == false){
            
            if (Input.touches[0].phase == TouchPhase.Began || Input.touches[1].phase == TouchPhase.Began){
                interval = Vector2.Distance(Input.touches[0].position, Input.touches[1].position);
            }
            float tmpInterval = Vector2.Distance(Input.touches[0].position, Input.touches[1].position);
            tmp_rotation = tmpInterval - interval;
            //if (tmp_rotation < 0){
                rotation_z -= (tmpInterval - interval) / ROTA_SPEED;
            //} else {
            //  rotation_z += (tmpInterval - interval) / ROTA_SPEED;                
            //}
            if (rotation_z > 0 || tmp_rotation == 0){
                rotation_z = 0;
            }
            
                interval = tmpInterval;
                this.transform.Rotate(0, 0, rotation_z);
            
            isPinched = true;
        } else if (isDragging ){
           
        }

        if (Input.GetMouseButtonDown(0) && operation == true){
            OnMouseDown();
        }
        if (Input.GetMouseButton(0) && operation == true){
            OnMouseDrag();
        }
        if (Input.GetMouseButtonUp(0) && operation == true){
            OnMouseUp();
        }
	}

    void OnMouseDown(){
        Debug.Log("OnMouseDown");
        operation = true;
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        Vector3 newVecter = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,screenPoint.z));

        Vector2 tapPoint = new Vector2(newVecter.x,newVecter.y);
        Collider2D colition2d = Physics2D.OverlapPoint(tapPoint);
        if(colition2d){
            RaycastHit2D hitObject = Physics2D.Raycast(tapPoint,-Vector2.up);
            if(hitObject){
                currentPoint = new Vector2(tapPoint.x,tapPoint.y);
                isClicked = true;
            }
        }
    }

    void OnMouseDrag(){
        Debug.Log("OnMouseDrag");
        if (!isClicked){
            return;
        }

        Vector3 screenPoint = Camera.main.ScreenToWorldPoint(this.transform.position);
        Vector3 newVecter = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

        Vector2 tapPoint = new Vector2(newVecter.x, newVecter.y);
        this.transform.position = new Vector2(this.transform.position.x + (tapPoint.x - currentPoint.x), this.transform.position.y + (tapPoint.y - currentPoint.y));
        currentPoint = tapPoint;
    }

    void OnMouseUp(){
        Debug.Log("OnMouseUp");
        isClicked = false;
        operation = false;
    }

    private void Tap(Vector3 point){
        Debug.Log("Tap");
    } 
}
