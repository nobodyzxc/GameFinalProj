using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class moveTank : MonoBehaviour {

	// Use this for initialization
	//float speed = 0.1f;
	float speed = 4f;

	public int life = 3;
	public int destCount = 0;

	public GameObject tank;
	public GameObject enemyLF;
	public GameObject GameOver;
	public GameObject curLife;
	public GameObject scoreTank;
	public GameObject enemy;

	public int curEnemy = 0;
	public int enemySpawnRate = 300;
	public int enemySpawnCount = 0;

	void Start () {
		GameOver.SetActive (false);
		curLife.GetComponent<Text> ().text = "TANK : " + life;
		scoreTank.GetComponent<Text> ().text = "DEFEAT : " + destCount;
		for (int i = 0; i < 10; i++)
			genEnemy ();
	}

	// Update is called once per frame
	void Update () {

		Vector3 p = transform.position;
		if (Input.GetKey (KeyCode.LeftArrow))
			gameObject.transform.Rotate (new Vector3 (0, -1, 0) , Space.World);
		if (Input.GetKey (KeyCode.RightArrow))
			gameObject.transform.Rotate (new Vector3 (0, 1, 0) , Space.World);
		if (Input.GetKey (KeyCode.UpArrow))
			transform.Translate(Vector3.forward * Time.deltaTime * -speed);
		if (Input.GetKey (KeyCode.DownArrow))
			transform.Translate(Vector3.forward * Time.deltaTime * speed);
		if (Input.GetKeyUp (KeyCode.Alpha1) && this.transform.childCount == 2) {
			print ("spawn");
			spawn ();
			GameOver.SetActive (false);
			curLife.GetComponent<Text> ().text = "TANK : " + life;
		}
        if (Input.GetKeyUp (KeyCode.KeypadEnter) && this.transform.childCount == 2) {
			print ("spawn");
			spawn ();
			GameOver.SetActive (false);
			curLife.GetComponent<Text> ().text = "TANK : " + life;
		}
		if (enemySpawnCount == enemySpawnRate) {
			genEnemy ();
			enemySpawnCount = 0;
		} else
			enemySpawnCount += 1;
	}

	public void subLife(){
		life -= 1;
		curLife.GetComponent<Text> ().text = "TANK : " + life;
		if (life == 0) {
			print ("set");
			GameOver.SetActive (true);
		}
	}

	public void destAdd(){
		if (life > 0) {
			destCount += 1;
			scoreTank.GetComponent<Text> ().text = "DEFEAT : " + destCount;
		}
	}

	float pnRng(float s , float e){
		int pos = 1;
		if (Random.Range (0, 2) == 0)
			pos = -1;
		return pos * Random.Range (s, e);

	}

	public void genEnemy(){
		if (curEnemy > 50)
			return;
		curEnemy += 1;
		Instantiate (enemy , this.transform.position +
			new Vector3 (pnRng(35f , 100f), 0.3f, pnRng(35f , 100f)), this.transform.rotation);
	}

	public void spawn(){
		Instantiate (tank, this.transform.position + new Vector3(0 , 0.1f , 0) , this.transform.rotation).transform.parent = this.transform;
	}

	void OnCollisionEnter(Collision collision){

	}
}
