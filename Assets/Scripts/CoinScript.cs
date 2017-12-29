using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour {
	GameManager GM;
	public float CoinScore = 1000f;
	AudioSource audioSource;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player") {
			GM = GameObject.Find ("GameManager").GetComponent<GameManager> ();
			audioSource = GetComponent<AudioSource> ();
			if(audioSource)
				audioSource.Play ();
			if(GM)
				GM.addScore (CoinScore);
			Destroy (this.gameObject);
		}
	}
}
