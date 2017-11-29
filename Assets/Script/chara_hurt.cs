using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chara_hurt : MonoBehaviour {

	void OnJointBreak(float bf){
		GetComponent<Renderer> ().material.color = new Color (1, 0, 0, 1);
		GetComponent<Joint>().connectedBody.gameObject.GetComponent<Renderer> ().material.color = new Color (1, 0, 0, 1);
	}
}
