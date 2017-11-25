using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class moveEnemy : MonoBehaviour {

	public GameObject player;
	public GameObject smoke;

	int cd;
	float spinRate = 3.0f;
	float speed = 2.5f;
	int initCD;
	int isTricky;
	int hyperactive;
	int lastExec = 0;
	float dist;
	float detDist;

	int life = 1;
	int totlife;


	float offsetDir = 0;
	int offsetCount = 0;
	const int offsetCD = 100;

	int sleep = 0;
	int walk = 0;

	int brave;
	void Start () {
		detDist = Random.Range (25f, 32f);
		totlife = Random.Range (15, 26);
		life = totlife;
		speed = Random.Range (2.0f, 4.5f);
		initCD = Random.Range (1, 7) * 50;
		cd = initCD;
		brave = Random.Range (0, 6) * 2;
		isTricky = Random.Range (0, 4);
		hyperactive = 1;//Random.Range (0, 2);
		print("Speed = " + speed + " Life = " + life);
		print ("CD = " + initCD + " Brave : " + brave);
		print ("Tricky = " + isTricky + " hyperActive = " + hyperactive);
		print ("detdist = " + detDist);

		player = GameObject.Find ("PlayerZone");
	}

	void Update ()
	{
		player = GameObject.Find ("PlayerZone");
		
		dist = Vector3.Distance (player.transform.position, transform.position);
		if (player.transform.childCount == 2) {
			randomWalk ();
			return;
		}
		if (dist > 300f) {
			print ("out of border");
			GameObject.Find ("PlayerZone").GetComponent<moveTank> ().curEnemy -= 1;
			Destroy (this.gameObject);
		}

		//print (detDist + " : " + dist);
		if (dist < 14 - brave) {
			escape ();
			lastExec = 0;
		} else if (dist < detDist && dist > 20 - brave / 2) {
			trace ();
			lastExec = 1;
		} else if (dist < detDist && hyperactive > 0) {
			if (lastExec == 0)
				escape ();
			else
				trace ();
		} else {
			randomWalk ();
		}
		if (dist < 19) {
			cannonToward ();
			if (cd == 0) {
				attack (dist);
			} else {
				cd -= 1;
				//if(cd % 100 == 0)
				//	Debug.Log(cd / 100);
			}
		}

	}

	void randomWalk(){
		
		if (walk > 0) {
			walk -= 1;
			trickySpin ();
			transform.Translate(Vector3.forward * Time.deltaTime * (lastExec * 2 - 1) * speed);
		} else {
			if (sleep == 0) {
				if (Random.Range (0, 3) == 0) {
					sleep = Random.Range (1, 100) + 200;
				} else {
					walk = Random.Range (250, 500);
					lastExec = Random.Range (0, 2);
				}
			} else {
				sleep -= 1;
			}
		}
	}

	void attack(float dist){
		//dist = -0.007x2 + 0.5615x + 5.7579;
		//dist += Random.Range(-5 , 6); // let it miss
		float rot = 0.1664f * dist * dist - 0.5964f * dist - 2.3429f;
		if (transform.GetChild (1).GetChild (0).GetComponent<spinEnemyCannon> ().spinCannon (rot)) {
			transform.GetChild (1).GetChild (0).GetChild (0).GetChild (0).GetComponent<shootEnemyBullet>().shoot ();
			cd = initCD;
			cd = cd / (int)(Mathf.Abs (dist - 20) / 10 + 1);
		}
	}

	void bodyToward(){
		Vector3 _dir = transform.position - player.transform.position ;
		_dir.Normalize();
		transform.rotation = Quaternion.Slerp(transform.rotation, 
			Quaternion.LookRotation(_dir),  spinRate * Time.deltaTime);
	}

	void cannonToward(){
		transform.GetChild(1).transform.LookAt(2 * transform.position - player.transform.position);

	}

	void trickySpin(){
		if (isTricky > 0) {
			if (offsetCount > 0) {
				gameObject.transform.Rotate (new Vector3 (0, offsetDir, 0), Space.World);
				offsetCount -= 1;
			} else {
				offsetCount = offsetCD;
				offsetDir = Random.Range (-isTricky, isTricky + 1);
			}
		}
	}

	void trace(){
		bodyToward ();
		trickySpin ();
		transform.Translate(Vector3.forward * Time.deltaTime * -speed);
	}

	void escape(){
		bodyToward ();
		trickySpin ();
		transform.Translate(Vector3.forward * Time.deltaTime * speed);
	}

	public void hurt(){
		if (dist > detDist)
			detDist = dist + 10f;
		GameObject.Find ("PlayerZone").GetComponent<moveTank>().enemyLF.SetActive (true);
		life -= 1;

		GameObject.Find ("enemyLFText").GetComponent<Text>().text = life + " / " + totlife;
		GameObject.Find ("enemyRest").GetComponent<Image>().fillAmount = (float)life / (float)totlife;

		if (life == 0) {
			for (float i = -3f; i < 4f; i += 1f)
				for (float j = -3f; j < 4f; j += 1f) {
					Vector3 p = new Vector3 (transform.position.x + i,
						transform.position.y, transform.position.z + j);
					Instantiate (smoke, p , transform.rotation);
				}
			Instantiate (smoke, transform.position, transform.rotation);
			GameObject.Find ("PlayerZone").GetComponent<moveTank>().enemyLF.SetActive (false);
			GameObject.Find ("PlayerZone").GetComponent<moveTank> ().destAdd ();
			GameObject.Find ("PlayerZone").GetComponent<moveTank> ().curEnemy -= 1;
			Destroy (this.gameObject);
		}

	}

	void OnCollisionEnter(Collision collision){

	}
}
