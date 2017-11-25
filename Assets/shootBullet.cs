using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shootBullet : MonoBehaviour {
	public GameObject bullet;
	public Image powerBar;
	float addPow = 0f;
	float maxPow = 600f;
	int cd = 0;
	int initCD = 5;
	// Use this for initialization
	void Start () {
		powerBar = GameObject.Find ("powerBar").GetComponent<Image> ();
	}
	
	void Update () {
		if (Input.GetKey (KeyCode.Space)) {
			if(addPow < maxPow)
				addPow += 5;
			powerBar.fillAmount = addPow / maxPow;
		}
		if (Input.GetKeyUp (KeyCode.Space) && cd == 0) {
			shoot (addPow);
			addPow = 0;
			powerBar.fillAmount = 0;
			cd = initCD;
		}
		if (cd > 0)
			cd -= 1;
	}

	public void shoot(float extra){
		GameObject obj = transform.parent.transform.parent.gameObject;
		Vector3 rot = obj.transform.rotation.eulerAngles;
		rot = new Vector3(rot.x - 90 ,rot.y ,rot.z);
		GameObject b = Instantiate (bullet , transform.position - (transform.forward) , Quaternion.Euler(rot));
		b.GetComponent<Rigidbody>().AddRelativeForce (0f , extra , 0f);
	}
}
