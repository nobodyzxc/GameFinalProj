using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class humanAct : MonoBehaviour {

	Rigidbody rbody;
	// Use this for initialization
	void Start () {
		rbody = gameObject.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		print (rbody.velocity);
	}
}
