using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class senseTank : MonoBehaviour {
	int totlife = 8;
	int life = 8;
	public GameObject loading;
	public GameObject smoke;
	public GameObject	lftxt;
	Vector3 offset;
	// Use this for initialization
	void Start () {
		loading = GameObject.Find ("playerRest");
		lftxt = GameObject.Find ("playerLFText");
		lftxt.GetComponent<Text>().text = life + " / " + totlife;
		loading.GetComponent<Image>().fillAmount = (float)life / (float)totlife;
		GameObject.Find ("PlayerZone").GetComponent<moveTank>().enemyLF.SetActive (false);

	}
	
	// Update is called once per frame
	void Update () {
	}

	public void hurt(){
		life -= 1;
		lftxt.GetComponent<Text>().text = life + " / " + totlife;
		loading.GetComponent<Image>().fillAmount = (float)life / (float)totlife;
		print ("HURT ! HURT !");
		if (life == 0) {
			for (float i = -3f; i < 4f; i += 1f)
				for (float j = -3f; j < 4f; j += 1f) {
					Vector3 p = new Vector3 (transform.position.x + i,
						transform.position.y, transform.position.z + j);
					Instantiate (smoke, p , transform.rotation);
				}
			Instantiate (smoke, transform.position, transform.rotation);
			Destroy (this.gameObject);
			GameObject.Find ("PlayerZone").GetComponent<moveTank> ().subLife ();
		}
	}
}
