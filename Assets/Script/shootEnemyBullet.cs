using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootEnemyBullet : MonoBehaviour {
	public GameObject bullet;
	int isMirror;
	// Use this for initialization
	void Start () {
		isMirror = Random.Range (0, 6); // 1/6 possibility
		if(isMirror == 0) print(">> isMirror");
	}

	void Update () {
		if (isMirror == 0 && Input.GetKeyUp (KeyCode.Space)) {
			shoot ();
		}
	}

	public void shoot(){
		GameObject obj = transform.parent.transform.parent.gameObject;
		Vector3 rot = obj.transform.rotation.eulerAngles;
		rot = new Vector3(rot.x - 90 ,rot.y ,rot.z);
		Instantiate (bullet , transform.position - (transform.forward) , Quaternion.Euler(rot));
	}
}