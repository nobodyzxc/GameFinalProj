using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tagGround : MonoBehaviour {

	// Use this for initialization

	void tagWerky(GameObject p){
		p.tag = "Ground";
		foreach(Transform t in p.transform){
			t.GetChild (0).tag = "Ground";
		}
	}

	void Start () {
		GameObject p = GameObject.Find ("werky");
		if (p)
			tagWerky (p);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
