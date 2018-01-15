using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JetFireControlScript : MonoBehaviour {
	public ParticleSystem Leftfire;
	public ParticleSystem Rightfire;
	public Slider fuel;
	public float fuelTank = 100;
	bool fireFlag;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<jump> ().ringTrigger == 60) {
			fuelTank = Mathf.Max (500, fuelTank + 100);
			fireFlag = true;
		}
		if (GetComponent<jump> ().ringTrigger == 0 && fireFlag == true) {
			fireFlag = false;
			Leftfire.Stop ();
			Rightfire.Stop ();
		}
		
		if (fireFlag) {
			Leftfire.Play ();
			Rightfire.Play ();
		}

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
		if (Input.GetKeyUp(KeyCode.Z) || GetComponent<jump>().state >= 3) {
			Leftfire.Stop ();
			Rightfire.Stop ();
		}

	}
}
