using UnityEngine;
using System.Collections;

public class EnemyPatrol : MonoBehaviour {// this script is for how enemy moving
	public float moveSpeed;
	public bool facingLeft = false;
	public bool moveLeft = false;

	private Animator anim;

	public Transform wallCheck;
	public float wallCheckRadius;
	public LayerMask WhatIsWall;
	private bool hitWall;

	public Transform edgeCheck;
	private bool notHitEdge;
	
	void Flip(){ //function check for flip the enemy when it changing side
		facingLeft = !facingLeft;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		hitWall = Physics2D.OverlapCircle (wallCheck.position, wallCheckRadius, WhatIsWall);
		notHitEdge = Physics2D.OverlapCircle (edgeCheck.position, wallCheckRadius, WhatIsWall);
		if (hitWall || !notHitEdge) {//checking when enemy flip either hit the wall or at the edge
			moveLeft = !moveLeft;
		}
			if (moveLeft) {
				rigidbody2D.velocity = new Vector3 (-moveSpeed, rigidbody2D.velocity.y); //moving the enemy
			} else {
				rigidbody2D.velocity = new Vector3 (moveSpeed, rigidbody2D.velocity.y);
			}
			if (!moveLeft && facingLeft) {//if not moving to the left and facing to the left then flip
				Flip ();
			}
			if (moveLeft && !facingLeft) {//if moving to the left but not facing to the left then flip
				Flip ();
			}
			anim.SetFloat ("Speed", Mathf.Abs (rigidbody2D.velocity.x));
	}
	void OnTriggerEnter2D(Collider2D other){//function for not continuingly hitting the player, still got some buggin but work fine
		if (other.tag == "Player") {
			moveLeft = !moveLeft;
	}
}
}
