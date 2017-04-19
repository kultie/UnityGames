using UnityEngine;
using System.Collections;

public class KunaiCharger : MonoBehaviour {//this script for picking up bullet = "kunai" in-game
	public int kunaiAmount;
	public AudioSource powerPickUPSound;
	void OnTriggerEnter2D(Collider2D other){
		if (other.name == "Player") {
			KunaiCounter.AddKunai(kunaiAmount);
			Destroy(this.gameObject);
			powerPickUPSound.Play();
		}
		else return;
	}
}
