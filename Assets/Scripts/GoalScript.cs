using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour {
	public Animator _animtor;
	public GameObject SWAT;
	public jump playerJump;
	public GameObject GoalCenter;
	public GameObject parachute;

	public GameObject VictoryPanel;
	public GameObject ScoreText;
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
		if (other.gameObject.tag == "Player") {
			if (playerJump.parachuteOpen) {
				playerJump.Victory = true;
				_animtor.SetTrigger ("Victory");
				VictoryPanel.SetActive (true);
				ScoreText.SetActive (false);
				Destroy (parachute);
				float dist = Vector3.Distance(SWAT.transform.position, GoalCenter.transform.position);
				GM.addScore (10000 - dist * 200);
			}

			Destroy (this.gameObject);

		}
	}
}
