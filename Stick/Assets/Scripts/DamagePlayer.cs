using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class DamagePlayer : MonoBehaviour { //this for player collide with anything that can damage him
	public LevelManager levelManager;
	public PlayerController player;
	public int damage;
	// Use this for initialization
	void Start () {//find necessary components and objects
		levelManager = FindObjectOfType<LevelManager> ();
		player = FindObjectOfType<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.name == "Player") {//if collide with player
			HealthManager.damagePlayer(damage); //minus HP
			other.audio.Play();

			player.knockbackCount = player.knockbackLength; //knock back base on which side player currently see
			if(transform.position.x < other.transform.position.x){
				player.knockFromRight = false;
			}
			else{
				player.knockFromRight = true;
			}
		}
	}
}

