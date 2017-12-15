using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour {
	GameManager GM;
	// Use this for initialization
	void Start () {
		GM = GameObject.Find ("GameManager").GetComponent<GameManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player") {
			GM.addScore (1000);
			Destroy (this.gameObject);
		}
	}
}
