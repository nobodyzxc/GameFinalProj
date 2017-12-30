using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camFollow2 : MonoBehaviour {

//5.3 1.55 3.7
	Vector3 c1p= new Vector3(-0.1030156f,3.091995f,4.299012f);
//	Vector3 c1er= new Vector3(30.38f,156.08f,0);
	Vector3 c2p= new Vector3(-0.03f,0.89f,-1.28f);
	Vector3 c3p= new Vector3(-0.03f,0.89f + 2f ,-1.28f - 1f);
//	Vector3 c2er= new Vector3(-180, 0, 0);
	Vector3 player_acc=new Vector3(0,0,0);
	Vector3 pre_speed;
	public float total_smooth;
	public float acc_strengh;
	Rigidbody plrb;
	Vector3 offset;
	int st;
	public GameObject player;
	public GameObject player_script;

	// Use this for initialization
	void Awake () {
		plrb = player_script.GetComponent<Rigidbody> ();
		pre_speed=plrb.velocity;
		//offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		st=player_script.GetComponent<jump> ().state;
		player_acc = (plrb.velocity-pre_speed)/Time.fixedDeltaTime;
		player_acc -= new Vector3 (0, -10, 0);
		pre_speed=plrb.velocity;
		Debug.Log (player_acc);
		if (st == 2) {
			//offset = (transform.localPosition - c2p) * total_smooth;
			//transform.position = Vector3.Lerp(transform.position, player.transform.position + c2p, Time.fixedDeltaTime);

			transform.position = Vector3.Lerp(transform.position, player.transform.position + 
				Quaternion.Euler (0, player.transform.eulerAngles.y, 0) * c2p - Vector3.Normalize(player_acc)*acc_strengh, total_smooth*Time.fixedDeltaTime);
		} else if (st == 3){
			transform.position = Vector3.Lerp(transform.position, player.transform.position + c3p - Vector3.Normalize(player_acc)*acc_strengh, total_smooth*Time.fixedDeltaTime);
			//offset = (transform.localPosition - c3p) * total_smooth;
		} else {
			transform.position = Vector3.Lerp(transform.position, player.transform.position + c1p - Vector3.Normalize(player_acc)*acc_strengh, total_smooth*Time.fixedDeltaTime);
			//offset = (transform.localPosition - c1p) * total_smooth;
		}
		//transform.localPosition = transform.localPosition - offset;
		//nv.transform.position = new Vector3(nv.transform.position.x , 9.38f , nv.transform.position.z);
		transform.LookAt(player.transform.position-Vector3.Normalize(player_acc)*acc_strengh/3);
//		Debug.Log(Vector3.Distance(transform.position, player.transform.position));


	}
}
