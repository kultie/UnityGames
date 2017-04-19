using UnityEngine;
using System.Collections;

public class LifePickup : MonoBehaviour {//Script controller when you pick up lives
	private LifeManager lifeSystem;
	public AudioSource audio_pickup;
	// Use this for initialization
	void Start () {
		lifeSystem = FindObjectOfType<LifeManager> ();
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D other){//hurra you pick up 1 live 
		if (other.tag == "Player") {
			lifeSystem.extraLife();
			Destroy(gameObject);
			audio_pickup.Play ();
		}
	}
}
