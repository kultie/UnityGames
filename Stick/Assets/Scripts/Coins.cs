using UnityEngine;
using System.Collections;

public class Coins : MonoBehaviour {
	public int points = 5;

	public AudioSource pickUpsound;
	// Use this for initialization
	void OnTriggerEnter2D(Collider2D other){
		if (other.name == "Player") {
			ScoreManager.AddPoints (points);
			Destroy (this.gameObject);
			pickUpsound.Play();
		} else
			return;
	}
}
