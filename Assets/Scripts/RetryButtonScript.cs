using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetryButtonScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void ReloadLevel(){
		Application.LoadLevel(Application.loadedLevel);
	}
	public void ReturnHome(){
		Application.LoadLevel("GameStart");
	}
}
