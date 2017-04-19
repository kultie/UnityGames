using UnityEngine;
using System.Collections;

public class IngameButton : MonoBehaviour {//this script controlling the button in-game UI
	public PauseMenu pauseMenu;
	public bool muted;
	public AudioSource audio_button;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}
	public void Pause(){//pause button
		pauseMenu.GetComponent<PauseMenu> ().paused = true;
		pauseMenu.pauseMenuCanvas.SetActive (true);
		Time.timeScale = 0;
		audio_button.Play ();
	}
	public void Mute(){//Mute button
		muted = !muted;
		if (muted == true) {
			AudioListener.volume = 0;
			PlayerPrefs.SetInt ("volume", 0);
			Debug.Log ("Setting volume to " + PlayerPrefs.GetInt ("volume"));
		} else if (muted == false) {
			AudioListener.volume = 1;
			PlayerPrefs.SetInt ("volume", 1);
			Debug.Log ("Setting volume to " + PlayerPrefs.GetInt ("volume"));
		}
	}
	public void toTitle(){//return to title button
		Application.LoadLevel ("Title");
	}
	public void Retry(){//Retry when you are so bad at this game and running out of lives the game gives you
		Application.LoadLevel (Application.loadedLevel);
		PlayerPrefs.SetInt ("PlayerCurrentLives", PlayerPrefs.GetInt("PlayerMaxLives"));
		PlayerPrefs.SetFloat ("CurrentScore", 0);
		PlayerPrefs.SetInt ("PlayerCurrentHP", PlayerPrefs.GetInt ("PlayerMaxHP"));
	}

}
