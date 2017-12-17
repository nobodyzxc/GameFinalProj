using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour {
	public Animator _animtor;
	public GameObject player;
	public jump playerJump;
	public GameObject GoalCenter;
	public GameObject parachute;
	GameManager GM;
	jump jp;
	// Use this for initialization
	void Start () {
		GM = GameObject.Find ("GameManager").GetComponent<GameManager> ();
	}

	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player" && playerJump.parachuteOpen) {
			playerJump.Victory = true;
			_animtor.SetTrigger ("Victory");
			Destroy (parachute);
			float dist = Vector3.Distance(player.transform.position, GoalCenter.transform.position);
			GM.addScore (10000 - dist * 500);
		}
	}
}
