using UnityEngine;
using System.Collections;

public class AudioSystem : MonoBehaviour {//Controlling the audio system

	// Use this for initialization
	void Start () {
		Debug.Log ("Setting volume to " + PlayerPrefs.GetInt("volume"));
		AudioListener.volume = PlayerPrefs.GetInt("volume");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
