using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openParachute : MonoBehaviour {
	public GameObject parachuteInst;
	public GameObject player;
	public Quaternion plyRot;
	public GameObject ptr;
	GameObject parachute = null;
	// Use this for initialization

	GameObject bar;
	void Start () {
		player.GetComponent<Rigidbody> ().drag = -1f;
		plyRot = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		print (Physics.gravity);
		if (Input.GetKeyDown (KeyCode.E)) {
			if (parachute) {
				Destroy (bar);
				parachute.GetComponent<ctrlParachute> ().drop ();
				player.GetComponent<Rigidbody> ().drag = -1f;
				parachute = null;
			} else {
				open ();
				player.GetComponent<Rigidbody> ().drag = 0.9f;
			}
		}
		if (Input.GetKeyDown (KeyCode.V)) {
			print (transform.rotation + " " + transform.position);
		}
	}

	void open(){
		parachute = Instantiate(parachuteInst , transform.position, transform.rotation, transform);
	}
}
