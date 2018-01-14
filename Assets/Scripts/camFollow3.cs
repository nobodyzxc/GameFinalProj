using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camFollow3 : MonoBehaviour {
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
	public GameObject cam_rotate;
	public float rot_speed;

	float press;
	public float offset_ad;
	Vector3 lookatTra;
	// Use this for initialization
	void Start () {
		//offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		st=asd.GetComponent<jump> ().state;
		if (st == 2) {
			transform.position = Vector3.Lerp(transform.position, player.transform.position + 
				Quaternion.Euler (0, player.transform.eulerAngles.y, 0) * c2p, smooth*Time.deltaTime);
			if (Input.GetKey (KeyCode.RightArrow)) {
				transform.eulerAngles += new Vector3 (0, +rot_speed, 0);
			}
			if (Input.GetKey (KeyCode.LeftArrow)) {
				transform.eulerAngles += new Vector3 (0, -rot_speed, 0);
			}
			press = (Input.GetKey (KeyCode.LeftArrow)) ? press-0.05f : ((Input.GetKey (KeyCode.RightArrow)) ? press+0.05f : press*0.9f);
			press = Mathf.Clamp (press, -1, 1);
			lookatTra = player.transform.localPosition + new Vector3 (press * offset_ad, 0, 0);
			transform.LookAt(player.transform.TransformPoint(lookatTra));
		} else if (st == 3){
			transform.position = Vector3.Lerp(transform.position, player.transform.position + c3p, smooth*Time.deltaTime);
			transform.LookAt(player.transform);
		} else {
			transform.position = Vector3.Lerp(transform.position, player.transform.position + c1p, smooth*Time.deltaTime);
			transform.LookAt(player.transform);
		}

	}
}
