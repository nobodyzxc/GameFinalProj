using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randombloods : MonoBehaviour {

	// Use this for initialization
	void Start () {
		float xx = Random.Range (-0.7f, 0.7f);
		float yy = Random.Range (0.3f, 0.4f);
		float zz = Random.Range (-1f, 0.7f);
		transform.localPosition = new Vector3 (xx, yy, zz);
	}

}
