using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class navFollow : MonoBehaviour {

	public GameObject player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (player.transform.position.x, 350, player.transform.position.z);
		transform.eulerAngles = new Vector3 (90, player.transform.eulerAngles.y - 90, -90);
	}
}
