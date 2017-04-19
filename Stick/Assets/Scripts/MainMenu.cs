using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {//Controlling how the menu at title work
	public string startLevel;
	public GameObject howtoCanvas;
	public GameObject mainMenu;
	public AudioSource audio_button;//Audio when you pick player


	public int playerMaxHP;
	public int playerLives;
	void Start(){
	}
	//Main Menu
	void Update(){
	}
	public void NewGame(){//This is for setting every thing basic for new game
		PlayerPrefs.SetInt ("PlayerMaxLives", playerLives);
		PlayerPrefs.SetInt ("PlayerCurrentLives", playerLives);
		PlayerPrefs.SetFloat ("CurrentScore", 0);
		PlayerPrefs.SetInt ("PlayerCurrentHP", playerMaxHP);
		PlayerPrefs.SetInt ("PlayerMaxHP",playerMaxHP);

		audio_button.Play ();
		Application.LoadLevel (startLevel);
	}
	public void Howto(){//Active howto menu
		audio_button.Play ();
		howtoCanvas.SetActive (true);
		mainMenu.SetActive (false);
	}
	public void Exit(){//Quit game
		audio_button.Play ();
		Application.Quit ();
	}
}
