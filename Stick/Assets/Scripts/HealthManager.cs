using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {
	public int maxPlayerHP;
	public static int currentPlayerHP;

	public bool dead;
	Text text;

	private LifeManager lifeSystem;

	private LevelManager levelManager;
	// Use this for initialization
	void Start () {//finding necessary components
		text = GetComponent<Text> ();
		currentPlayerHP = PlayerPrefs.GetInt ("PlayerMaxHP");
		levelManager = FindObjectOfType<LevelManager> ();
		dead = false;
		lifeSystem = FindObjectOfType<LifeManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (currentPlayerHP <= 0 && !dead) { //if HP <0 kill player and take 1 life
			currentPlayerHP = 0;
			levelManager.PlayerRespawn();
			lifeSystem.takeLife();
			dead = true;
		}
		text.text = "" + currentPlayerHP;//Get text of HP
		if (currentPlayerHP <= 0) {
			text.text = "" + 0;
		}
	}
	public static void damagePlayer(int damageDealt){ //minus HP when get hit
		currentPlayerHP -= damageDealt;
		PlayerPrefs.SetInt ("PlayerCurrentHP",currentPlayerHP);
	}
	public void fullHealth(){ //Set HP player to max
		currentPlayerHP = PlayerPrefs.GetInt ("PlayerMaxHP");
	}
}
