using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heli_moving : MonoBehaviour {
	public float speed;
	public float uprotateSpeed;
	public float tailrotateSpeed;
	float timeA;
	float rot;
	public GameObject uprot, tailrot;
	public GameObject playerbeforejumping;

	void Start(){
		rot=transform.rotation.y;
		GetComponent<Rigidbody> ().velocity = new Vector3 (-speed * Mathf.Sin (rot), 0, -speed * Mathf.Cos (rot));
		playerbeforejumping.GetComponent<Rigidbody> ().velocity = new Vector3 (-speed * Mathf.Sin (rot), 0, -speed * Mathf.Cos (rot));
	}
	void Update(){
//		Debug.Log (playerbeforejumping.GetComponent<Rigidbody> ().velocity);
//		Debug.Log(timeA);
		uprot.transform.rotation=Quaternion.Euler(new Vector3(0, uprotateSpeed*timeA,5.03f));
		tailrot.transform.rotation=Quaternion.Euler(new Vector3(0, 0, tailrotateSpeed*timeA));
		timeA = (timeA+Time.deltaTime)%360;
	}
}
