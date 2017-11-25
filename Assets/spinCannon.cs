using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spinCannon : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float Xangle = transform.rotation.eulerAngles.x;
		if (Xangle > 180)
			Xangle -= 360;
		
		if (Input.GetKey (KeyCode.A))
			gameObject.transform.parent.transform.Rotate (new Vector3 (0, -1, 0));
		if (Input.GetKey (KeyCode.D))
			gameObject.transform.parent.transform.Rotate (new Vector3 (0, 1, 0));
		if (Input.GetKey (KeyCode.W) && Xangle < 72.5f)
			gameObject.transform.Rotate (new Vector3 (1, 0, 0));
		if (Input.GetKey (KeyCode.S) && Xangle > -6.5f)
			gameObject.transform.Rotate (new Vector3 (-1, 0, 0));

	}
}
