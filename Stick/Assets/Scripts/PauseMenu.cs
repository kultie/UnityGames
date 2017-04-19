using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {//When you hit pause this will show
	public bool paused;
	//Get the cavas for active and deactive them
	public GameObject pauseMenuCanvas;
	public GameObject howtoCanvas;
	public AudioSource audio_button;
	void Start(){
	}
	void Update(){
		if (paused) {//Pause and unpause 
			pauseMenuCanvas.SetActive (true);
		} else {
			pauseMenuCanvas.SetActive (false);
		}
	}

	public void Resume(){//Resume the game
		paused = false;
		Time.timeScale = 1;
		audio_button.Play ();
	}
	//public void HowTo(){//How to play the game will be here this will be disable in the apk
		//audio_button.Play ();
		//howtoCanvas.SetActive (true);
		//pauseMenuCanvas.SetActive (false);

	//}
	public void MainMenu(){//Return to the title
		audio_button.Play ();
		Application.LoadLevel ("Title");
		AudioListener.pause = false;
		Time.timeScale = 1;
	}
}
