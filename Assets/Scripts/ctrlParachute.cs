using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ctrlParachute : MonoBehaviour {
	public float size = 0f;
	//public GameObject player;
	public Rigidbody player;
	// Use this for initialization
	void Start () {
		transform.localScale = Vector3.zero;
		transform.localPosition += new Vector3 (0.85f, 4f, 3f); 
	}
	
	// Update is called once per frame
	void Update () {
		if (size < 1f) {
			size += 0.05f;
			float ns = size * size;
			transform.localScale = new Vector3(ns , ns , ns);
		}
	}

	public void drop(){
		transform.SetParent (transform.parent.parent.parent.parent);
	}
}
