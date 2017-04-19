using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {//Script for showing score you got
	public static float score;
	public static float currentScore;

	Text text;

	void Start(){
		text = GetComponent<Text> ();

		score = PlayerPrefs.GetFloat ("CurrentScore");
	}
	void Update(){//Text on the UI
		if (score <= 0) {
			score = 0;
		}
		text.text = "" + score;
	}

	public static void AddPoints(float points){//Adding score if requirement is met
		score += points;
		PlayerPrefs.SetFloat ("CurrentScore",score );
	}
	//public static void Reset(){
		//score = 0;
	//}
}
