using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ctrlCamera : MonoBehaviour {
	public GameObject player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float Xangle = transform.rotation.eulerAngles.x;
		if (Xangle > 180)
			Xangle -= 360;
		if (Input.GetKey (KeyCode.R))
			gameObject.transform.Rotate (new Vector3 (-1, 0, 0));
		if (Input.GetKey (KeyCode.F))
			gameObject.transform.Rotate (new Vector3 (1, 0, 0));
		if (Input.GetKey (KeyCode.Z))
			gameObject.transform.Rotate (new Vector3 (0, -1, 0) , Space.World);
		if (Input.GetKey (KeyCode.C))
			gameObject.transform.Rotate (new Vector3 (0, 1, 0) , Space.World);
		
		if (Input.GetKey (KeyCode.X)) {
			player = GameObject.Find ("Tank");
			if (player == null)
				player = GameObject.Find ("Tank(Clone)");
			if (player == null)
				return;
			gameObject.transform.LookAt (player.transform);
			transform.Rotate (new Vector3 (-22.235f, 0f, 0f));
		}

	}
}
