using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ctrlParachute : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.localScale = Vector3.zero;
		transform.localPosition += new Vector3 (0.85f, 4f, 3f); 
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.localScale.x < 1f) {
			transform.localScale += new Vector3(0.1f , 0.1f , 0.1f);
		}
	}

	public void drop(){
		transform.SetParent (transform.parent.parent.parent.parent);
	}
}
