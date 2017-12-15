using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjFollow : MonoBehaviour {
	public GameObject plyer;
	Vector3 offset;
	// Use this for initialization
	void Start () {
		offset = transform.position - plyer.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = plyer.transform.position + offset;
	}
}
