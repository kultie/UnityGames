using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour {//Show the score when you need them
	private Text text;
	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();
		text.text = "Your Score: " + PlayerPrefs.GetFloat ("CurrentScore");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
