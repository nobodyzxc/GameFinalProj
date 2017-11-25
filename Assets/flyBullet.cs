using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyBullet : MonoBehaviour {
	public GameObject smoke;
	public GameObject player;
	bool spawned = false;

	// Use this for initialization
	void Start () {
		this.GetComponent<Rigidbody> ().AddRelativeForce (0f , 600f , 0f);
		player = GameObject.Find ("Tank");
	}

	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter(Collision collision){
		if (!spawned) {
			Instantiate (smoke, transform.position, transform.rotation);
			spawned = true;
			if (collision.gameObject.tag == "Player" && collision.gameObject.transform.childCount > 2)
				collision.gameObject.transform.GetChild(2).GetComponent<senseTank> ().hurt ();
			if (collision.gameObject.tag == "Enemy")
				collision.gameObject.GetComponent<moveEnemy> ().hurt ();
		}
		player = GameObject.Find ("Tank");
		//float dy = transform.position.y - player.transform.position.y;
		//float dx = transform.position.x - player.transform.position.x;
		//float dz = transform.position.z - player.transform.position.z;
		//print (dy + " " + (Mathf.Sqrt (dx * dx + dz * dz)));
		//print(Vector3.Distance(player.transform.position , transform.position));
		Destroy (this.gameObject);
	}
}
