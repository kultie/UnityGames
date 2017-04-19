using UnityEngine;
using System.Collections;

public class LevelLoader : MonoBehaviour {//script for which level will load when player hit the requirement
	public string level;
	private PlayerController player;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerStay2D(Collider2D other){
		if (other.tag == "Player") {
			if(player.punching){//When player tab melee button
				Application.LoadLevel(level);
			}
		}
	}
}
