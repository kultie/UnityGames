using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {//What you need for moving the player
	//The speed
	public float moveSpeed;
	private float moveVelocity;
	private bool facingLeft = false;
	private bool canMove;
	//What jump need
	public float jumpHeight;
	public bool jumpAble;
	//Can't attack without them
	public float attackTime;
	public float attackTimeCounter;
	public bool punching;
	public bool isThrowing;
	public float timeCounter;
	//Where and how the kunai is throw
	private ThrowPoint throwPoint;
	private KunaiController kunaiController;
	//Checking for jumping
	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask WhatIsGround;
	private bool grounded;
	//Aimate, physics, and the current level system
	private Animator anim;
	public LevelManager levelManager;
	private Rigidbody2D myrigidbody2D;
	//Get hit and knock back
	public float knockback;
	public float knockbackLength;
	public float knockbackCount;
	public bool knockFromRight = true;	
	
	//public bool die = false;

	void Flip(){//funciont for flip
		facingLeft = !facingLeft;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	public void meleePressed(){//When attack key got pressed and if grounded then you can attack
		if (grounded) {
			attackTimeCounter = attackTime;
		}
	}
	public void attack(){//function attack
		if (attackTimeCounter > 0) {//Time of one attack calculator
			attackTimeCounter -= Time.deltaTime;
			jumpAble = false;//Can't jump while attack !!DUH
			punching = true;
			anim.SetBool ("Punching", true);//Animation of slasing things 
			myrigidbody2D.velocity = new Vector3 (0, rigidbody2D.velocity.y);//Can't move while attack too !HAHAHAHAH
		} else {
			jumpAble = true;
			punching = false;
			anim.SetBool ("Punching", false);//Animate of put down your sword 
		}
	}
	public void Throwing(){//Throwing kunai function
		if (KunaiCounter.kunaiCounter > 0) {
			throwPoint.Shooting ();
			KunaiCounter.kunaiCounter = KunaiCounter.kunaiCounter - 1;
		} else {
			anim.SetBool("Throwing", false);
		}
	}
	public void ThrowCancel(){
		if (timeCounter > 0) {
			timeCounter -= Time.deltaTime;
			anim.SetBool ("Throwing", true);
		} else {
			anim.SetBool ("Throwing",false);
		}
	}
	public void ThrowingUnPress(){
		anim.SetBool ("Throwing", false);
	}

	public void getHit(){//When you get hit
		if (knockbackCount > 0) {
			anim.SetBool ("Hit", true);//Animate
			canMove = false;//Can't do anything when getting hit
			if (knockFromRight) {//When you get hit from the right
				myrigidbody2D.velocity = new Vector2 (-knockback, 0.5f);
				if(facingLeft){
					Flip();
				}
			} else {//And from the left
				myrigidbody2D.velocity = new Vector2 (knockback, 0.5f);
				if(!facingLeft){
					Flip ();
				}
			}
			knockbackCount -= Time.deltaTime;//How long you get hit
		} else {//The knock back time is over now you can do things
			canMove = true;
			anim.SetBool("Hit", false);
		}
	}
	public void Jump(){//function for jumping
		if (jumpAble && grounded) { //Can only jump if on the ground and can jump
			myrigidbody2D.velocity = new Vector2 (0f, jumpHeight);
			anim.SetBool ("Ground", false);
		}
	}
	public void moving(float moveInput){//functino for moving
		if (!punching && canMove) {
			if (moveInput > -0.1f || moveInput < 0.1f) {
				float move = moveInput;//Gives us of one if we are moving via the arrow keys
				moveVelocity = moveSpeed;
				myrigidbody2D.velocity = new Vector3 (move * moveVelocity, rigidbody2D.velocity.y);	
				//set our speed
				anim.SetFloat ("Speed", Mathf.Abs (moveSpeed * moveVelocity));
			
				//if we are moving left but not facing left flip, and vice versa
				if (move < 0 && !facingLeft) {
				
					Flip ();
				} else if (move > 0 && facingLeft) {
					Flip ();
				}
			}
		}
	}
	void Start () {	//What you need when the game start? EVERYTHINGS
		levelManager = FindObjectOfType<LevelManager> ();
		anim = GetComponent<Animator> ();
		kunaiController = FindObjectOfType<KunaiController> ();
		throwPoint = FindObjectOfType<ThrowPoint> ();
		myrigidbody2D = GetComponent<Rigidbody2D> ();
	}
	void FixedUpdate(){//by a fixed time pass
		jumpAble = true;
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, WhatIsGround);//Var for are you on the ground?
		anim.SetBool ("Ground", grounded);//When on the ground
		anim.SetFloat ("vSpeed", rigidbody2D.velocity.y);
		//moving (Input.GetAxis("Horizontal"));//this will be disable in the apk file
	}
	// Update is called once per frame
	void Update () {
		//isThrowing = false;
		canMove = true;
		//Death ();
		if(Input.GetKey(KeyCode.Z)){
			meleePressed();
		}
		attack ();
		if (Input.GetKeyDown (KeyCode.C)) {
			Jump ();
		}
		if (Input.GetKeyDown (KeyCode.X)) {
			Throwing();
			timeCounter = 0.001f;
			ThrowCancel();
		}
		if (Input.GetKeyUp (KeyCode.X)) {
			ThrowingUnPress();
		}
		getHit ();
		moveVelocity = 0f;
		anim.SetFloat ("Speed", Mathf.Abs (rigidbody2D.velocity.x));//Get the speed for animator
	}


}
