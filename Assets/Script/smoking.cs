using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smoking : MonoBehaviour {
	int life = 500;
	// Use this for initialization
	void Start () {
		this.GetComponent<ParticleSystem> ().Play ();
	}

	// Update is called once per frame
	void Update () {
		if(this.GetComponent<Light> ().intensity > 0)
			this.GetComponent<Light> ().intensity -= 0.5f;
		
		if (life > 0)
			life -= 1;
		if(life == 350)
			this.GetComponent<ParticleSystem> ().Stop ();
		if (life == 100)
			Destroy (gameObject);
	}
}
