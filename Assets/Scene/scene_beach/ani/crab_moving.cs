using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crab_moving : MonoBehaviour {
	float timeA;
	float head;
	public float sp;
	public GameObject ra;
	Vector3 pre_pos;
	void Awake(){
		timeA = Random.Range(0,20);
		head = Random.Range (0, 360);
		ra.gameObject.transform.rotation=Quaternion.Euler(new Vector3(0,head,0));
		pre_pos = transform.localPosition;
	}
	// Update is called once per frame
	void Update () {
		timeA += Time.deltaTime;
		if (timeA < 10) {
			transform.localRotation=Quaternion.Euler(new Vector3(0,0,0));
			transform.localPosition = pre_pos + new Vector3(timeA * sp,0,0);

		} else if (timeA < 20) {
			transform.localRotation=Quaternion.Euler(new Vector3(0,180,0));
			transform.localPosition = pre_pos + new Vector3((20 - timeA) * sp,0,0);
		} else {
			timeA -= 20;
		}
	}
	void OnCollisionStay(Collision other){
		Debug.Log ("ASD");
	}
}