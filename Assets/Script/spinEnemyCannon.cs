using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spinEnemyCannon : MonoBehaviour {
	Quaternion init;
	// Use this for initialization
	void Start () {
		init = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void initCannon(){
		transform.rotation = init;
	}

	public bool spinCannon(float angle){
		float Xangle = transform.rotation.eulerAngles.x;
		if (Xangle > 180)
			Xangle -= 360;
		float PorN = angle - Xangle > 0 ? 1 : -1;

		gameObject.transform.Rotate (new Vector3 (PorN * 1 , 0, 0));

		//print (Xangle + " -> " +  angle + " : " + (angle - Xangle));

		if (Mathf.Abs(Xangle - angle) < 0.5f)
			return true;
		else
			return false;
	}
}
