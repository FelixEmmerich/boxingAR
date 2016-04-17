using UnityEngine;
using System.Collections;
using JetBrains;
using System.IO;
using System.Net;

public class Scores : MonoBehaviour {


	JSONObject j;

	// Use this for initialization
	void Start ()
	{
	    JSONObject j;

		using (StreamReader reader = new StreamReader ("scores.json")) {
			string json = reader.ReadToEnd ();
			j = new JSONObject(json);
		}
			
		string name = j.GetField ("Name");
		float time = j.GetField ("Time");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
