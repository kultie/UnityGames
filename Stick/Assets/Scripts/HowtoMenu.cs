using UnityEngine;
using System.Collections;

public class HowtoMenu : MonoBehaviour {//this script is for controlling the "howto..." menu in-game, this open howto and return to previous, will see in-game
	public GameObject previousCanvas;
	public GameObject howtoCanvas;
	public AudioSource audio_button;
	// Use this for initialization
	void Start () {
	
	}
	public void Return(){
		howtoCanvas.SetActive (false);
		previousCanvas.SetActive (true);
		audio_button.Play ();
	}
}
