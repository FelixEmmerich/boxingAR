﻿using UnityEngine;
using System.Collections;

/*This class is responsible for handling Globally shared variables to control GamePlay.
 * It makes controls the over all time for game play accepting events from the projectile class to adjust the time accordingly
 * It also tracks the position of the use in realtime based on the glasses and passes them onto projectileclass for getting the direction of the bullet*/

public class GameMaster : MonoBehaviour {
	public float GLOBAL_Time=0; 
	public Vector3 position_User= new Vector3(0,0,0);
	private float timeElapsed= Time.deltaTime;


	// Use this for initialization
	void Start () {
		//set of constructors
		//**problem here construct in condition when the QR code is read
	}
	
	// Update is called once per frame and updates all the variables
	void Update () {
		GLOBAL_Time = GLOBAL_Time + timeElapsed;
		OnGUI ();
	}

	/*private boolean gameOverCheck(){
		if(timeElapsed>=GLOBAL_Time){
			return true;
		}else {
			return false;
		}
	}*/

	//method to reduce the time on event that the projectile hits the player when the monster is activated
	private void onPunchTimeDeduction(){
		//if(true){
			GLOBAL_Time += 5;
		//}
	}

	//display the current time taken
	private void OnGUI(){
		GUI.TextField (new Rect(), GLOBAL_Time.ToString());
	}
}
