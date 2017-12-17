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
	public GameObject parachuteInst;
	public Vector3 offset;
	// Use this for initialization
	Vector3 startPosition;
	public GameObject topCam;
	public GameObject backCam;
	float gra = 3f; //4.9f;
	public ConstantForce CF;
	public GameObject SWAT;
	[HideInInspector]public bool Victory = false;
	[HideInInspector]public bool parachuteOpen = false;
	public GameObject BackGroundMusic;
	public GameObject RetryPanel;
	public AudioClip[] deathAudio;
	AudioSource audioSource;
	AudioClip deathClip;

	public GameObject bloods;

	void switchCam(){
		bool t = topCam.activeSelf;
		backCam.SetActive (t);
		topCam.SetActive (!t);
	}

	void Start () {

		//rbody = gameObject.GetComponent<Rigidbody> ();
		rbody = GetComponent<Rigidbody>();
		animtor = transform.GetChild(0).gameObject.GetComponent<Animator> ();
		audioSource = gameObject.GetComponent<AudioSource> ();
		//Physics.gravity = new Vector3 (0f, -gra, 0f);
	}

	float approach(float v , int a , int b){
		if (Mathf.Abs (v - a) > Mathf.Abs (v - b))
			return b;
		return a;
	}

	// Update is called once per frame
	void Update () {
		if(state >= 1 && state < 3)
			CF.relativeForce = new Vector3 (0f, -gra+2, 0f);
		//print (Physics.gravity);
		//print (rbody.velocity);
		if (state == 2) {
			int fix = 15;
			Vector3 nv =  transform.forward.normalized
				* (rbody.velocity.x / rbody.velocity.normalized.x)
				+ new Vector3(0 , -Mathf.Sin((rbody.rotation.eulerAngles.x * Mathf.Deg2Rad)) , 0) * Time.deltaTime * 10;
			if (!float.IsNaN (nv.x))
				rbody.velocity = nv;
			float torque = 0.5f;
			Quaternion rot = transform.rotation;
			Vector3 euler = transform.eulerAngles;

			if (Input.GetKey (KeyCode.RightArrow)) {
				float nextZ = (euler.z >= 360 - fix || euler.z <= fix)? euler.z - 1 : approach(euler.z, 360 - fix, fix) - 1;
				transform.eulerAngles = new Vector3 (euler.x, euler.y, nextZ);
				rbody.AddTorque (0, torque, 0);
			}
			if (Input.GetKey (KeyCode.LeftArrow)) {
				float nextZ = (euler.z >= 360 - fix || euler.z <= fix)? euler.z  + 1 : approach(euler.z, 360 - fix, fix) + 1;
				transform.eulerAngles = new Vector3 (euler.x, euler.y, nextZ);
				rbody.AddTorque (0, -torque, 0);
			}
			/*if (Input.GetKey (KeyCode.UpArrow)){
				transform.Rotate (new Vector3 (1, 0, 0));
			}
			if (Input.GetKey (KeyCode.DownArrow)) {
				transform.Rotate (new Vector3 (-1, 0, 0));
			}*/
			print (transform.rotation);

			if (Input.GetKey (KeyCode.LeftControl)) {
				transform.Rotate (new Vector3 (-1, 0, 0));
			} else {
				Vector3 eu = transform.eulerAngles;
				transform.eulerAngles = new Vector3 (eu.x + 1, eu.y, eu.z);

					
				/*if (transform.rotation.eulerAngles.x >= 180)
					transform.Rotate (new Vector3 (-1, 0, 0)); 
				*/
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
				animtor.SetInteger ("state", 1);
				transform.parent = transform.parent.parent;
				rbody.useGravity = true;
				rbody.velocity = (transform.position - chara_pre_Pos) / Time.deltaTime;

			} else if (state == 2) {
				switchCam ();
				animtor.SetInteger ("state", 2);

				//rbody.velocity += transform.forward * 80;


			} else if (state == 3) {
				switchCam ();

				animtor.SetInteger ("state", 3);
				paraAnim.SetInteger ("state", 1);
				rbody.drag = 0.8f; /* parachute drag */
				paraOpenTime = 1;
			} else if (state == 4) {
				rbody.drag = 0f;
				parachuteInst.transform.parent = parachuteInst.transform.parent.parent.parent.parent;
				parachuteInst.AddComponent<Rigidbody> ();
				parachuteInst.GetComponent<Rigidbody> ().velocity = -rbody.velocity;
				parachuteInst.GetComponent<Rigidbody> ().isKinematic = true;

			}
		}
		if (paraOpenTime > 0 && paraOpenTime < 600) {
			paraOpenTime += 1;
			if (paraOpenTime > 100) {
				parachuteOpen = true;
			}
			//if(rbody.velocity != Vector3.zero)
				//print (rbody.velocity);
		}
		chara_pre_Pos = transform.position;
	}


	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.tag == "Ground") {
			if(SWAT.transform.parent != null)
				SWAT.transform.parent = SWAT.transform.parent.parent;
			if (state == 3 && paraOpenTime >= 100) {
				if (!Victory) {
					animtor.SetTrigger ("Fail");
					StartCoroutine (RetryGame ());
				} else {
					BackGroundMusic.SetActive (false);
				}

				//Destroy (parachuteInst);
			}
			if (paraOpenTime < 100) {
				state = 5;
				animtor.SetInteger ("state", 5);
				playerDead ();
			} else if(!parachuteOpen){
				state = 6;
				animtor.SetInteger ("state", 6);
				playerDead ();
			}

			print (paraOpenTime);

		}
	}
	void playerDead(){
		int index = Random.Range (0, deathAudio.Length);
		deathClip = deathAudio [index];
		audioSource.clip = deathClip;
		audioSource.Play ();
		bloods.SetActive (true);
		StartCoroutine (RetryGame ());
	}
	IEnumerator RetryGame(){

		yield return new WaitForSeconds(5.0f);
		BackGroundMusic.SetActive (false);
		RetryPanel.SetActive (true);


	}
}
