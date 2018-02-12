using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

	public bool isRollABall;
	public bool isMaze;

	void OnMouseUp(){
		if(isRollABall)
		{
			Application.LoadLevel(0);
		}
		if (isMaze)
		{
			Application.LoadLevel(2);
		}
	} 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
