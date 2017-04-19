using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour {
	public LevelManager levelManager;
	private Animator anim;
	public AudioSource audio_check;
	
	// Use this for initialization
	void Start () {
		levelManager = FindObjectOfType<LevelManager> ();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.name == "Player") { //if collied with player save spawn pos of player to checkpoint
			levelManager.currentCheckpoint = gameObject;
			anim.SetBool ("PlayerHit", true);
			audio_check.Play();
		}
	}
}