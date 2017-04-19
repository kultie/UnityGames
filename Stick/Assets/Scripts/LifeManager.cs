using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour {//Showing how much life do we have
	//public int startingLives;
	private int lifeCounter;

	public GameObject GameOverCanvas;
	public PlayerController player;
	private Text text;
	// Use this for initialization
	void Start () {//Finding needed Objects and components
		text = GetComponent<Text> ();

		lifeCounter = PlayerPrefs.GetInt("PlayerCurrentLives");
		player = FindObjectOfType<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {//Get the text for UI
		text.text = "x " + lifeCounter;
		if (lifeCounter <= 0) {
			GameOverCanvas.SetActive(true);
			player.gameObject.SetActive(false);
		}

	}
	public void extraLife(){//Take an extra live 
		lifeCounter ++;
		PlayerPrefs.SetInt ("PlayerCurrentLives", lifeCounter);
	}
	public void takeLife(){//take life when you die
		lifeCounter --;
		PlayerPrefs.SetInt ("PlayerCurrentLives", lifeCounter);
	}
}
