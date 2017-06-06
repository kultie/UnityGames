using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float speed = 2f;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		rigidbody2D.velocity = new Vector3 ( -speed, rigidbody2D.velocity.y);
		if (transform.position.x < -20f) {
			Destroy(gameObject);
		}		
	}	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") {
			Destroy (other.gameObject);
			Destroy	(this.gameObject);
		}
	}
}
