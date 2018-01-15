using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tagGround : MonoBehaviour {

	// Use this for initialization

	void tagWerky(GameObject p){
		p.tag = "Ground";
		foreach(Transform t in p.transform){
			t.GetChild (0).tag = "Ground";
			t.GetChild (2).tag = "Ground";
			t.GetChild (3).tag = "Ground";
		}
	}

	void tagTroska(GameObject p){
		foreach(Transform t in p.transform){
			t.gameObject.tag = "Ground";
		}
	}

	void Start () {
		GameObject p = GameObject.Find ("werky");
		if (p)
			tagWerky (p);
		p = GameObject.Find ("Troska_A");
		if (p)
			tagTroska (p);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
