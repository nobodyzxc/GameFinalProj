using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camFollow1 : MonoBehaviour {
	Vector3 c1p= new Vector3(-0.1030156f,3.091995f,4.299012f);
//	Vector3 c1er= new Vector3(30.38f,156.08f,0);
	Vector3 c2p= new Vector3(-0.03f,0.89f,-1.28f);
//	Vector3 c2er= new Vector3(-180, 0, 0);
	public float smooth;
	Vector3 offset;
	int st;
	public GameObject player;
	public GameObject asd;
	// Use this for initialization
	void Start () {
		//offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		st=asd.GetComponent<jump> ().state;
		if (st !=2) {
			offset = (transform.localPosition - c1p) * smooth;
		} else {
			offset = (transform.localPosition - c2p) * smooth;
		}
		transform.localPosition = transform.localPosition - offset;
		//nv.transform.position = new Vector3(nv.transform.position.x , 9.38f , nv.transform.position.z);
		transform.LookAt(player.transform);
	}
}
