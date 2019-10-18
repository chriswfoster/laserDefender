using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {
	
	Text scoreText;
	public static int gameScore;
	
	// Use this for initialization
	void Start () {
		gameScore = 0;
		scoreText = GetComponent<Text>();
		scoreText.text = "" + gameScore;
	}
	
	public void Score (int points){
		gameScore += points;
		scoreText.text = "" + gameScore;
		// or = gameScore.ToString
	}
	
	public static void Reset(){
		gameScore = 0;
	}
}
