using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlane : MonoBehaviour {
	public GameObject goal;
	public GameObject player;
	public Rigidbody prbody;
	Vector3 startPos;
	Vector3 offsetEndPos;
	Rigidbody rbody;
	float force = 50000f;
	float playerOffset;
	// Use this for initialization
	void Start () {
		startPos = transform.position;
		rbody = gameObject.GetComponent<Rigidbody> ();
		//rbody.AddForce(new Vector3(force , 0 , force));
		//prbody.AddForce(new Vector3(force , 0 , force));
		playerOffset = dist (player, gameObject);
	}

	int sign(float s){
		return s > 0 ? 1 : -1;
	}
	// Update is called once per frame
	float dist(GameObject a , GameObject b){
		return (a.transform.position.y - b.transform.position.y);
	}




	void Update () {
		/*
		float dir = sign (nx - transform.position.x);
		if(dir != sign(rbody.velocity.x)){
			rbody.velocity = Vector3.zero;
			rbody.AddForce(new Vector3(force * dir , 0 , force * dir));
			if (dist(player, gameObject) == playerOffset) {
				prbody.velocity = Vector3.zero;
				prbody.AddForce(new Vector3(force * dir , 0 , force * dir));
			}
		}
		*/
	}
}