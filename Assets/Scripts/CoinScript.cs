using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class CoinScript : MonoBehaviour {
	GameManager GM;
	public float CoinScore = 1000f;
	NavMeshAgent nav;
	AudioSource audioSource;
	Transform player;
	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
		GM = GameObject.Find ("GameManager").GetComponent<GameManager> ();
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		if(gameObject.tag == "Ring")
			transform.LookAt (player);
	}
	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player") {
			if(audioSource)
				audioSource.Play ();

			if(GM)
				GM.addScore (CoinScore);
			Destroy (this.gameObject);

		}
	}
}
