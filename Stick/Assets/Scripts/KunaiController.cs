using UnityEngine;
using System.Collections;

public class KunaiController : MonoBehaviour {//Kuani controller obvious
	public float speed;//speed of kunai
	public PlayerController player;
	public GameObject hitEffect;
	// Use this for initialization
	void Start () {//find playercontroller objects
		player = FindObjectOfType<PlayerController> ();
		if (player.transform.localScale.x < 0) {//flip side when player flip
			speed *= -1;
			transform.localScale *= -1;
		}

	}
	
	// Update is called once per frame
	void Update () {//flying when shoot
		rigidbody2D.velocity = new Vector2 (speed, rigidbody2D.velocity.y);

	}
	void OnTriggerEnter2D(Collider2D other){//create particle when hit objects
			Instantiate(hitEffect,this.transform.position, this.transform.rotation);
			Destroy (this.gameObject);
	}
}
