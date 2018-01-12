using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hintScript : MonoBehaviour {
	public GameObject HintPanel;
	public Text hint;
	public jump _jump;
	float timer;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (_jump.state == 0) {
			hint.text = "press space to jump";
		}else if (_jump.state == 1 || _jump.state == 2) {
			hint.text = "press Z fly";
			timer += Time.deltaTime;
			if (timer > 5f) {
				hint.text = "press space open parachute";
			}
		} else if (_jump.state == 3) {
			HintPanel.SetActive (true);
			hint.text = "press space drop parachute";
		} else {
			hint.text = "";
			HintPanel.SetActive (false);
		}
	}
}
