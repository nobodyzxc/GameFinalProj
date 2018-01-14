using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camFollow1 : MonoBehaviour {
	Vector3 c1p= new Vector3(-0.1030156f,3.091995f,4.299012f);
//	Vector3 c1er= new Vector3(30.38f,156.08f,0);
	Vector3 c2p= new Vector3(-0.03f,0.89f,-1.28f);
	Vector3 c3p= new Vector3(-0.03f,0.89f + 2f ,-1.28f - 1f);
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
		if (st == 2) {
			transform.position = Vector3.Lerp(transform.position, player.transform.position + 
				Quaternion.Euler (0, player.transform.eulerAngles.y, 0) * c2p, Time.deltaTime);
		} else if (st == 3){
			transform.position = Vector3.Lerp(transform.position, player.transform.position + c3p, Time.deltaTime);
		} else {
			transform.position = Vector3.Lerp(transform.position, player.transform.position + c1p, Time.deltaTime);
		}
		transform.LookAt(player.transform);
	}
}
