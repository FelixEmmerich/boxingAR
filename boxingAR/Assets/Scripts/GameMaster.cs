using UnityEngine;
using System.Collections;
using Projectile.cs;
using Monster.cs;

/*This class is responsible for handling Globally shared variables to control GamePlay.
 * It makes controls the over all time for game play accepting events from the projectile class to adjust the time accordingly
 * It also tracks the position of the use in realtime based on the glasses and passes them onto projectileclass for getting the direction of the bullet*/

public class GameMaster : MonoBehaviour {
	public float GLOBAL_Time=0; 
	public Vector3 position_User= new Vector3(0,0,0);
	public GameObject collidedObject;
	private float timeElapsed= Time.deltaTime;
	private boolean isActive;
	public GameObject[] monsterCount = new GameObject[3]; //array to hold instance of all the monster gameobjects

	// Use this for initializatio3
	void Start () {
		//set of constructors
		//**problem here construct in condition when the QR code is read
	}
	
	// Update is called once per frame and updates all the variables
	void Update () {
		GLOBAL_Time = GLOBAL_Time + timeElapsed;
		OnGUI ();
	}

	//method to reduce the time on event that the projectile hits the player when the monster is activated
	private void onPunchTimeDeduction(){
		if(isActive){
			GLOBAL_Time += 5;
		}
	}

	//display the current time taken
	private void OnGUI(){
		GUI.TextField (new Rect(), GLOBAL_Time.ToString());
	}

	public void addToMonsterCount(boolean isActive) {
		MonsterCount[3]= Monster.FindObjectOfType
	}

	private boolean gameOverCheck(){
		if (monsterCount[3].length==0) {
			//end game
			}
	}
			
}
