using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadLevelButtonScript : MonoBehaviour {
	public GameObject loadindBackGround;
	public Text loadText;
	public Image loadImage;
	// Use this for initialization
	void Start () {
		
	}
	public void LoadGameLevel01(){
		StartCoroutine (DisplayLoadingScreen("Level01"));
	}
	public void LoadGameLevel02(){
		StartCoroutine (DisplayLoadingScreen("Level02"));
	}
	public void LoadGameLevel03(){
		StartCoroutine (DisplayLoadingScreen("Level03"));
	}
	IEnumerator DisplayLoadingScreen (string sceneName){////(1)
		loadindBackGround.SetActive(true);
		AsyncOperation async = Application.LoadLevelAsync (sceneName);////(2)
		while (!async.isDone) {////(3)
			loadText.text = (async.progress * 100).ToString() + "%";////(4)
			loadImage.transform.localScale = new Vector2(async.progress,loadImage.transform.localScale.y);
			yield return null;
		}
	} 
}
