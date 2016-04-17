using UnityEngine;
using System.Collections;
using JetBrains;
using System.IO;
using System.Net;

public class Scores : MonoBehaviour {


	JSONObject j;

	// Use this for initialization
	void Start () {
		
		using (StreamReader reader = new StreamReader ("scores.json")) {
			String json = reader.ReadToEnd ();
			JSONObject j = new JSONObject(json);
		}
			
		String name = j.GetField ("Name");
		float time = j.GetField ("Time");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
