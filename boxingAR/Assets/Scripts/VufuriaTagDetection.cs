using UnityEngine;
using System.Collections;
using Vuforia;
using System.Collections.Generic;

/* class using IEnumerable to scan for each active marker then return a boolean variable*/

public class VufuriaTagDetection : MonoBehaviour {
    public bool isActive = false;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        StateManager sManager = TrackerManager.Instance.GetStateManager();
        IEnumerable<TrackableBehaviour> activeTrackables = sManager.GetActiveTrackableBehaviours();
        foreach (TrackableBehaviour trackable in activeTrackables)
        {
            if(trackable is MarkerBehaviour) { 
            isActive = true;
            }
        }
        isActive = false;
    }

}
