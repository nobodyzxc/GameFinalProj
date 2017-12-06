using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraButtonScripts : MonoBehaviour {
	public GameObject StartCamera;
	public GameObject LevelCamera;

	void Start(){
		StartCamera.SetActive (true);
		LevelCamera.SetActive (false);
	}
	public void GameStartButton(){
		StartCamera.SetActive (false);
		LevelCamera.SetActive (true);
	}
	public void BackHomeButton(){
		StartCamera.SetActive (true);
		LevelCamera.SetActive (false);
	}
}
