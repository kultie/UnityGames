using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {//Enemy system with die and dealing damage function
	public int enemyHP;
	public GameObject deathEffect;
	public int pointsOnDeath;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (enemyHP <= 0) {//if enemy's HP < 0 destroy it
			Instantiate(deathEffect, transform.position, transform.rotation);
			ScoreManager.AddPoints(pointsOnDeath);
			Destroy (gameObject);
		}
	}
	
	public void giveDamage (int damageDealt){//deal damage function
		enemyHP -= damageDealt;
		audio.Play ();
	}
}