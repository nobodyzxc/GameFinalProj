using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JetFireControlScript : MonoBehaviour {
	public ParticleSystem Leftfire;
	public ParticleSystem Rightfire;
	public Slider fuel;
	public float fuelTank = 1000;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		fuel.value = fuelTank;
		if (Input.GetKey(KeyCode.Z)) {
			if (fuelTank <= 0) {
				fuelTank = 0;
				Leftfire.Stop ();
				Rightfire.Stop ();
			} else if(fuelTank > 0){
				fuelTank -= 10 * Time.deltaTime;
				Leftfire.Play ();
				Rightfire.Play ();
			}
		}
		if (Input.GetKeyUp(KeyCode.Z)) {
			Leftfire.Stop ();
			Rightfire.Stop ();
		}

	}
}
