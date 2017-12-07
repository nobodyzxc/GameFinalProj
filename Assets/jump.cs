using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour {
	Animator animtor;
	public Animator paraAnim;
	Rigidbody rbody;
	int state = 0;
	int paraOpenTime = 0;
	// Use this for initialization
	Vector3 startPosition;
	void Start () {
		rbody = gameObject.GetComponent<Rigidbody> ();
		animtor = gameObject.GetComponent<Animator> ();	
		Physics.gravity = new Vector3 (0f, -4.9f, 0f);
	}

	// Update is called once per frame
	void Update () {

		//print (Physics.gravity);
		//print (rbody.velocity);
		if (Input.GetKeyDown (KeyCode.Space)) {
			state += 1;
			if (state == 1) {
				animtor.SetInteger ("state", 1);
				transform.parent = transform.parent.parent;
				rbody.useGravity = true;
				//Vector3 v3Force = 100f * transform.forward;
				//rbody.AddForce (v3Force);
			} else if (state == 2) {
				animtor.SetInteger ("state", 2);
				paraAnim.SetInteger ("state", 1);
				rbody.drag = 0.5f;
				paraOpenTime = 1;
			}
		}
		if (paraOpenTime > 0 && paraOpenTime < 600) {
			paraOpenTime += 1;
			if(rbody.velocity != Vector3.zero)
				print (rbody.velocity);
		}
	}


	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.tag == "Ground") {
			if (paraOpenTime < 50)
				animtor.SetInteger ("state", 5);
			else
				animtor.SetInteger ("state", 6);
			print (paraOpenTime);

		}
	}
}
