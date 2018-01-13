using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateCloudScript : MonoBehaviour {

	public GameObject cloud;
	public float spawnMin = 1f;
	public float spawnMax = 2f;
	public jump Player;
	// Use this for initialization
	void Start () {
		Spawn ();
	}

	void Spawn(){
		if (Player.state == 2) {
			Destroy(Instantiate (cloud, transform.position, Quaternion.identity),3);

		}
		Invoke ("Spawn", Random.Range (spawnMin, spawnMax));

	}
}
