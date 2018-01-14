﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class CoinScript : MonoBehaviour {
	GameManager GM;
	public float CoinScore = 1000f;
	NavMeshAgent nav;
	AudioSource audioSource;
	Transform player;
	Vector3 lookPos;
	Quaternion lastPos;
	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
		GM = GameObject.Find ("GameManager").GetComponent<GameManager> ();
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}

	// Update is called once per frame
	void Update () {
		//if (gameObject.tag == "Ring") {
		//	//transform.LookAt (player);
		//	lookPos = player.position - transform.position;
		//	lookPos.y = 0;
		//	lastPos = Quaternion.LookRotation(lookPos);
		//	transform.rotation = Quaternion.Slerp(transform.rotation,lastPos, Time.deltaTime * 100);
		//}
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
