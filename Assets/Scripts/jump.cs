using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;



public class jump : MonoBehaviour {
	Animator animtor;
	public Animator paraAnim;
	Rigidbody rbody;
	public int state = 0;
	float paraOpenTime = 0;
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
	public GameObject coin;
	public GameObject ring;
	float escapeTime = 0f;
	public GameObject bloods;
	const float deadTime = 3f;
	public JetFireControlScript JFCS;

	void switchCam(){
		return;
		bool t = topCam.activeSelf;
		backCam.SetActive (t);
		topCam.SetActive (!t);
	}

	float approach(float v , int a , int b){
		if (Mathf.Abs (v - a) > Mathf.Abs (v - b))
			return b;
		return a;
	}

	StreamWriter writer;
	bool fileOpen = false;
	int gap = 0;
	bool SETROUTE = false;
	bool SHOWBALL = false;
	void Start () {
		
		//rbody = gameObject.GetComponent<Rigidbody> ();
		rbody = GetComponent<Rigidbody>();
		animtor = transform.GetChild(0).gameObject.GetComponent<Animator> ();
		audioSource = gameObject.GetComponent<AudioSource> ();


		//Physics.gravity = new Vector3 (0f, -gra, 0f);
		string path = "Assets/routes/route3.txt";
		//Write some text to the test.txt file

		if (SETROUTE) {
			writer = new StreamWriter (path, true);
			fileOpen = true;
		} else if(SHOWBALL){
			int counter = 0;
			StreamReader reader = new StreamReader (path);
			while (true) {
				var str = reader.ReadLine ();
				if (str == null)
					break;
				var parts = str.Split (' ');
				Vector3 pos = new Vector3 (float.Parse(parts[0]), float.Parse(parts[1]), float.Parse(parts[2]));
				Quaternion rot = Quaternion.Euler(float.Parse(parts[3]), float.Parse(parts[4]), float.Parse(parts[5]));
				if(counter == 10)
					Instantiate (ring, pos , rot);
				else
					Instantiate (coin, pos , rot);
				counter++;
				counter %= 90;
			}
		}
	}


	// Update is called once per frame
	void Update () {

		if (state == 2 && SETROUTE) {
			if (gap == 0) {
				gap = 3;
				writer.WriteLine (transform.position.x + " " + transform.position.y + " " + transform.position.z
					+ " " + transform.rotation.x + " " + transform.rotation.y + " " + transform.rotation.z);
				print ("write file");
			}
			gap--;
		}
		if (state == 5 && fileOpen && SETROUTE) {
			fileOpen = false;
			writer.Close();
			print ("close file");
		}


		if(state >= 1 && state < 3)
			CF.relativeForce = new Vector3 (0f, -gra+2, 0f);
		//print (Physics.gravity);
		//print (rbody.velocity);
		int fix = 15;
		Vector3 euler = transform.eulerAngles;

		if (state == 2){
			Vector3 nv =  transform.forward.normalized
				* (rbody.velocity.x / rbody.velocity.normalized.x)
				+ new Vector3(0 , -Mathf.Sin((rbody.rotation.eulerAngles.x * Mathf.Deg2Rad)) , 0) * Time.deltaTime * 10;
			if (!float.IsNaN (nv.x))
				rbody.velocity = nv;
			float torque = 0.25f;
			Quaternion rot = transform.rotation;
		
			if (Input.GetKey (KeyCode.RightArrow)) {
				float nextZ = (euler.z >= 360 - fix || euler.z <= 180)? euler.z - 0.5f : euler.z;
				transform.eulerAngles = new Vector3 (euler.x, euler.y, nextZ);
				rbody.AddTorque (0, torque, 0);
			}
			if (Input.GetKey (KeyCode.LeftArrow)) {
				float nextZ = (euler.z >= 180 || euler.z <= fix)? euler.z  + 0.5f : euler.z;
				transform.eulerAngles = new Vector3 (euler.x, euler.y, nextZ);
				rbody.AddTorque (0, -torque, 0);
			}
			if(Input.GetKey(KeyCode.Alpha1))
				writer.Close();
			/*if (Input.GetKey (KeyCode.UpArrow)){
				transform.Rotate (new Vector3 (1, 0, 0));
			}
			if (Input.GetKey (KeyCode.DownArrow)) {
				transform.Rotate (new Vector3 (-1, 0, 0));
			}*/

			if (Input.GetKey (KeyCode.Z) ) {
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
			float nextX;
			float speed = 10 * Time.deltaTime;
			if (Input.GetKey (KeyCode.RightArrow)) {
				transform.position += new Vector3 (-speed, 0, 0);
			}
			if (Input.GetKey (KeyCode.LeftArrow)) {
				transform.position += new Vector3 (speed, 0, 0);
			}

			if (Input.GetKey (KeyCode.UpArrow)) {
				nextX = (euler.x >= 360 - fix || euler.x <= fix)? euler.x - 1 : approach(euler.x, 360 - fix, fix) - 1;
				transform.eulerAngles = new Vector3 (nextX, euler.y, euler.z);
			}
			if (Input.GetKey (KeyCode.DownArrow)) {
				nextX = (euler.x >= 360 - fix || euler.x <= fix)? euler.x  + 1 : approach(euler.x, 360 - fix, fix) + 1;
				transform.eulerAngles = new Vector3 (nextX, euler.y, euler.z);
			}
			// spin , let feet toward land
			/*
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
			*/
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
				animtor.SetTrigger ("dropParachute");
				escapeTime += Time.deltaTime;
				parachuteInst.transform.parent = parachuteInst.transform.parent.parent.parent.parent;
				parachuteInst.AddComponent<Rigidbody> ();
				parachuteInst.GetComponent<Rigidbody> ().velocity = -rbody.velocity;
				parachuteInst.GetComponent<Rigidbody> ().isKinematic = true;


			}
		}
		if (paraOpenTime > 0 && paraOpenTime < 600 && state == 3) {
			paraOpenTime += Time.deltaTime ;
			print (paraOpenTime);
			if (paraOpenTime > deadTime) {
				parachuteOpen = true;
			}
			//if(rbody.velocity != Vector3.zero)
				//print (rbody.velocity);
		}
		chara_pre_Pos = transform.position;
	}


	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.tag == "Ground") {
			//rbody.velocity = Vector3.zero;
			rbody.freezeRotation = true;
			if (SWAT.transform.parent != null) {
				transform.GetChild (1).parent = transform.GetChild (0);
				SWAT.transform.parent = SWAT.transform.parent.parent;

				state = 8 + 9;
			}
			if (state != 2 && paraOpenTime >= deadTime) {
				if (!Victory) {
					animtor.SetTrigger ("Fail");
					StartCoroutine (RetryGame ());
				} else {
					BackGroundMusic.SetActive (false);
				}

				//Destroy (parachuteInst);
			}

			if (paraOpenTime < deadTime) { /* mod here */
				print (paraOpenTime+" not enough");
				state = 5;
				animtor.SetInteger ("state", 5);
				playerDead ();
			} else if(!parachuteOpen || escapeTime > deadTime){
				print (paraOpenTime+" not open");
				state = 6;
				animtor.SetInteger ("state", 6);
				playerDead ();
			}


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
