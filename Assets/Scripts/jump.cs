using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour {
	Animator animtor;
	public Animator paraAnim;
	Rigidbody rbody;
	public int state = 0;
	int paraOpenTime = 0;
	float charaSpeed;
	Vector3 chara_pre_Pos;
	public GameObject parachute;
	public GameObject parachuteInst;
	public Vector3 offset;
	// Use this for initialization
	Vector3 startPosition;
	public GameObject test;
	public GameObject topCam;
	public GameObject backCam;
	float gra = 3f; //4.9f;
	public ConstantForce CF;
	void switchCam(){
		bool t = topCam.activeSelf;
		backCam.SetActive (t);
		topCam.SetActive (!t);
	}
		
	void Start () {
		
		//rbody = gameObject.GetComponent<Rigidbody> ();
		rbody = GetComponent<Rigidbody>();
		animtor = transform.GetChild(0).gameObject.GetComponent<Animator> ();
		//Physics.gravity = new Vector3 (0f, -gra, 0f);
	}

	// Update is called once per frame
	void Update () {
		if(state >= 1 && state < 3)
			CF.relativeForce = new Vector3 (0f, -gra+2, 0f);
		//print (Physics.gravity);
		//print (rbody.velocity);
		if (state == 2) {
			rbody.velocity = transform.forward.normalized * (rbody.velocity.x / rbody.velocity.normalized.x);
			print (transform.rotation);
			float torque = 0.5f;
			if (Input.GetKey (KeyCode.RightArrow)) {
				//transform.RotateAround (test.transform.position, Vector3.forward, 20 * Time.deltaTime);
				transform.Rotate (new Vector3 (0, 0, -1));
				rbody.AddTorque (0, torque, 0);
				print (transform.rotation);
			}
			if (Input.GetKey (KeyCode.LeftArrow)) {
				transform.Rotate (new Vector3 (0, 0, 1));
				rbody.AddTorque (0, -torque, 0);
			}
			if (Input.GetKey (KeyCode.UpArrow)) {
				transform.Rotate (new Vector3 (1, 0, 0));
			}
			if (Input.GetKey (KeyCode.DownArrow)) {
				transform.Rotate (new Vector3 (-1, 0, 0));
			}
		}
		if (state == 3) {
			CF.enabled = false;
			if (Input.GetKey (KeyCode.RightArrow)) {
				transform.Rotate (new Vector3 (0, 0, -1));
			}
			if (Input.GetKey (KeyCode.LeftArrow)) {
				transform.Rotate (new Vector3 (0, 0, 1));
			}
			if (Input.GetKey (KeyCode.UpArrow)) {
				transform.Rotate (new Vector3 (1, 0, 0));
			}
			if (Input.GetKey (KeyCode.DownArrow)) {
				transform.Rotate (new Vector3 (-1, 0, 0));
			}
		}


		if (Input.GetKeyDown (KeyCode.Space)) {
			state += 1;
			if (state == 1) {
				rbody.useGravity = true;
				//playerbeforejumping.GetComponent<Rigidbody> ().velocity = new Vector3 (-speed * Mathf.Sin (rot), 0, -speed * Mathf.Cos (rot));
				animtor.SetInteger ("state", 1);
				transform.parent = transform.parent.parent;
				//transform.parent.parent = transform.parent.parent.parent;
				rbody.useGravity = true;

				rbody.velocity = (transform.position - chara_pre_Pos) / Time.deltaTime;
				//Vector3 v3Force = 100f * transform.forward;
				//rbody.AddForce (v3Force);
			} 
			else if (state == 2) {
				switchCam ();
				animtor.SetInteger ("state", 2);
				//rbody.drag = 0.1f;
				//rbody.AddForce (100 * transform.forward);
				rbody.velocity += transform.forward * 80;
			}
			else if (state == 3) {
				switchCam ();
				animtor.SetInteger ("state", 3);
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
		chara_pre_Pos = transform.position;
	}


	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.tag == "Ground") {
			state += 1;
			if (paraOpenTime < 50)
				animtor.SetInteger ("state", 5);
			else
				animtor.SetInteger ("state", 6);
			print (paraOpenTime);

		}
	}
}
