using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetFireControlScript : MonoBehaviour {
	public ParticleSystem Leftfire;
	public ParticleSystem Rightfire;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Z)) {
			Leftfire.Play ();
			Rightfire.Play ();
		}
		if (Input.GetKeyUp(KeyCode.Z)) {
			Leftfire.Stop ();
			Rightfire.Stop ();
		}

	}
}
