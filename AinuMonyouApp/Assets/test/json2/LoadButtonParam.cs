using UnityEngine;
using System.Collections;

public class LoadButtonParam : MonoBehaviour {
	[SerializeField]
	private int number = 0;
	public int Number{
		get{ return number; }
		set{ number = value;}
	}
}
