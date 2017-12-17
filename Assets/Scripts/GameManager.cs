using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	float Score = 0f;
	public Text ScoreText;
	public Text VictoryScoreText;
	// Use this for initialization
	void Start () {
		
	}
	public void addScore(float n){
		Score += n;
	}
	// Update is called once per frame
	void Update () {
		ScoreText.text = "Score : " + (int)Score;
		VictoryScoreText.text = "Your Score : " + (int)Score;
	}
}
