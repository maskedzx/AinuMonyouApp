using UnityEngine;
using System.Collections;

public class LoadButtonParam : MonoBehaviour {
	[SerializeField]
	private int number = 0;
    private ScrollController scroll;

    void Start()
    {
        scroll = FindObjectOfType<ScrollController>();
    }
	public int Number{
		get{ return number; }
		set{ number = value;}
	}

    public void LoadButton()
    {
        scroll.LoadAinu(number);
    }
}
