using UnityEngine;
using System.Collections.Generic;

/*This class is responsible for handling Globally shared variables to control GamePlay.
 * It makes controls the over all time for game play accepting events from the projectile class to adjust the time accordingly
 * It also tracks the position of the use in realtime based on the glasses and passes them onto projectileclass for getting the direction of the bullet*/

public class GameMaster : MonoBehaviour {
	public float GLOBAL_Time=0; 
	private bool isActive=true;
	public List<Monster> Monsters; //array to hold instance of all the monster gameobjects

	// Use this for initialization
	void Start ()
    {
		//set of constructors
		//**problem here construct in condition when the QR code is read
	    var MyMonsters = FindObjectsOfType<Monster>();
	    foreach (Monster monster in MyMonsters)
	    {
	        monster.Master = this;
	        Monsters.Add(monster);
	    }
    }
	
	// Update is called once per frame and updates all the variables
	void Update ()
    {
	    if (isActive)
	    {
	        GLOBAL_Time = GLOBAL_Time + Time.deltaTime;
	    }
	}

	//method to reduce the time on event that the projectile hits the player when the monster is activated
	private void onPunchTimeDeduction(){
		if(isActive){
			GLOBAL_Time += 5;
		}
	}

	//display the current time taken
	private void OnGUI()
    {
	    if (isActive)
	    {
	        GUI.TextField(new Rect(Screen.width/4, Screen.height*0.9f, Screen.width/2, Screen.height/10), GLOBAL_Time.ToString());
	    }
	    else
	    {
	        //Todo: Highscore stuff
	    }
	}

	private void GameOverCheck()
    {
		if (Monsters.Count==0)
		{
		    isActive = false;
		}
	}

    public void RemoveMonster(Monster monster)
    {
        Monsters.Remove(monster);
        GameOverCheck();
    }
			
}
