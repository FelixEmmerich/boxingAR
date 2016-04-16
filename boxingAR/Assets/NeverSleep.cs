using UnityEngine;
using System.Collections;

public class NeverSleep : MonoBehaviour {

    //Place this on some script in the scene to prevent google glass from breaking everything after a while

	// Use this for initialization
	void Start ()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }
}
