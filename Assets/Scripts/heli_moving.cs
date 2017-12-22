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
	public GameObject destination;
	public GameObject heli;
	float step = 20f;
	float spinStep = 1f;


	void Start(){
	}
	void Update(){
		
//		if (true) {
//			Vector3 tardir = (transform.position - destination.transform.position).normalized;
//			tardir = new Vector3 (tardir.x, 0f, tardir.z);
//			Vector3 newdir = Vector3.RotateTowards (transform.forward, tardir, spinStep * Time.deltaTime, 0.0f);
//			transform.rotation = Quaternion.LookRotation (newdir);
//		}

		//transform.position = Vector3.MoveTowards(transform.position, destination.transform.position, step * Time.deltaTime);


//		Debug.Log (playerbeforejumping.GetComponent<Rigidbody> ().velocity);
//		Debug.Log(timeA);
		uprot.transform.rotation=Quaternion.Euler(new Vector3(0, uprotateSpeed*timeA,5.03f));
		tailrot.transform.rotation=Quaternion.Euler(new Vector3(0, 0, tailrotateSpeed*timeA));
		timeA = (timeA+Time.deltaTime)%360;
	}
}
