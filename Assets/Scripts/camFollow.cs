using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camFollow : MonoBehaviour {
	Vector3 offset;
	public GameObject player;
	public GameObject nv;
	// Use this for initialization
	void Start () {
		//offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		//transform.position = player.transform.position + offset;
		//nv.transform.position = new Vector3(nv.transform.position.x , 9.38f , nv.transform.position.z);
		transform.LookAt(player.transform);
	}
}
