using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paraFollow : MonoBehaviour {

	public Vector3 offset;
	public GameObject player;
	// Use this for initialization
	void Start () {
		offset = player.transform.localPosition;
	}

	// Update is called once per frame
	void LateUpdate () {
		transform.localPosition = offset + new Vector3(0f, 1.1f, -0.2f);
	}
}
