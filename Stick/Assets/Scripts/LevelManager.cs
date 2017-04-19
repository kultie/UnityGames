using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {//this is the main script of one level
	public GameObject currentCheckpoint; //Getting check poin
	private PlayerController player; //Get the player
	private HealthManager HPManager; //Get the HealthManager of player

	//Get the particle in game
	public GameObject deathParticle; 
	public GameObject respawnParticle;
	//get the points for penaty and time to player respawn
	private float currentPoints;
	public float pointsPenalty;
	public float respawnDelay;

	private CameraControl camera_main;
	// Use this for initialization
	void Start () {//Find needed Objects
		player = FindObjectOfType<PlayerController> ();
		camera_main = FindObjectOfType<CameraControl> ();
		HPManager = FindObjectOfType<HealthManager> ();

	}
	
	// Update is called once per frame
	void Update () {//The points penalty calculator
		currentPoints = PlayerPrefs.GetFloat("CurrentScore");
		pointsPenalty = currentPoints / 2;
	}
	public void PlayerRespawn(){
		StartCoroutine ("RespawnPlayerCo");
	}
	public IEnumerator RespawnPlayerCo(){//What happen when player DIE
		Instantiate (deathParticle, player.transform.position, player.transform.rotation);//Create death particle
		//disable all player components
		player.enabled = false;	
		player.renderer.enabled = false;
		player.collider2D.enabled = false;
		camera_main.isFollowing = false;
		player.rigidbody2D.velocity = Vector2.zero;
		//player.rigidbody2D.gravityScale = 0f;

		//Points penalty
		ScoreManager.AddPoints (-pointsPenalty);
		//wait then respawn
		yield return new WaitForSeconds (respawnDelay);
		//player.rigidbody2D.gravityScale = gravityScale;
		yield return new WaitForSeconds (0.5f);
		//Respawn is active player objects again with the new position is checkpoint position
		Instantiate (respawnParticle, currentCheckpoint.transform.position, currentCheckpoint.transform.rotation);
		yield return new WaitForSeconds (0.5f);
		player.knockbackCount = 0;
		player.transform.position = currentCheckpoint.transform.position;
		player.enabled = true;
		player.renderer.enabled = true;
		player.collider2D.enabled = true;
		//For the game to run smoothly we gonna need those lines below
		camera_main.isFollowing = true;
		HPManager.fullHealth ();
		HPManager.dead = false;

	}
}
